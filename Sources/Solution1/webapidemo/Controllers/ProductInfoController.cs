using EntityModel.Orders;
using EntityModel.Product;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using Kestrel.ViewModelServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Product;
using webapidemo.BaseControllers;

namespace webapidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    //产品信息
    public class ProductInfoController : BaseTemplateController<ProductInfo, ProductInfoVM>

    {
        private readonly IWebAPIModelService<ProductInfo, ProductInfoVM> _service;
        public IWebAPIModelService<ProductInfo, ProductInfoVM> _serviceP;//提供给派生类使用的服务
        private readonly IWebAPIModelService<PRecord, PRecordVM> Service;



        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public ProductInfoController(IWebAPIModelService<ProductInfo, ProductInfoVM> service)
        {
            this._service = service;
            this._serviceP = service;
        }
        /// <summary>
        /// 获取所有的 ProductInfo 对象，前端访问定义 GET: api/ProductInfo
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<ProductInfoVM>> GetProductInfos()
        {
            var VM = await _service.GetBoVMCollectionAsyn(x=>x.PCategory,y=>y.Order);
            var PCategory = new List<PCategory>();
            PCategory = _service.EntityRepository.EntitiesContext.PCategory.ToList();

            var Order = new List<Order>();
            Order = _service.EntityRepository.EntitiesContext.Order.ToList();
            foreach (var l in VM)
            {
                l.OrderList = Order;
                l.PCategoryList = PCategory;
            }
            return VM;
        }

        public Task<List<ProductInfoVM>> GetProductInfos(String Token)
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<ProductInfoVM>> PostProductInfo(ProductInfoVM ProductInfoVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var item = await SubdataWithViewModelService.SaveProductInfoWithOrderAndPCategory(_service, ProductInfoVM);
            return CreatedAtAction(nameof(GetProductInfo), new { id = ProductInfoVM.Id }, ProductInfoVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 ProductInfo 对象，前端访问定义  GET: api/ProductInfos/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 ProductInfo 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/ProductInfo/id
        public async Task<ActionResult<ProductInfoVM>> GetProductInfo(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id, x => x.PCategory, y => y.Order);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetProductInfo(Guid id, ProductInfoVM ProductInfoVM)
        {

            var ProductInfo = await _service.GetBoVMAsyn(id, x => x.PCategory, y => y.Order);
            if (ProductInfo != null)
            {
                var item = await SubdataWithViewModelService.SaveProductInfoWithOrderAndPCategory(_service, ProductInfoVM);
            }
            return NoContent(); // 返回 204
        }
       


        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 ProductInfo 对象，
        /// 前端访问定义 DELETE: api/ProductInfo/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductInfoVM>> DelProductInfo(Guid id)
        {
            var ProductInfoVM = await _service.GetBoVMAsyn(id);
            if (ProductInfoVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return ProductInfoVM;
        }
    }
}
