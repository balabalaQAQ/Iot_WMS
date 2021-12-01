using EntityModel.RawMaterials;
using Kestrel.DataAccess.Tools;
using Kestrel.IWebAPIModelService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using ViewModels.RawMaterials;
using webapidemo.BaseControllers;

namespace webapidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    public class MCategoryController : BaseTemplateController<MCategory, MCategoryVM>

    {
        private readonly IWebAPIModelService<MCategory, MCategoryVM> _service;
    
        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public MCategoryController(IWebAPIModelService<MCategory, MCategoryVM> service)
        {
            this._service = service;
        }
        /// <summary>
        /// 获取所有的 MCategory 对象，前端访问定义 GET: api/MCategory
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<MCategoryVM>> GetMCategorys()
        {
            var VM = await _service.GetBoVMCollectionAsyn();
            return VM;
        }

        public Task<List<MCategoryVM>> GetMCategorys(String Token)
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<MCategoryVM>> PostMCategory(MCategoryVM MCategoryVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await _service.SaveBoAsyn(MCategoryVM);
            return CreatedAtAction(nameof(GetMCategorys), new { id = MCategoryVM.Id }, MCategoryVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 MCategory 对象，前端访问定义  GET: api/MCategorys/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 MCategory 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/MCategory/id
        public async Task<ActionResult<MCategoryVM>> GetMCategory(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id);
            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetMCategory(Guid id, MCategoryVM MCategoryVM)
        {

            var MCategory = await _service.GetBoVMAsyn(id);
            if (MCategory != null)
            {
                await _service.SaveBoAsyn(MCategoryVM);
            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 MCategory 对象，
        /// 前端访问定义 DELETE: api/MCategory/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MCategoryVM>> DelMCategory(Guid id)
        {
            var MCategoryVM = await _service.GetBoVMAsyn(id);
            if (MCategoryVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return MCategoryVM;
        }
    }
}


