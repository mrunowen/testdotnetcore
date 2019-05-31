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

			DateTime authTime = DateTime.UtcNow;
			DateTime expiresAt = authTime.AddDays(7);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[] {
					new Claim(JwtRegisteredClaimNames.Iss, JwtBearer.Iss),
					new Claim(JwtRegisteredClaimNames.Aud, JwtBearer.Aud)
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


			var key = new SymmetricSecurityKey(JwtBearer.SecretKey);
			var tokenValidationParams = new TokenValidationParameters
			{
				ValidateLifetime = true,
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = JwtBearer.Iss,
				ValidAudience = JwtBearer.Aud,
				IssuerSigningKey = key
			};

			var jwt = new JwtSecurityTokenHandler();

			var s = jwt.ReadToken(j);

			var c = jwt.ValidateToken(j, tokenValidationParams, out s);

		}
	}
}
