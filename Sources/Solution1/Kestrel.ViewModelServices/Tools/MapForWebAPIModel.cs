
using EntityModel.Orders;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Orders;

namespace Kestrel.ViewModelServices.Tools
{
    public static class MapForWebAPIModel
    {
        //public static async Task<SaveStatusModel> SaveCommodityForCreateOrEdit(this IWebAPIModelService<Commodity, CommodityVM> service, CommodityVM boVM)
        //{
        //    var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };

        //    // 根据视图模型的 Id 获取实体对象
        //    var bo = await service.EntityRepository.GetBoAsyn(boVM.Id);
        //    var isNew = false;

        //    if (bo == null)
        //    {
        //        bo = new Commodity();
        //        isNew = true;
        //    }

        //    // 将视图模型的数据映射到实体模型
        //    boVM.MapToEntityModel<CommodityVM, Commodity>(bo);
        //    if (isNew)
        //    {
        //        var result = await service.EntityRepository.EntitiesContext.AddAsync(bo);

        //    }

        //    else
        //    {
        //        //   await service.EntityRepository.EntitiesContext.Update(bo); 

        //    }
        //    return saveStatus;
        //}

        public static async Task<SaveStatusModel> SaveCommodityForCreateOrEdit(this IWebAPIModelService<Order, OrderVM> service, Order order)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };

            // 根据视图模型的 Id 获取实体对象
            var bo = await service.EntityRepository.GetBoAsyn(order.Id);
            var isNew = false;

            if (bo == null)
            {
                bo = new Order();
                isNew = true;
            }
 
            if (isNew)
            {
                var result = await service.EntityRepository.EntitiesContext.AddAsync(order);

            }

            else
            {
                //   await service.EntityRepository.EntitiesContext.Update(bo); 

            }
            return saveStatus;
        }
    }
}
