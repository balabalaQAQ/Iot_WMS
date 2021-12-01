using EntityModel.Orders;
using EntityModel.Product;
using EntityModel.RawMaterials;
using EntityModel.Users;
using Kestrel.DataAccess;
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
 
       
        /// <summary>
        ///  产品信息，子数据： 产品类型
        /// </summary>

        public static async Task<SaveStatusModel> SaveProductInfoWithPCategory(this IWebAPIModelService<ProductInfo, ProductInfoVM> service, ProductInfoVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
            if (bo == null) { bo = new ProductInfo(); }

            boVM.MapToEntityModel(bo);
            if (boVM.Id.ToString() != null)
            {
                var PCategoryid = boVM.PCategory.Id;
                var PCategoryitem = await service.EntityRepository.GetOtherBoAsyn<PCategory>(PCategoryid);
                bo.PCategory = PCategoryitem;
            }
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }

        /// <summary>
        ///  原料信息，子数据： 原料类型
        /// </summary>
        public static async Task<SaveStatusModel> SaveMaterialsInfoWithMCategory(this IWebAPIModelService<MaterialsInfo, MaterialsInfoVM> service, MaterialsInfoVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
            if (bo == null) { bo = new MaterialsInfo(); }

            boVM.MapToEntityModel(bo);
            if (boVM.Id.ToString() != null)
            {
                var MCategoryid = boVM.MCategory.Id;
                var MCategoryitem = await service.EntityRepository.GetOtherBoAsyn<MCategory>(MCategoryid);
                bo.MCategory = MCategoryitem;
            }
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }
        
        /// <summary>
        ///  产品操作记录，子数据：所属产品信息
        /// </summary>

        public static async Task<SaveStatusModel> SavePRecordWithProductInfo(this IWebAPIModelService<PRecord, PRecordVM> service, PRecordVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
       
            if (bo == null) { bo = new PRecord(); }
 
            boVM.MapToEntityModel(bo);

        
            if (boVM.Id.ToString() != null)
            {
              var ProductInfoid = boVM.ProductInfo.Id;
              var ProductInfoitem = await service.EntityRepository.GetOtherBoAsyn<ProductInfo>(ProductInfoid);
           
              bo.ProductInfo = ProductInfoitem;
               
            }
            bo.SetTime = DateTime.Now.ToString();
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }

        /// <summary>
        ///  原料操作记录，子数据： 所属原料信息, 所属订单
        /// </summary>

        public static async Task<SaveStatusModel> SaveRMRecordWithOrderandMaterialsInfo(this IWebAPIModelService<RMRecord, RMRecordVM> service, RMRecordVM boVM)
        {

            SaveStatusModel saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);

            if (bo == null) { bo = new RMRecord(); }

            boVM.MapToEntityModel(bo);


            if (boVM.Id.ToString() != null)
            {
                var MaterialsInfoid = boVM.MaterialsInfo.Id;
                var MaterialsInfoitem = await service.EntityRepository.GetOtherBoAsyn<MaterialsInfo>(MaterialsInfoid);
                bo.MaterialsInfo = MaterialsInfoitem;

                var Orderid = boVM.Order.Id;
                var Orderitem = await service.EntityRepository.GetOtherBoAsyn<Order>(Orderid);
                bo.Order = Orderitem;
            }
            bo.SetTime = DateTime.Now.ToString();
            saveStatus = await service.EntityRepository.SaveBoAsyn(bo);
            return saveStatus;
        }
        
    }
}
