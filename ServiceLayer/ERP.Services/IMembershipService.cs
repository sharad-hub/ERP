
using ERP.Entities;
using ERP.Services.Utilities;
using System;
using System.Collections.Generic;
namespace ERP.Services
{
    public interface IMembershipService
    {
        User CreateUser(User user, string password, int[] roles);
        User CreateUserByManager(User user, string password, string CreatedByUserEmail);
        User GetUser(int userId);

        IEnumerable<User> GetUsersByManageEmail(string emailID);
        User GetUsersByEmail(string emailID);
        System.Collections.Generic.List<UserRight> GetUserRoles(string username);
        MembershipContext ValidateUser(string username, string password);
    }
}
