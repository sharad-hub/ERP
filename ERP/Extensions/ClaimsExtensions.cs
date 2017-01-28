using ERP.Entities;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace ERP.Extensions
{
    public static class ClaimsExtensions
    {
        static string GetUserEmail(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
        }

        public static string GetUserEmail(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserEmail(claimsIdentity) : "";
        }

        static string GetUserNameIdentifier(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
        }

        public static string GetUserNameIdentifier(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserNameIdentifier(claimsIdentity) : "";
        }
        static string GetUserNameID(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserID").Value;
        }

        public static string GetUserID(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserNameID(claimsIdentity) : "";
        }

        static string GetUserType(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserType").Value;
        }

        public static string GetUserType(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserType(claimsIdentity) : "";
        }
        static string GetUserDefaultUrl(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/DefaultUrl").Value;
        }

        public static string GetUserDefaultUrl(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserDefaultUrl(claimsIdentity) : "";
        }
        static string GetUserThemeSkin(this ClaimsIdentity identity)
        {
            return identity.GetClaim( "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/ThemeSkin");           
        }

        public static string GetUserThemeSkin(this IIdentity identity)
        {
            var defaultTheme = ConfigurationManager.AppSettings["Default_Theme"] == null ? "" : ConfigurationManager.AppSettings["Default_Theme"];
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity != null ? GetUserThemeSkin(claimsIdentity) : defaultTheme;
        }
       public static   string GetUserReferenceID(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity.GetClaim(CustomClaimTypes.UserReferenceID);
        }
        public static string GetClaim(this ClaimsIdentity identity, string  claimype)
        {
            var claim= identity.Claims.Where(x => x.Type == claimype).FirstOrDefault();
            return claim != null ? claim.Value : string.Empty;
        }
    }
}