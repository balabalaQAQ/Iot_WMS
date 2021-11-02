﻿using EntityModel.Foundation;
using EntityModel.OR;
using EntityModel.Tools;
using EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Product
{
    public class PRecord : IEntity//产品操作记录
    {
         
        public Guid Id { get; set; }

        public string Name { get; set; }   // 记录名
        public string Description { get; set; }//操作说明

        public string SetTime { get; set; }//操作时间

        public virtual User User { get; set; }//操作人

        public SetType setType { get; set; }//操作类型

        public int SetNum { get; set; }//操作数量

        public virtual ProductInfo MaterialsInfo { get; set; } //原料信息
        [StringLength(200)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; } = false;//无需删除
        public PRecord()
        {
            this.Id = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<String>();
        }
    }
}