using System.Web.Script.Serialization;

namespace System
{
    public static class JsonHelper
    {
        public static string ToJSON(this object obj)
        {
            var rtnVal = string.Empty;
            try
            {
                rtnVal = new JavaScriptSerializer().Serialize(obj);
            }
            catch (Exception ex)
            {
                rtnVal = ex.Message;
            }
            return rtnVal;
        }

        public static T DeserializeJSONString<T>(this string obj)
        {
            T rtnVal = default(T);
            try
            {
                rtnVal = new JavaScriptSerializer().Deserialize<T>(obj);
            }
            catch (Exception)
            {
            }
            return rtnVal;
        }

        public static dynamic DeserializeJSONString(this string obj)
        {
            dynamic rtnVal = default(dynamic);
            try
            {
                rtnVal = new JavaScriptSerializer().Deserialize<dynamic>(obj);
            }
            catch (Exception)
            {
            }
            return rtnVal;
        }
    }
}
