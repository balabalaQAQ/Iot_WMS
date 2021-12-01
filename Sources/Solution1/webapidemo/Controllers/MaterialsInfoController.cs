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
    public class MaterialsInfoController : BaseTemplateController<MaterialsInfo, MaterialsInfoVM>

    {
        private readonly IWebAPIModelService<MaterialsInfo, MaterialsInfoVM> _service;

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public MaterialsInfoController(IWebAPIModelService<MaterialsInfo, MaterialsInfoVM> service)
        {
            this._service = service;
        }
        /// <summary>
        /// 获取所有的 MaterialsInfo 对象，前端访问定义 GET: api/MaterialsInfo
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public async Task<List<MaterialsInfoVM>> GetMaterialsInfos()
        {
            var VM = await _service.GetBoVMCollectionAsyn(x => x.MCategory);
            var MCategory = new List<MCategory>();
            MCategory = _service.EntityRepository.EntitiesContext.MCategory.ToList();
 
            foreach (var l in VM)
            {
                l.MCategoryList = MCategory;
            }
            return VM;
        }

        public Task<List<MaterialsInfoVM>> GetMaterialsInfos(String Token)
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<MaterialsInfoVM>> PostMaterialsInfo(MaterialsInfoVM MaterialsInfoVM)
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            var item = await SubdataWithViewModelService.SaveMaterialsInfoWithMCategory(_service, MaterialsInfoVM);
            return CreatedAtAction(nameof(GetMaterialsInfo), new { id = MaterialsInfoVM.Id }, MaterialsInfoVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 MaterialsInfo 对象，前端访问定义  GET: api/MaterialsInfos/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 MaterialsInfo 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/MaterialsInfo/id
        public async Task<ActionResult<MaterialsInfoVM>> GetMaterialsInfo(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id, x => x.MCategory);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetMaterialsInfo(Guid id, MaterialsInfoVM MaterialsInfoVM)
        {

            var MaterialsInfo = await _service.GetBoVMAsyn(id, x => x.MCategory);
            if (MaterialsInfo != null)
            {
                var item = await SubdataWithViewModelService.SaveMaterialsInfoWithMCategory(_service, MaterialsInfoVM);
            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 MaterialsInfo 对象，
        /// 前端访问定义 DELETE: api/MaterialsInfo/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialsInfoVM>> DelMaterialsInfo(Guid id)
        {
            var MaterialsInfoVM = await _service.GetBoVMAsyn(id);
            if (MaterialsInfoVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return MaterialsInfoVM;
        }
    }
}
