using EntityModel.Product;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
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
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AnyOrigin")]
    // 产品类型
    public class PCategoryController : BaseTemplateController<PCategory, PCategoryVM>
    {
        private readonly IWebAPIModelService<PCategory, PCategoryVM> _service;

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public PCategoryController(
               IWebAPIModelService<PCategory, PCategoryVM> service
            )
        {
            this._service = service;
        }

        /// <summary>
        /// 获取所有的 PCategory 对象，前端访问定义 GET: api/PCategory
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public Task<List<PCategoryVM>> GetPCategorys()
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }

        public Task<List<PCategoryVM>> GetPCategorys(String Token)
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<PCategoryVM>> PostPCategory(PCategoryVM PCategoryVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await _service.SaveBoAsyn(PCategoryVM);
            return CreatedAtAction(nameof(GetPCategory), new { id = PCategoryVM.Id }, PCategoryVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 PCategory 对象，前端访问定义  GET: api/PCategorys/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 User 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/PCategory/id
        public async Task<ActionResult<PCategoryVM>> GetPCategory(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetPCategory(Guid id, PCategoryVM PCategoryVM)
        {

            var PCategory = await _service.GetBoVMAsyn(id);
            if (PCategory != null)
            {
                await _service.SaveBoAsyn(PCategoryVM);

            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 PCategory 对象，
        /// 前端访问定义 DELETE: api/PCategory/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PCategoryVM>> DelPCategory(Guid id)
        {
            var PCategoryVM = await _service.GetBoVMAsyn(id);
            if (PCategoryVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return PCategoryVM;
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