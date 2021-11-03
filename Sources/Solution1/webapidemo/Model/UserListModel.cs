
using EntityModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapidemo.Model
{
    public class UserListModel
    {
        public List<User> User { get; set; }
        public List<String> Statuses { get; set; }
        public List<Role> Role { get; set; }
    }
}
