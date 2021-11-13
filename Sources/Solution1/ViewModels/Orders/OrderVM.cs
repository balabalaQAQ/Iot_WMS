using EntityModel.Order;
using EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Orders
{
     public class OrderVM : EntityViewModel
    {
        [Display(Name = "订单号")]
        [Required(ErrorMessage = "订单号是必须的")]
        public string OrderNum { get; set; }//订单号

        public float Price { get; set; } //单价

        public float TotalPrice { get; set; }//总价


        //   [Display(Name = "消费时间")]
        //    [Required(ErrorMessage = "操作时间是必须的")]
        public string SetTime { get; set; }//订单申请时间

        //  [Display(Name = "订单状态")]
        //   [Required(ErrorMessage = "订单状态是必须的")]

        public Status Status { get; set; }//订单状态


        //public User Director { get; set; }

        // [Display(Name = "负责人")]
        //   [Required(ErrorMessage = "负责人是必须的")]
        //   public Guid DirectorId { get; set; }//负责人
        //   public Guid ReviewerId { get; set; }//审核人

        //   public   Role Reviewer { get; set; }
    }
}
