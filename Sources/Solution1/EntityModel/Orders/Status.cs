using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityModel.Order
{

   
    public enum Status
    {
        待审核=0,
        审核成功,
        审核失败,
        已取消,
        已完成

    }
}
