using EntityModel.Orders;
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

        public string SetTime { get; set; }//操作时间

        public Status Status { get; set; } = 0;//订单状态
        public float Price { get; set; }//单价

        public int Number { get; set; }//数量

        public float TotalPrice { get; set; }//总价

        public string Director { get; set; }//负责人
        public string Reviewer { get; set; }//审核人
    }
}
