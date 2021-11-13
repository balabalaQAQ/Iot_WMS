using EntityModel.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Product
{
    public class PCategory : IEntity//产品类型
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  //产品类型名

        public string DisplayName { get; set; }  //产品类型简称
        public string CategoryNum { get; set; } //类型编号
        public string Description { get; set; }//产品类型说明
        public string SortCode { get; set; } 
        public bool IsPseudoDelete { get; set; }

        public PCategory()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
