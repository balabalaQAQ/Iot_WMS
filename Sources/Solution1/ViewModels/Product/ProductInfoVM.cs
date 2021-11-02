using EntityModel.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Product
{
   public class ProductInfoVM : EntityViewModel
    {
        [Display(Name = "产品类别")]
        [Required(ErrorMessage = "产品类别是必须的")]
        public string PCategory { get; set; } //产品类别

        [Display(Name = "库存量")]
        [Required(ErrorMessage = "库存量是必须的")]
        public int Inventory { get; set; }//库存量

        public virtual Order Order { get; set; }//所属订单

        public Guid   OrderId { get; set; }//所属订单ID
    }
}
