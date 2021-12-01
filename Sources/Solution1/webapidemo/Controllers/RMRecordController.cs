using EntityModel.RawMaterials;
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
using ViewModels.RawMaterials;
using webapidemo.BaseControllers;

namespace webapidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    public class RMRecordController : BaseTemplateController<RMRecord, RMRecordVM>
    {
        private readonly IWebAPIModelService<RMRecord, RMRecordVM> _servicePR;


        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public RMRecordController(IWebAPIModelService<RMRecord, RMRecordVM> service)
        {
            var demo = base.ViewModelService;

            this._servicePR = service;
        }

        /// <summary>
        /// 获取所有的 RMRecord 对象，前端访问定义 GET: api/RMRecord
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<RMRecordVM>> GetRMRecords()
        {
            var VM = await _servicePR.GetBoVMCollectionAsyn(y => y.MaterialsInfo,x=>x.Order);
            return VM;
        }

        public Task<List<RMRecordVM>> GetRMRecords(String Token)
        {
            var VM = _servicePR.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<RMRecordVM>> PostRMRecord(RMRecordVM RMRecordVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await SubdataWithViewModelService.SaveRMRecordWithOrderandMaterialsInfo(_servicePR, RMRecordVM);
            return CreatedAtAction(nameof(GetRMRecord), new { id = RMRecordVM.Id }, RMRecordVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 RMRecord 对象，前端访问定义  GET: api/RMRecords/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 User 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/RMRecord/id
        public async Task<ActionResult<RMRecordVM>> GetRMRecord(Guid id)
        {
            var VM = _servicePR.GetBoVMAsyn(id,y => y.MaterialsInfo, x => x.Order);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetRMRecord(Guid id, RMRecordVM RMRecordVM)
        {

            var RMRecord = await _servicePR.GetBoVMAsyn(id,y => y.MaterialsInfo, x => x.Order);
            if (RMRecord != null)
            {
                await _servicePR.SaveBoAsyn(RMRecordVM);

            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 RMRecord 对象，
        /// 前端访问定义 DELETE: api/RMRecord/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<RMRecordVM>> DelRMRecord(Guid id)
        {
            var RMRecordVM = await _servicePR.GetBoVMAsyn(id);
            if (RMRecordVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _servicePR.DeleteBoAsyn(id);

            return RMRecordVM;
        }
    }
}
