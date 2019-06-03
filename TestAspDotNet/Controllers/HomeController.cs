﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using TestAspDotNet.Authentication;

namespace TestAspDotNet.Controllers
{
	//[Authorize]
	[Route("api/Home")]
	public class HomeController : Controller
	{
		[HttpGet("index")]
		[AllowAnonymous]
		public IActionResult Index()
		{
			Claim[] claims = new Claim[]{
					new Claim(ClaimTypes.Name, "奥玛吧"),
					new Claim(ClaimTypes.Email, "6766g@mail.com")
			};

			var c = new MemoryCacheOptions();
			IMemoryCache memory = new MemoryCache(c);
			
			//memory.GetOrCreate
			string tokenString = JwtBearer.CreateJwtToken(claims);

			return Ok(new
			{
				jwtToken = tokenString
			});
		}


		[Authorize]
		[HttpGet("log")]
		public void Log()
		{
			string token = JwtBearer.GetJwtInHeader(Request.Headers);
			ClaimsPrincipal principal = JwtBearer.GetClaimsPrincipal(token);
		}
	}
}
