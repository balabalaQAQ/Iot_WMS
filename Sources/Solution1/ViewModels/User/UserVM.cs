using EntityModel.Orders;
using EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.User
{
    public class UserVM : EntityViewModel
    {
        [Display(Name = "性别")]
        [Required(ErrorMessage = "性别是必须的")]
        public bool Sex { get; set; }

        [Display(Name = "职务")]
        [Required(ErrorMessage = "职务是必须的")]
        public string Post { get; set; }//职务

        public Role Role { get; set; }

        public Guid Roleid { get; set; }

        public string RoleName { get; set; }

        Dictionary<int, string> states = new Dictionary<int, string> { };

        public Status Status { get; set; }
    }
}
