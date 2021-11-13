using Kestrel.IWebAPIModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityModel.Order;
using Kestrel.ORM;
 
using ViewModels.Orders;
 
using Kestrel.DataAccess.Tools;
using Microsoft.AspNetCore.Cors;
using webapidemo.BaseControllers;

namespace webapidemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AnyOrigin")]
    // [Authorize]

    // 订单
    public class OrderController :BaseTemplateController<Order, OrderVM>
    {
        private readonly IWebAPIModelService<Order, OrderVM> _service;

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public OrderController(IWebAPIModelService<Order, OrderVM> service  )
        {
            this._service = service;
        }

        /// <summary>
        /// 获取所有的 Order 对象，前端访问定义 GET: api/Order
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<OrderVM>> GetOrders()
        {
            var VM = await _service.GetBoVMCollectionAsyn();

            return  VM;
        }

        public async Task<List<OrderVM>> GetOrders(String Token)
        {
            var VM = await _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<OrderVM>> PostOrder(OrderVM OrderVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            OrderVM.SetTime = DateTime.Now.ToString();
            await _service.SaveBoAsyn(OrderVM);
            return CreatedAtAction(nameof(GetOrder), new { id = OrderVM.Id }, OrderVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 Order 对象，前端访问定义  GET: api/Orders/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 User 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/Order/id
        public async Task<ActionResult<OrderVM>> GetOrder(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetOrder(Guid id, OrderVM OrderVM)
        {

            var Order = await _service.GetBoVMAsyn(id);
            if (Order != null)
            {
                await _service.SaveBoAsyn(OrderVM);

            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 Order 对象，
        /// 前端访问定义 DELETE: api/Order/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderVM>> DelOrder(Guid id)
        {
            var OrderVM = await _service.GetBoVMAsyn(id);
            if (OrderVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return OrderVM;
        }
        // [Authorize]
        //[HttpPost]
        //public IActionResult GetUserInfo()
        //{
        //    获取当前请求的用户信息，包含token信息
        //    var user = HttpContext.User;
        //    return Ok(new { status = "success" });

        //}

    }
}
