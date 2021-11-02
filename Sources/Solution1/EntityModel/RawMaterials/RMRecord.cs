using EntityModel.Foundation;
using EntityModel.Tools;
using EntityModel.Users;
using EntityModel.OR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.RawMaterials
{
    public class RMRecord : IEntity//原料记录
    {
        public Guid Id { get; set; }

        public string Name { get; set; }   // 记录名
        public string Description { get; set; }//操作说明

        public string SetTime { get; set; }//操作时间

        public virtual User User { get; set; }//操作人

        public SetType setType { get; set; }//操作类型

        public int SetNum { get; set; }//操作数量

        public virtual MaterialsInfo MaterialsInfo{get;set;} //原料信息
        [StringLength(200)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;//无需删除
        public RMRecord()
        {
            this.Id = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<String>();
        }
    }
}
