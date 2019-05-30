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

namespace TestAspDotNet.Controllers
{
	//[Authorize]
	[Route("api/Home")]
	public class HomeController : Controller
	{
		private readonly byte[] sKey = Encoding.UTF8.GetBytes("11231123123123123132");
		private readonly string iss = "http://localhost:5200";
		private readonly string aud = "api";

		//[HttpGet("index")]
		//public async void Index()
		//{
		//	var claims = new List<Claim>
		//	{
		//		new Claim(ClaimTypes.Name, "奥巴马"),
		//		new Claim(ClaimTypes.NameIdentifier, "身份证")
		//	};

		//	var c = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		//	var p = new ClaimsPrincipal(c);

		//	await HttpContext.SignInAsync(p);

		//}

		[HttpGet("index")]
		[AllowAnonymous]
		public IActionResult Index()
		{
			JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();

			var secretKey = new SymmetricSecurityKey(sKey);

			DateTime authTime = DateTime.UtcNow;
			DateTime expiresAt = authTime.AddDays(7);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[] {
					new Claim(JwtRegisteredClaimNames.Iss, iss),
					new Claim(JwtRegisteredClaimNames.Aud, aud)
				}),
				Expires = expiresAt,
				NotBefore = authTime.AddDays(1),
				SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
			};
			IdentityModelEventSource.ShowPII = true;
			var token = jwt.CreateToken(tokenDescriptor);
			string tokenString = jwt.WriteToken(token);

			return Ok(tokenString);
		}


		[Authorize]
		[HttpGet("log")]
		public void Log()
		{
			string j = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyMDAiLCJhdWQiOiJhcGkiLCJuYmYiOjE1NTkxOTQ1NDAsImV4cCI6MTU1OTc5OTM0MCwiaWF0IjoxNTU5MTk0NTQwfQ.KbH7ZNcnB9C-hv3rAbFnx2wEJ1c-GrQeiUfm-jhihyg";


			var key = new SymmetricSecurityKey(sKey);
			var tokenValidationParams = new TokenValidationParameters
			{
				ValidateLifetime = true,
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = iss,
				ValidAudience = aud,
				IssuerSigningKey = key
			};

			var jwt = new JwtSecurityTokenHandler();

			var s = jwt.ReadToken(j);

			var c = jwt.ValidateToken(j, tokenValidationParams, out s);

		}
	}
}
