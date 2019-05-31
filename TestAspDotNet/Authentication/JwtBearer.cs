using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace TestAspDotNet.Authentication
{
	public class JwtBearer
	{
		/// <summary>
		/// 密钥
		/// 在配置文件中配置
		/// </summary>
		public static readonly byte[] SecretKey = Encoding.UTF8.GetBytes(Config.GetJwtSecretKey());
		/// <summary>
		/// iss
		/// 在配置文件中配置
		/// </summary>
		public static string Iss => Config.GetJwtIss();
		/// <summary>
		/// aud
		/// 在配置文件中配置
		/// </summary>
		public static string Aud => Config.GetJwtAud();

		public static void JwtBearerOption(JwtBearerOptions options)
		{
			options.TokenValidationParameters = GetTokenValidationParameters();
		}

		public static TokenValidationParameters GetTokenValidationParameters()
		{
			return new TokenValidationParameters
			{
				RequireExpirationTime = true,
				ValidIssuer = Iss,
				ValidAudience = Aud,
				ValidateAudience = true,
				ValidateIssuer = true,
				//ValidateLifetime = true,
				IssuerSigningKey = new SymmetricSecurityKey(SecretKey)
			};
		}

		/// <summary>
		/// 获取头部中的 JWT 参数
		/// </summary>
		/// <param name="header"></param>
		/// <returns></returns>
		public static string GetJwtInHeader(IHeaderDictionary header)
		{
			if (!header.TryGetValue("Authorization", out StringValues value))
				return "";
			string[] jwts = value.ToString().Split(' ');
			if (jwts.Length != 2 || jwts[0] != "Bearer")
				return "";
			return jwts[1];
		}

	}
}
