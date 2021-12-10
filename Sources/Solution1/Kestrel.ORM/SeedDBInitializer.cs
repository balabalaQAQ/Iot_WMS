using EntityModel.Product;
using EntityModel.RawMaterials;
using EntityModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Kestrel.ORM
{
    public static class SeedDBInitializer
    {

        public static void Seed(this ModelBuilder context)//种子数据
        {
            #region 角色
            var Roid = Guid.NewGuid();
            context.Entity<IRole>().HasData(//添加基础角色
                 new IRole { Id = Roid, Name = "Admin", Description = "管理员：拥有用户管理、原料采购管理、产品出入库管理权限", DepartmentName = "管理员", DisplayName = "Adimn" },
                 new IRole { Id = Guid.NewGuid(), Name = "PurchasingDepartment", Description = "采购部门：拥有个人信息管理、原料采购信息管理权限。", DepartmentName = "采购部门", DisplayName = "Purchase" },
                 new IRole { Id = Guid.NewGuid(), Name = "ProductionDepartment", Description = "生产部门：拥有个人信息管理、原料领取管理、生产货物信息管理、产品入库管理权限", DepartmentName = "生产部门", DisplayName = "Production" },
                 new IRole { Id = Guid.NewGuid(), Name = "SaleDepartment", Description = "销售部门：拥有个人信息管理、产品入库管理权限", DepartmentName = "销售部门", DisplayName = "Sale" }
            );
            #endregion

            #region 管理员  
            context.Entity<IUser>().HasData(//添加Admin管理员
                new IUser
                {    
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    EmployeeNumber = "Admin",
                    Password = "123456",
                    RoleId = Roid
                }
             );
            #endregion

            #region 产品类型 
            var PCategoryid = Guid.NewGuid();
            context.Entity<PCategory>().HasData(//添加一般产品类型
              new PCategory { Id = PCategoryid, Name = "智能家居系列-Iot设备", DisplayName = "Iot设备", CategoryNum = "ZNJJ-001", Description = "新一代智能家居系列" },
              new PCategory { Id = Guid.NewGuid(), Name = "微量级系列-Iot芯片", DisplayName = "Iot芯片", CategoryNum = "WL-001", Description = "新一代微量级系列" }

            );
            #endregion
            #region 产品信息
           
            context.Entity<ProductInfo>().HasData(//添加一般产品类型
              new ProductInfo { Id = Guid.NewGuid(), Name="demo",Inventory = 0 , Price =0.0 }
            );
            #endregion

            #region 原料信息
            context.Entity<MaterialsInfo>().HasData(//添加原料信息demo
              new MaterialsInfo { Id = Guid.NewGuid(), Name = "Stm32微型集成MCU（附带WIFI模块）-STM32F3206"  },
              new MaterialsInfo { Id = Guid.NewGuid(), Name = "映射模块-TC01"}
             );
            #endregion

            #region 原料类型
            context.Entity<MCategory>().HasData(//添加一般原料类型
              new MCategory { Id = Guid.NewGuid(), Name = "Stm32微型集成MCU（附带WIFI模块）-STM32F3206", DisplayName = "STM32", CategoryNum = "STM-32F", Description = "Stm32微型集成MCU" },
              new MCategory { Id = Guid.NewGuid(), Name = "映射模块-TC01", DisplayName = "映射模块", CategoryNum = "TC01", Description = "映射模块-TC01" }
             );
            #endregion
        }
    }
}

