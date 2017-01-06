using System;
using System.Configuration; 
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using ERP.Models;

namespace ERP.APIWrappers
{
    public static class CommonWrapper
    {
        public static APIResponseError PostException<ErrorLog>(ErrorLog argError, string argToken)
        {
            return PostToAPIError<ErrorLog>(argError, string.Format("{0}Common/WriteError", ControllersWrapper.BASE_URL), "POST", argToken);
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


        #region User
        //Login
        #endregion
    }
}