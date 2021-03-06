﻿/*  RELEASE NOTE
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
		/// <summary>
		/// 配置
		/// </summary>
		public static IConfiguration Configuration { get; private set; }

		public static void SetConfiguration(IConfiguration config)
		{
			Configuration = config;
		}
		
		/// <summary>
		/// 获取数据库连接字符串
		/// </summary>
		/// <param name="name"></param>
		public static void GetConnectionString(string name) => Configuration.GetConnectionString(name);

		/// <summary>
		/// 获取配置文件中的 JWT 配置
		/// </summary>
		/// <returns></returns>
		public static IConfigurationSection GetJwtSettings() => _config.GetSection("JwtSettings");

		/// <summary>
		/// 获取 JWT 的密钥
		/// </summary>
		/// <returns></returns>
		public static string GetJwtSecretKey() => GetJwtSettings()["SecretKey"] ?? "";
		/// <summary>
		/// 获取 JWT 的 Iss
		/// </summary>
		/// <returns></returns>
		public static string GetJwtIss() => GetJwtSettings()["Iss"] ?? "";
		/// <summary>
		/// 获取 JWT 的 Aud
		/// </summary>
		/// <returns></returns>
		public static string GetJwtAud() => GetJwtSettings()["Aud"] ?? "";
		/// <summary>
		/// '获取JWT 的 Expires
		/// </summary>
		/// <returns></returns>
		public static int GetJwtExpires()
		{
			//	默认过期时间
			int defaultExpires = 1;
			string expires = GetJwtSettings()["Expires"];
			if (int.TryParse(expires, out int ex))
				return ex;
			return defaultExpires;
		}
	}
}
