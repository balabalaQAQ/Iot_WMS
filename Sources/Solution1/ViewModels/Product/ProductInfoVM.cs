using EntityModel.Orders;
using EntityModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Product
{
 
   public class ProductInfoVM : EntityViewModel   //产品信息
    {
 

        [Display(Name = "库存量")]
        [Required(ErrorMessage = "库存量是必须的")]
        public int Inventory { get; set; }//库存量

        public string ProductID { get; set; } // 产品编号


        public double Price { get; set; }//单价
        public virtual PCategory PCategory { get; set; } //产品类别

        public List<PCategory> PCategoryList { get; set; }

       
    }
}
