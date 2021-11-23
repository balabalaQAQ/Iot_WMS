
using EntityModel.Foundation;
using EntityModel.Orders;
using EntityModel.Tools;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Product
{
    public class ProductInfo : IEntity   // 产品信息
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // 产品名
        public string ProductID { get; set; } // 产品编号

        public virtual PCategory PCategory { get; set; } //产品类别

        public string Description { get; set; }//产品描述

        public int Inventory { get; set; }//库存量

        public double Price { get; set; }//单价

        public virtual Order Order { get;set;}//所属订单

 
        [StringLength(200)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;
        public ProductInfo()
        {
            this.Id = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<String>();
        }

    }
}
