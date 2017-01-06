
using ERP.Attribute;
using ERP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Json.Client
{
    public class JsonClient
    {
        #region private data fields

        private string _contentType = string.Empty;

        private string _endPoint = string.Empty;

        private HttpVerb _method = HttpVerb.GET;

        private string _postData = string.Empty;

        #endregion

        #region constructors

        private JsonClient(string endPoint, string contentType)
        {
            _endPoint = endPoint;
            _method = HttpVerb.GET;
            _contentType = contentType;
            _postData = "";
        }

        public JsonClient(string endpoint, HttpVerb method = HttpVerb.GET, string contentType = "application/json")
            : this(endpoint, contentType)
        {
            _method = method;
        }

        public JsonClient(string endpoint, string postData, HttpVerb method = HttpVerb.GET, string contentType = "application/json")
            : this(endpoint, contentType)
        {
            _method = method;
            _postData = postData;
        }

        #endregion

        #region Methods/Functions

        public string MakeRequest(string parameters = "")
        {
            var request = (HttpWebRequest)System.Net.WebRequest.Create(_endPoint + parameters);

            request.Method = _method.ToString();
            request.ContentLength = 0;
            request.ContentType = _contentType;

            if (!string.IsNullOrEmpty(_postData) && _method == HttpVerb.POST)
            {
                var bytes = Encoding.UTF8.GetBytes(_postData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var _responseData = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response
                _responseData = response.GetData();
                return _responseData;
            }
        }

        /// <summary>
        /// Method for restful service calling based on request/response types
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request object</param>
        /// <param name="parameters">Query string parameters which will append in endpoint before service call</param>
        /// <returns></returns>
        public TResponse MakeRequest<TRequest, TResponse>(TRequest request = default(TRequest), string parameters = "")
        {
            TResponse resultResponse = default(TResponse);
            try
            {
                if (request != null)
                    _postData = JsonConvert.SerializeObject(request);
                var resData = MakeRequest(parameters);
                resultResponse = JsonConvert.DeserializeObject<TResponse>(resData);
                return resultResponse;
            }
            catch (System.Net.WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                var responseValue = res.GetData();              
                var exception = new ApiException(ex.Message, ex);               
                try
                {
                    APIResponse result = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                    if (!string.IsNullOrEmpty(result.ErrorCode))
                    {
                        exception.ErrorId = Convert.ToInt32(result.ErrorCode);
                        exception.DcMessage = result.ErrorContent;
                    }
                }
                catch
                {
                    exception.DcMessage = ex.Message + ";" + responseValue;
                }              

                
throw exception;             
            }
            return resultResponse;
        }

        public TResponse MakeRequest<TResponse>(string parameters = "")
        {
            TResponse resultResponse = default(TResponse);
            try
            {

                _postData = string.Empty;
                var resData = MakeRequest(parameters);
                resultResponse = JsonConvert.DeserializeObject<TResponse>(resData);
                return resultResponse;
            }
            catch (System.Net.WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                var responseValue = res.GetData();
                var exception = new ApiException(ex.Message, ex);
                try
                {
                    APIResponse result = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(responseValue);
                    if (!string.IsNullOrEmpty(result.ErrorCode))
                    {
                        exception.ErrorId = Convert.ToInt32(result.ErrorCode);
                        exception.DcMessage = result.ErrorContent;
                    }
                }
                catch
                {
                    exception.DcMessage = ex.Message + ";" + responseValue;
                }

                throw exception;
            }
            
        }

        private void ConstructExceptionLogging(string argAction, string argErrorId, string argMessage)
        {
            if (!string.IsNullOrEmpty(argErrorId))
                LogException("Web_Api_Error:" + argErrorId + "______________" + argMessage, 22);
            else
                LogException(argMessage, 21);
        }

        private string LogException(string argMessage, Int32 argErrCategory)
        {
            return CustomHandleErrorAttribute.RaiseErrorSignal(
               new ErrorLog()
               {
                   Details = argMessage,
                   ErrorID = argErrCategory,
                   Errored = DateTime.Now
               });
        }

        #endregion
    }
}
