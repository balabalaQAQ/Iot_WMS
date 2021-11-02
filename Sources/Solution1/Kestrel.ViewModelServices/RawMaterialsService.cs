
using EntityModel.Orders;
using EntityModel.RawMaterials;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using Kestrel.ViewModelServices.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.RawMaterials;

namespace Kestrel.ViewModelServices
{
    public static class RawMaterialsService
    {
        public static async Task<SaveStatusModel> SaveCardWithLevel(this IWebAPIModelService<MaterialsInfo, MaterilsInfoVM> service, MaterilsInfoVM boVM)
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
    }
}
