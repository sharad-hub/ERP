 
using ERP.Entities;
using ERP.Services.Utilities;
using System;
namespace ERP.Services
{
   public interface IMembershipService
    {
         User CreateUser(User  user,string password, int[] roles);
         User GetUser(int userId);
         System.Collections.Generic.List<UserRight> GetUserRoles(string username);
        MembershipContext ValidateUser(string username, string password);
    }
}
