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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

namespace TestAspDotNet.Authentication
{
	/// <summary>
	/// JWT 类
	/// 在 appsettings.json 中配置节点： JwtSettings
	/// 节点下子节点配置 Iss、Aud 和 SecretKey（密钥）
	/// 节点下子节点配置 Expires（过期时间间隔：天）
	/// </summary>
	public sealed class JwtBearer
	{
		private static readonly JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();

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
		/// <summary>
		/// expires
		/// 在配置文件中配置
		/// </summary>
		public static int Expires => Config.GetJwtExpires();

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
			string[] jwts = value.ToString().Split(new char[] { ' ' });
			if (jwts.Length != 2 || jwts[0] != "Bearer")
				return "";
			return jwts[1];
		}

		/// <summary>
		/// 获取 JWT 中的声明
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<Claim> GetClaims(string token)
		{
			ClaimsPrincipal principal = GetClaimsPrincipal(token);
			return principal.Claims;
		}

		public static ClaimsPrincipal GetClaimsPrincipal(string token) => jwt.ValidateToken(token, GetTokenValidationParameters(), out SecurityToken securityToken);

		/// <summary>
		/// 创建一个 JWT Token 字符串
		/// </summary>
		/// <returns></returns>
		public static string CreateJwtToken(IEnumerable<Claim> claims)
		{
			var secretKey = new SymmetricSecurityKey(SecretKey);

			DateTime authTime = DateTime.UtcNow;
			DateTime expiresAt = authTime.AddDays(Expires);

			JwtSecurityToken token = new JwtSecurityToken
			(
				issuer: Iss,
				audience: Aud,
				notBefore: authTime,
				claims: claims,
				expires: expiresAt,
				signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
			);
			string tokenString = jwt.WriteToken(token);
			return tokenString;
		}
	}
}
