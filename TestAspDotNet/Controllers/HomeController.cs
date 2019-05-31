using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using TestAspDotNet.Models;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Logging;
using Common;
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
			JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();

			var secretKey = new SymmetricSecurityKey(JwtBearer.SecretKey);
			Claim[] claims = new Claim[]{
					new Claim(ClaimTypes.Name, "奥玛吧"),
					new Claim(ClaimTypes.Email, "6766g@mail.com")
			};

			DateTime authTime = DateTime.UtcNow;
			DateTime expiresAt = authTime.AddDays(7);

			JwtSecurityToken token = new JwtSecurityToken
			(
				issuer: JwtBearer.Iss,
				audience: JwtBearer.Aud,
				notBefore: authTime,
				claims: claims,
				expires: expiresAt,
				signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
			);
			string tokenString = jwt.WriteToken(token);

			return Ok(new
			{
				jwtToken = tokenString
			});
		}


		[Authorize]
		[HttpGet("log")]
		public void Log()
		{
			string j;
			j = JwtBearer.GetJwtInHeader(Request.Headers);

			var key = new SymmetricSecurityKey(JwtBearer.SecretKey);

			var jwt = new JwtSecurityTokenHandler();
			
			var c = jwt.ValidateToken(j, JwtBearer.GetTokenValidationParameters(), out SecurityToken s);

		}
	}
}
