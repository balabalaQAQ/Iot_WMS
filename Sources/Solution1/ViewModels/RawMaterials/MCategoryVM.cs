using EntityModel.RawMaterials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.RawMaterials
{
    public class MCategoryVM : EntityViewModel
    {
    

        public string MaterialsID { get; set; } //原料编号

        public MCategory MCategory { get; set; } //原料类别

        public int Inventory { get; set; }//库存量

    }
}
