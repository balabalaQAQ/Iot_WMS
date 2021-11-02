﻿using Kestrel.ViewModels.ControlModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModels;

namespace Kestrel.ViewModels.ApplicationCommon.RoleAndUser
{
    public class ApplicationUserVM : EntityViewModel
    {
        [Display(Name = "显示名")]
        [Required(ErrorMessage = "显示名不能为空值。")]
        public override string  Name { get; set; }

        [Required(ErrorMessage = "用户名不能为空值。")]
        [Display(Name = "用户名")]
        [StringLength(100, ErrorMessage = "你输入的数据超出限制100个字符的长度。")]
        public string UserName { get; set; }

        [Display(Name = "登录邮件")]
        [Required(ErrorMessage = "电子邮件数据是必须的。")]
        [EmailAddress(ErrorMessage = "请输入合法的电子邮件地址。")]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码是必须的。")]
        [RegularExpression(@"((^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,})$)", ErrorMessage = "密码至少8个字符，至少1个小写字母，一个大写字母，1个数字和1个特殊字符！")]
        public string Password { get; set; }

        [Display(Name = "重复密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "重复密码与密码必须一致")]
        public string PasswordComfirm { get; set; }

        [Display(Name = "锁定")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "宿主角色组")]
        public string MasterRoleId { get; set; }           
        [Display(Name = "宿主角色组")]
        public string MasterRoleName { get; set; }  
        public List<SelfReferentialItem> MasterRoleItemCollection { get; set; }

        [Display(Name = "从属角色组")]
        public string[] ApplicationRoleId { get; set; }                              // 角色组 Id 数组
        [Display(Name = "从属角色组")]
        public string[] ApplicationRoleName { get; set; }                            // 角色组名称集合
        public List<SelfReferentialItem> ApplicationRoleItemCollection { get; set; } // 待选角色组 
    }
}
