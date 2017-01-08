

using ERP.Data.Models;
using ERP.Entities;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository
{
    
    public static class UserRepository
    {
        public static User GetUserByUsername(this IRepository<User> userRepository, string username)
        {
            return userRepository.Queryable().FirstOrDefault(x => x.Username == username);
        }
        public static User GetSingle(this IRepository<User> userRepository, int userId)
        {
            return userRepository.Queryable().FirstOrDefault(x => x.UserID == userId);
        }
        
        public static Role GetSingle(this IRepository<Role> repository, int roleId)
        {
            return repository.Queryable().FirstOrDefault(x => x.ID == roleId);
        }
        //public static UserRole GetUserRoleByUserId(this IRepository<UserRole> repository, int id)
        //{
        //    return repository.Queryable().FirstOrDefault(x => x.UserId == id);           
        //} 
    }
}
