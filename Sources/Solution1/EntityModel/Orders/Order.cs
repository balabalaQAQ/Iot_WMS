using EntityModel.Foundation;
using EntityModel.Tools;
using EntityModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Order
{
    public class Order : IEntity//订单
    {
        public Guid Id { get; set; }

        public string OrderNum { get; set; }//订单号

        public string Name { get; set; }   // 订单名
        public string Description { get; set; }//订单描述

        public string SetTime { get; set; }//操作时间

        public Status Status { get; set; } = 0;//订单状态
        public float Price { get; set; } = 0;//单价

        public float TotalPrice { get; set; }//总价

        public virtual User Director { get; set; }//负责人
        public virtual User Reviewer { get; set; }//审核人
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;//无需删除

        public Order()
        {
            this.Id = Guid.NewGuid();
         //   this.SortCode ;
            this.SetTime = DateTime.Now.ToString();
        }

    }
}
