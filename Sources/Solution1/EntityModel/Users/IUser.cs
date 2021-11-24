using EntityModel.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Users
{
    public class IUser : IEntity
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }  // 昵称
        [StringLength(500)]
        public string Description { get; set; }//说明
        [StringLength(200)]
        public string SortCode { get; set; }//排序码
        public bool IsPseudoDelete { get; set; }//伪删除

        public bool Sex { get; set; }//性别

        public string Post { get; set; }//职务


        public virtual IRole Role { get; set; }//角色
        public IUser() : base()
        {
            this.Id = Guid.NewGuid();
        } 
    }
}
