using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text; 
using Newtonsoft.Json;
namespace ERP.APIWrapper
{
    public static class APIHelper
    {

        public static APIResponse PostToAPI<T>(T obj, string callUrl, string method, string argToken)
        {

            var resultResponse = new APIResponse() { Success = false };
            HttpWebResponse response = null;

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(callUrl);
            httpWReq.ContentType = "application/json; charset=utf-8";
            httpWReq.Method = method;

            using (Stream stream = httpWReq.GetRequestStream())
            {
                var data = new DataContractJsonSerializer(typeof(T));
                data.WriteObject(stream, obj);
            }

            try
            {
                response = (HttpWebResponse)httpWReq.GetResponse();
                var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(result);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("400") || ex.Message.Contains("Bad Request"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    dynamic responseValue = res.GetData();
                    resultResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                }
                else if (ex.Message.Contains("500") || ex.Message.Contains("Internal server error"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    dynamic responseValue = res.GetData();
                    resultResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                }
            }


            return resultResponse;
        }
                
        public static APIResponseError PostToAPIError<T>(T obj, string callUrl, string method, string argToken)
        {
            var resultResponse = new APIResponseError() { Success = true };
            HttpWebResponse response = null;

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(callUrl);
            httpWReq.ContentType = "application/json; charset=utf-8";
            httpWReq.Method = method;

            using (Stream stream = httpWReq.GetRequestStream())
            {
                var data = new DataContractJsonSerializer(typeof(T));
                data.WriteObject(stream, obj);
            }

            try
            {
                response = (HttpWebResponse)httpWReq.GetResponse();
                var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultResponse.Error = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorLog>(result);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("400") || ex.Message.Contains("Bad Request"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    dynamic responseValue = res.GetData();
                    resultResponse.Error = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorLog>(responseValue);
                }
                else if (ex.Message.Contains("500") || ex.Message.Contains("Internal server error"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    dynamic responseValue = res.GetData();
                    resultResponse.Error = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorLog>(responseValue);
                }
            }
            return resultResponse;
        }

        public static IEnumerable<KVPair> GetLookUpFromAPI(string callUrl)
        {
            var stringRes = MakeGetRequest(callUrl);
            return JsonConvert.DeserializeObject<IEnumerable<KVPair>>(stringRes);
        }

        public static IEnumerable<T> GetCollectionAPI<T>(string callUrl)
        {

            var stringRes = MakeGetRequest(callUrl);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(stringRes);
        }

        public static T GetObjectAPI<T>(string callUrl)
        {
            var stringRes = MakeGetRequest(callUrl);
            return JsonConvert.DeserializeObject<T>(stringRes);
        }

        public static string MakeGetRequest(string url)
        {
            var request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            var resultResponse = new APIResponse() { Success = false };

            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";

            var responseValue = string.Empty;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    responseValue = response.GetData();
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("400") || ex.Message.Contains("Bad Request"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    responseValue = res.GetData();
                    resultResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                    ConstructExceptionLogging("MakeGetRequest", resultResponse.ErrorCode, resultResponse.ErrorContent);
                }
                else if (ex.Message.Contains("500") || ex.Message.Contains("Internal server error"))
                {
                    System.Net.HttpWebResponse res = (HttpWebResponse)ex.Response;
                    responseValue = res.GetData();
                    resultResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                    ConstructExceptionLogging("MakeGetRequest", resultResponse.ErrorCode, resultResponse.ErrorContent);
                }
            }
            return responseValue;
        }

        public static void ConstructExceptionLogging(string argAction, string argErrorId, string argMessage)
        {

            if (!string.IsNullOrEmpty(argErrorId))
            {
                LogException("Web_Api_Error:" + argErrorId + "______________" + argMessage, 22);
            }
            else
            {
                LogException(argMessage, 21);
            }
        }

        public static string LogException(string argMessage, Int32 argErrCategory)
        {
            return CustomHandleErrorAttribute.RaiseErrorSignal(
               new ErrorLog()
               {
                   //UserName = this.CurrentUser.Name,
                   Details = argMessage,
                   ErrorID = argErrCategory,
                   Errored = DateTime.Now
               });
        }

        public static APIResponse MakePOSTRequest<T>(T objPost, string url)
        {
            var request = (HttpWebRequest)System.Net.WebRequest.Create(url);

            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";

            var PostData = JsonConvert.SerializeObject(objPost);
            if (!string.IsNullOrEmpty(PostData))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = new APIResponse();

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response    
                responseValue.Success = response.StatusCode == HttpStatusCode.OK;
                responseValue.Message = response.StatusDescription;
                string result = response.GetData();
                responseValue.CaseId = result.Substring(result.IndexOf(':') + 1, (result.IndexOf('}')) - (result.IndexOf(':') + 1));

                return responseValue;
            }
        }

    }
}

