using EntityModel.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.RawMaterials
{
    public class MCategory : IEntity//原料类型
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  //原料类型名

        public string DisplayName { get; set; }  //原料类型简称
        public string CategoryNum { get; set; } //类型编号
        public string Description { get; set; }//原料类型说明
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        public MCategory()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
