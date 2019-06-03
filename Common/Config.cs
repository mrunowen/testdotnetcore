/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Config.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-31 08:41:54
 *
 *  Version:        V1.0.0
 ***********************************************/

using Microsoft.Extensions.Configuration;

namespace Common
{
	public static class Config
	{
		private static IConfiguration _config;

		public static void SetConfiguration(IConfiguration config)
		{
			_config = config;
		}

		/// <summary>
		/// 获取配置文件中的 JWT 配置
		/// </summary>
		/// <returns></returns>
		public static IConfigurationSection GetJwtSettings() => _config.GetSection("JwtSettings");

		/// <summary>
		/// 获取 JWT 的密钥
		/// </summary>
		/// <returns></returns>
		public static string GetJwtSecretKey() => GetJwtSettings()["SecretKey"];
		/// <summary>
		/// 获取 JWT 的 Iss
		/// </summary>
		/// <returns></returns>
		public static string GetJwtIss() => GetJwtSettings()["Iss"];
		/// <summary>
		/// 获取 JWT 的 Aud
		/// </summary>
		/// <returns></returns>
		public static string GetJwtAud() => GetJwtSettings()["Aud"];
	}
}
