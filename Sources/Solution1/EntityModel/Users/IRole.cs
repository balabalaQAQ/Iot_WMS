using EntityModel.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Users
{
   public class IRole:IEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }     // 描述
        [StringLength(500)]
        public string DepartmentName { get; set; }     // 部门名
        [StringLength(200)]
        public string SortCode { get; set; }        // 角色编码
        [StringLength(200)]
        public string DisplayName { get; set; }    //用于显示的名字

        public bool IsPseudoDelete { get; set; }    //伪删除

        public IRole() : base()
        {
            this.Id = Guid.NewGuid();
        }

    
    }
}
