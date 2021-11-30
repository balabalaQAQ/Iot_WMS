using EntityModel.OR;
using EntityModel.Orders;
using EntityModel.RawMaterials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.RawMaterials
{
    public class RMRecordVM : EntityViewModel
    {
   
        public string SetTime { get; set; }//操作时间

        public string SetUserName { get; set; }//操作人名称

        public SetType setType { get; set; }//操作类型

        public virtual Order Order { get; set; }//所属订单

        public List<Order> OrderList { get; set; }//所有审核状态为完成的订单
        public int SetNum { get; set; }//操作数量

        public double TotalPrice { get; set; }//总价

        public virtual MaterialsInfo MaterialsInfo { get; set; } //原料信息
    }
}
