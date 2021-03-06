using EntityModel.Foundation;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityModel.Users
{
    public class User : IdentityUser<Guid>, IEntity
    {
        [StringLength(100)]
        public string Name { get; set; }  // 昵称
        [StringLength(500)]
        public string Description { get; set; }//说明
        [StringLength(200)]
        public string SortCode { get; set; }//排序码
        public bool IsPseudoDelete { get; set; }//伪删除

        public bool Sex { get; set; }//性别

        public string Post { get; set; }//职务


        public virtual Role Role { get; set; }//角色

        
    }
}
