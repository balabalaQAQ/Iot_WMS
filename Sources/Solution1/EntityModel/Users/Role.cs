using EntityModel.Foundation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Users
{
    public class Role : IdentityRole<Guid>, IEntity
    {
       
        [StringLength(500)]
        public string Description { get; set; }     // 描述
        [StringLength(500)]
        public string DepartmentName { get; set; }     // 部门名
        [StringLength(200)]
        public string SortCode { get; set; }        // 角色编码
        [StringLength(200)]
        public string DisplayName { get; set; }    //用于显示的名字

        public bool IsPseudoDelete { get; set; }    //伪删除
       
        public Role() : base()
        {
            this.Id = Guid.NewGuid();
        }


    }
}
