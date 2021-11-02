using EntityModel.Orders;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using KestrelWebApi.BaseControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Orders;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController :BaseTemplateController<Order, OrderVM>
    {
        private readonly IWebAPIModelService<Order, OrderVM> _service;

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public OrderController(
               IWebAPIModelService<Order, OrderVM> service
            )
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<List<OrderVM>> GetPark()
        {
            var VM = await _service.GetBoVMCollectionAsyn();
            return VM;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderVM>> GetParkAsync(Guid id)
        {

            var VM = _service.GetBoVMAsyn(id);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkr(Guid id, OrderVM AmusementParkVM)
        {
            var Commodity = await _service.GetBoVMAsyn(id);
            if (Commodity != null)
            {
                await _service.SaveBoAsyn(AmusementParkVM);

            }
            return NoContent(); // 返回 204
        }

        [HttpPost]
        public async Task<ActionResult<OrderVM>> PostPark(OrderVM AmusementParkVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await _service.SaveBoAsyn(AmusementParkVM);
            return CreatedAtAction(nameof(GetParkAsync), new { id = AmusementParkVM.Id }, AmusementParkVM);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderVM>> DeletePark(Guid id)
        {
            var AmusementParkVM = await _service.GetBoVMAsyn(id);
            if (AmusementParkVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return AmusementParkVM;
        }

    }
}
