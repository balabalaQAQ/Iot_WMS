using EntityModel.OR;
using EntityModel.Product;
using EntityModel.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Product
{
    public class PRecordVM : EntityViewModel
    {
        //[Display(Name = "操作时间")]
      //  [Required(ErrorMessage = "操作时间是必须的")]
       public string SetTime { get; set; }//操作时间

 
       public string SetUserName { get; set; }//操作人名称

        public SetType setType { get; set; }//操作类型

        [Display(Name = "操作数量")]
        [Required(ErrorMessage = "操作数量是必须的")]
        public int SetNum { get; set; }//操作数量

        public double TotalPrice { get; set; }//总价
        public virtual ProductInfo ProductInfo { get; set; } //原料信息

        
    }
}
