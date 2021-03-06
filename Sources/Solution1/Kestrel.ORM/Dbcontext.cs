using EntityModel.Orders;
using EntityModel.Product;
using EntityModel.RawMaterials;
using EntityModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
namespace Kestrel.ORM
{
    public class Dbcontext :DbContext
    {
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)//重写并调用自定义种子类
        {
            builder.Seed();
        }

        #region 用户角色实体
        public DbSet<IUser> IUser { get; set; }//用户 
        public DbSet<IRole> IRole { get; set; }//用户角色

        #endregion

        #region 产品
        public DbSet<ProductInfo> ProductInfo { get;set;}//产品信息
        public DbSet<PCategory> PCategory { get; set; }//产品类别
        public DbSet<PRecord> PRecord { get; set; }//操作记录
        #endregion

        #region 原料
        public DbSet<MaterialsInfo> MaterialsInfo { get; set; }//原料信息
        public DbSet<MCategory> MCategory { get; set; }//原料类别
        public DbSet<RMRecord> RMRecord { get; set; }//操作记录
        #endregion

        #region 订单
        public DbSet<Order> Order { get; set; }//订单详情
        #endregion
    }
}