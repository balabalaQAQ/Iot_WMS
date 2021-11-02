using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Product
{
    public class PCategoryVM : EntityViewModel
    {

        [Display(Name = "产品简称")]
        [Required(ErrorMessage = "产品简称是必须的")]
        public string DisplayName { get; set; }  //产品简称
        public string CategoryNum { get; set; } //类型编号
    }
}
