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
    public class MaterialsInfoVM : EntityViewModel
    {
        public Guid MCategoryId { get; set; }
        public MCategory MCategory { get; set; } //原料类别

        [Display(Name = "库存量")]
        [Required(ErrorMessage = "库存量是必须的")]

        public int Inventory { get; set; }//库存量
        public List<MCategory> MCategoryList { get; set; }
    }
}
