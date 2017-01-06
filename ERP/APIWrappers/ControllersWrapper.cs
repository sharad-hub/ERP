using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;
using Json.Client;
using ERP.Models;

namespace ERP.APIWrappers
{
    public static class ControllersWrapper
    {
        public static string BASE_URL = ConfigurationManager.AppSettings["BASE_URL"];

        public static TResponse Get<TRequest, TResponse>(string url, TRequest request = default(TRequest), string argToken = "")
        {
            var client = new JsonClient(url);
            return client.MakeRequest<TRequest, TResponse>();
        }

        public static TResponse Post<TRequest, TResponse>(TRequest request, string url, string argToken = "")
        {
            var client = new JsonClient(url, HttpVerb.POST);
            return client.MakeRequest<TRequest, TResponse>(request, argToken);
        }
     
        public static TResponse Post<TResponse>(string url, string argToken = "")
        {
            var client = new JsonClient(url, HttpVerb.POST);
            return client.MakeRequest<TResponse>(argToken);
        }

        /// <summary>
        /// Converts the object into xml document.
        /// </summary>
        /// <param name="argObj">object</param>
        /// <returns>string</returns>
        public static string ConstructXml(object argObj)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
            // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(argObj.GetType());

            try
            {
                // Creates a stream whose backing store is memory. 
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, argObj);
                    xmlStream.Position = 0;
                    //Loads the XML document from the specified string.
                    xmlDoc.Load(xmlStream);
                    return xmlDoc.InnerXml;
                }
            }
            finally
            {
                xmlDoc = null;
                xmlSerializer = null;
            }
        }

        private static string Ordinal(int num)
        {
            var suff = "th";
            var ones = num % 10;
            var tens = Math.Floor((double)num / 10) % 10;
            if (tens == 1)
            {
                suff = "th";
            }
            else
            {
                switch (ones)
                {
                    case 1: suff = "st"; break;
                    case 2: suff = "nd"; break;
                    case 3: suff = "rd"; break;
                }
            }
            return suff;
        }
        #region User 
        public static HttpResponseMessage Authenticate(LoginViewModel user, string argToken)
        {
            var _url = string.Format("{0}api/AccountApi/authenticate", BASE_URL);
            return Post<LoginViewModel, HttpResponseMessage>(user, _url);
            //return APIHelper.PostToAPI<requestExam>(argRequestExam, string.Format("{0}Validation/CaseCreate/step1", ConfigurationManager.AppSettings["BASE_URL"]), "POST", argToken);
        }
        #endregion
    }
}