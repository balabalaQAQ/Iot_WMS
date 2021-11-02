using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.User
{
    public class RoleVM : EntityViewModel
    {
        [Display(Name = "部门名")]
        [Required(ErrorMessage = "部门名是必须的")]
        public string DepartmentName { get; set; }     
      

        public Guid Roleid { get; set; }

        public string RoleName { get; set; }

        Dictionary<int, string> states = new Dictionary<int, string> { };

       
    }
}
