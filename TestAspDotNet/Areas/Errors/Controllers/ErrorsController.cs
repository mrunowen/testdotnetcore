using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAspDotNet.Areas.Errors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
		/// <summary>
		/// 返回错误信息
		/// </summary>
		[HttpGet]
		public string Index(string message)
		{
			return message;
		}

		/// <summary>
		/// 返回错误信息和堆栈跟踪
		/// </summary>
		/// <param name="message">错误信息</param>
		/// <param name="stackTrace">堆栈跟踪</param>
		[HttpGet("StackTrace")]
		public string Stack(string message, string stackTrace)
		{
			return string.Concat(message, " ------ ", stackTrace);
		}
    }
}