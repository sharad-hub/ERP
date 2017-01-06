using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System.Net
{
    public static class WebResponseHelper
    {
        public static string GetData(this WebResponse resp)
        {
            var respValue = string.Empty;
            if (resp != null)
                using (var responseStream = resp.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            respValue = reader.ReadToEnd();
                        }
                }
            return respValue;
        }

        public static string GetError(this WebException ex)
        {
            var rtnVal = string.Empty;
            if (ex.Response != null)
            {
                if (ex.Response.ContentType.ToLower() == "application/json")
                {
                    var data = ex.Response.GetData().DeserializeJSONString();
                }
                else
                    rtnVal = ex.Response.GetData();
            }
            else
                rtnVal = ex.Message;

            return rtnVal;
        }
    }
}