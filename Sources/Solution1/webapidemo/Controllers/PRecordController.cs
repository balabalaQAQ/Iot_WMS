using EntityModel.Product;
using EntityModel.Users;
using Kestrel.DataAccess;
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
    ////产品操作记录
    public class PRecordController : BaseTemplateController<PRecord, PRecordVM>
    {
        private readonly IWebAPIModelService<PRecord, PRecordVM> _servicePR;
        

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public PRecordController(IWebAPIModelService<PRecord, PRecordVM> service)  
        {
            var demo = base.ViewModelService;
           
            this._servicePR = service;   
        }

        /// <summary>
        /// 获取所有的 PRecord 对象，前端访问定义 GET: api/PRecord
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<PRecordVM>> GetPRecords()
        { 
            var VM = await _servicePR.GetBoVMCollectionAsyn(y => y.ProductInfo);
            return VM;
        }

        public Task<List<PRecordVM>> GetPRecords(String Token)
        {
            var VM = _servicePR.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<PRecordVM>> PostPRecord(PRecordVM PRecordVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await SubdataWithViewModelService.SavePRecordWithUserandProductInfo(_servicePR, PRecordVM);
            return CreatedAtAction(nameof(GetPRecord), new { id = PRecordVM.Id }, PRecordVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 PRecord 对象，前端访问定义  GET: api/PRecords/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 User 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/PRecord/id
        public async Task<ActionResult<PRecordVM>> GetPRecord(Guid id)
        {
            var VM =   _servicePR.GetBoVMAsyn(id ,y=> y.ProductInfo);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetPRecord(Guid id, PRecordVM PRecordVM)
        {

            var PRecord = await _servicePR.GetBoVMAsyn(id,x=>x.ProductInfo);
            if (PRecord != null)
            {
                await _servicePR.SaveBoAsyn(PRecordVM);

            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 PRecord 对象，
        /// 前端访问定义 DELETE: api/PRecord/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PRecordVM>> DelPRecord(Guid id)
        {
            var PRecordVM = await _servicePR.GetBoVMAsyn(id);
            if (PRecordVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _servicePR.DeleteBoAsyn(id);

            return PRecordVM;
        }
    }
}
