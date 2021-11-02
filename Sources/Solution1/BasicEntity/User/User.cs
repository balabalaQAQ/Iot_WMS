using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEntity
{
    public class User :IdentityUser<Guid>, IEntity
    {
        [StringLength(500)]
        public string Name { get; set; }  // 昵称
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(200)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        public string Image { get; set; }  //头像

        public virtual Role Role { get; set; }

        public virtual MembershipCard Card { get; set; }//会员卡

        public virtual Record Record { get; set; }//消费记录

    }
}
