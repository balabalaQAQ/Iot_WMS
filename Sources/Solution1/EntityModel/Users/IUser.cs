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
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;//伪删除，用户不可以提交删除申请，只能启用锁定状态

        public bool Sex { get; set; }//性别

        public int Phone { get; set; }//电话

        public string EmployeeNumber { get; set; }//职工号

        public string Password { get; set; }//密码

        public string HeadPortrait { get; set; }//头像
        public string Post { get; set; }//职务

        public string NativePlace{get;set; }//籍贯

        public string IdentityCardNumber { get; set; }//身份证号
        public string Address { get; set; }//地址
        public virtual string Email { get; set; }//邮箱

        public Guid RoleId { get; set; }
        public virtual IRole Role { get; set; }//角色
        public virtual int AccessFailedCount { get; set; }//访问失败计数

        public virtual bool IsLockoutEnabled { get; set; }//锁定状态是否启用
        public IUser() : base()
        {
            this.Id = Guid.NewGuid();
        } 
    }
}
