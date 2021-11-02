using EntityModel.OR;
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
        [Display(Name = "操作时间简称")]
        [Required(ErrorMessage = "操作时间是必须的")]
        public string SetTime { get; set; }//操作时间

        public virtual Guid UserId { get; set; }//操作人Id


        [Display(Name = "操作类型简称")]
        [Required(ErrorMessage = "操作类型是必须的")]
        public SetType setType { get; set; }//操作类型

        [Display(Name = "操作数量简称")]
        [Required(ErrorMessage = "操作数量是必须的")]
        public int SetNum { get; set; }//操作数量

        public virtual MaterialsInfo MaterialsInfo { get; set; } //原料信息

        public virtual Guid MaterialsInfoId { get; set; } //原料信息Id
    }
}
