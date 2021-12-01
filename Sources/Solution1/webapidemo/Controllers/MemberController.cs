using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weiapidemo.Provider;

namespace DikaleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    public class MemberController : ControllerBase//原料信息
    {

        private readonly MemberIO _context;  // 用于处理 EF 数据属性的

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public MemberController(MemberIO context)
        {
            this._context = context;
        }

        [HttpGet("[action]")]
        public IActionResult Forecasts([FromQuery(Name = "from")]int from = 0, [FromQuery(Name = "to")] int to = 4)
        {
            var quantity = to - from;
            if (quantity <= 0)
            {
                return BadRequest("'to'参数大于'from'参数，这是不允许的。");
            }
            if (from < 0)
            {
                return BadRequest("'from'参数不能小于0.");
            }
            var allForecasts = _context.GetForecasts();
            var result = new
            {
                Total = allForecasts.Count,
                Forecasts = allForecasts.Skip(from).Take(quantity).ToArray()
            };
            return Ok(result);
        }
    }
}