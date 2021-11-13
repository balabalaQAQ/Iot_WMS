
using EntityModel.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapidemo.Model;

namespace weiapidemo.Provider
{
    public class UserFake:UserIO
    {
        UserListModel VM;
      
        public UserListModel GetForecasts() 
        {
            return VM;
        }

        private  void _Initialize(UserContext context)
        {
            VM = new UserListModel();
            VM.User = context.Users.Include("Role").ToList();
    
            VM.Role = context.Roles.ToList();
            VM.Statuses = new List<string>();
           
            for (int i = 0; i < 3; i++)
            {
                VM.Statuses.Add(((Status)i).ToString());
                Role role = new Role();
                role.Id = Guid.NewGuid();
                role.RoleName = "角色" + i;
                VM.Role.Add(role);
            }
         
        }
        public   UserFake(UserContext context) 
        {
            _Initialize(context);
        }

    }
}
