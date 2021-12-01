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


        public string DisplayName { get; set; }  //原料类型简称
        public string CategoryNum { get; set; } //类型编号

    }
}
