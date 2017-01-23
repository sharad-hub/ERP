using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entities
{
  public class Constants
    {
     public const string PasswordKey = "Password";
    }

  public enum Keys
  {
      Password,
      URL,
      SkinTheme,

  }


     // Summary:
    //     Defines constants for the well-known claim types that can be assigned to
    //     a subject. This class cannot be inherited.
    //[ComVisible(false)]
  public static class CustomClaimTypes
  {
      public const string UserID = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserID";
      public const string UserType = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserType";
      public const string DefaultUrl = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/DefaultUrl";
      public const string ThemeSkin = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/ThemeSkin";
      public const string UserReferenceID = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserReferenceID";   
  }
}
