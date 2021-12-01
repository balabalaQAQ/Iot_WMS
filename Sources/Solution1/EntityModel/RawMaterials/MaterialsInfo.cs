using EntityModel.Foundation;
using EntityModel.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Orders;

namespace EntityModel.RawMaterials
{
    public class MaterialsInfo : IEntity   // 原料信息
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //原料名

        public string MaterialsID { get; set; } //原料编号

        public Guid MCategoryId { get; set; }  
        public MCategory MCategory { get; set; } //原料类别

        public string Description { get; set; }//描述

        public int Inventory { get; set; }//库存量

        [StringLength(200)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;

        public MaterialsInfo()
        {
            this.Id = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<String>();
        }


    }
}
