﻿using EntityModel.Order;
using EntityModel.Product;
using EntityModel.RawMaterials;
using EntityModel.Users;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using Kestrel.ViewModelServices.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Product;
using ViewModels.RawMaterials;

namespace Kestrel.ViewModelServices
{
 
    //所有子数据添加函数都通过这里添加
    public static class SubdataWithViewModelService
    {
        //原料信息，子数据：订单
        public static async Task<SaveStatusModel> SaveMaterialsWithOrder(this IWebAPIModelService<MaterialsInfo, MaterilsInfoVM> service, MaterilsInfoVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
            if (bo == null) { bo = new MaterialsInfo(); }

            boVM.MapToEntityModel(bo);
            if (boVM.Id.ToString() != null)
            {
                var id = boVM.Order.Id;
                var item = await service.EntityRepository.GetOtherBoAsyn<Order>(id);
                bo.Order = item;
            }
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }
        //产品信息，子数据：订单 、产品类型
        public static async Task<SaveStatusModel> SaveProductInfoWithOrderAndPCategory(this IWebAPIModelService<ProductInfo, ProductInfoVM> service, ProductInfoVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
            if (bo == null) { bo = new ProductInfo(); }

            boVM.MapToEntityModel(bo);
            if (boVM.Id.ToString() != null)
            {
                var Orderid = boVM.Order.Id;
                var Orderitem = await service.EntityRepository.GetOtherBoAsyn<Order>(Orderid);
                bo.Order = Orderitem;
                var PCategoryid = boVM.PCategory.Id;
                var PCategoryitem = await service.EntityRepository.GetOtherBoAsyn<PCategory>(PCategoryid);
                bo.PCategory = PCategoryitem;
            }
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }
        //产品操作记录，子数据：用户 、所属产品信息
        public static async Task<SaveStatusModel> SavePRecordWithUserandProductInfo(this IWebAPIModelService<PRecord, PRecordVM> service, PRecordVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
            if (bo == null) { bo = new PRecord(); }

            boVM.MapToEntityModel(bo);
            if (boVM.Id.ToString() != null)
            {
                var Userid = boVM.Userid;
                var Useritem = await service.EntityRepository.GetOtherBoAsyn<User>(Userid);
                bo.User = Useritem;
                var ProductInfoid = boVM.ProductInfo.Id;
                var ProductInfoitem = await service.EntityRepository.GetOtherBoAsyn<ProductInfo>(ProductInfoid);
                bo.ProductInfo = ProductInfoitem;
            }
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }
    }
}
