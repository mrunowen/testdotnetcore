using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


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
			options.TokenValidationParameters = new TokenValidationParameters
			{
				//ValidateLifetime = true,
				RequireExpirationTime = true,
				ValidIssuer = Iss,
				ValidAudience = Aud,
				ValidateAudience = true,
				ValidateIssuer = true,
				//ValidateLifetime = true,
				IssuerSigningKey = new SymmetricSecurityKey(SecretKey)
			};
		}
	}
}
