using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAspDotNet.Areas.Users.Controllers
{
	/// <summary>
	/// 登陆登出等相关操作用
	/// </summary>
	[Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {

		[HttpPost("login")]
		public string SignIn()
		{
			return "success";
		}

		[HttpGet("logout")]
		[Authorize]
		public string SingOut()
		{
			return "success";
		}
    }
}