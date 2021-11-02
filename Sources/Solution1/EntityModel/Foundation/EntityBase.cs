using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.Foundation
{
    /// <summary>
    /// 接口 IEntityBase 的实现
    /// </summary>
    public abstract class EntityBase:IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
