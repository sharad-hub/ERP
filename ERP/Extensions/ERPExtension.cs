using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ERP.Extensions
{
    public static class ERPExtension
    {
        //public static DcLife.Services.WebServiceObjects.Security.DcOnlineIdentity CurrentUser(this object obj)
        //{
        //    return HttpContext.Current.User.Identity as DcLife.Services.WebServiceObjects.Security.DcOnlineIdentity;
        //}

        public static IIdentity CurrentUser(this object obj)
        {
            return HttpContext.Current.User.Identity;
        }

        public static bool IsGuestUser(this object obj)
        {
            return HttpContext.Current.User.IsInRole("GuestUser");
        }

        public static string FullUserName(this object obj)
        {
            if (HttpContext.Current.Session["fullUName"] != null)
                return (string)HttpContext.Current.Session["fullUName"];
            return string.Empty;
        }

        public static bool IsERPAdmin(this object obj)
        {
            return HttpContext.Current.User.IsInRole("Administrator");
        }      

        public static string GetFormattedDate(this object obj, DateTime date)
        {
            return string.Format("{0} {1}{2} {3}, {4}",
                date.ToString("dddd"),
                date.Day,
                Ordinal(date.Day),
                date.ToString("MMM"),
                date.ToString("yyyy"));
        }

        public static string GetFormattedDate(this DateTime date)
        {
            return string.Format("{0} {1}{2} {3}, {4} {5}",
                date.ToString("dddd"),
                date.Day,
                Ordinal(date.Day),
                date.ToString("MMM"),
                date.ToString("yyyy"),
                date.ToString("hh:mm"));
        }

        //public static string Encrypt(this object obj, string text)
        //{
        //    return  stre  DCOnline.Security.Crypto.Encrypt(text);
        //}

        //public static string UrlWithEncryt(this UrlHelper uHelper, string url, string qString)
        //{
        //    return string.Format("{0}?enc={1}", url, Encrypt(uHelper, qString));
        //}

        //public static string UrlWithEncryt(this UrlHelper uHelper, string actionName, string controllerName, string qString)
        //{
        //    var url = uHelper.Action(actionName, controllerName);
        //    return string.Format("{0}?enc={1}", url, Encrypt(uHelper, qString));
        //}

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

        /// <summary>
        /// Convert date string from DD/MM/YYYY to YYYY/MM/DD
        /// </summary>
        /// <param name="dStr"></param>
        /// <returns></returns>
        public static string DbDateFormat(this string dStr)
        {
            var _completedDate = dStr;
            var cDate = default(DateTime);
            if (DateTime.TryParse(_completedDate, new CultureInfo("en-GB"), DateTimeStyles.AdjustToUniversal, out cDate))
                _completedDate = cDate.ToString("yyyy-MM-dd");
            return _completedDate;
        }

        public static string DateUIFormat(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
        }

        public static string CurrentVersion(this object obj)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string version = assembly.GetName().Version.ToString();
            return version;
        }
    }
}