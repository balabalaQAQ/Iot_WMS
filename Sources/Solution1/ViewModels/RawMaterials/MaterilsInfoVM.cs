using EntityModel.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.RawMaterials
{
    public class MaterilsInfoVM : EntityViewModel
    {
        [Display(Name = "原料类别")]
        [Required(ErrorMessage = "原料类别是必须的")]
        public string MCategory { get; set; } //原料类别

        [Display(Name = "库存量")]
        [Required(ErrorMessage = "库存量是必须的")]

        public int Inventory { get; set; }//库存量

        public virtual Order Order { get; set; }//所属订单
        public   Guid OrderId { get; set; }//所属订单Id
    }
}
