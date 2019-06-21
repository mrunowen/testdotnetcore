using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace TestAspDotNet
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			//	这是一个公用的配置文件
			Config.SetConfiguration(configuration);
			IdentityModelEventSource.ShowPII = true;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMemoryCache();

			services.AddDbContext<DB.DB>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Products"));
			});
			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<DB.DB>();

			//	使用 JWT 身份验证
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(Authentication.JwtBearer.JwtBearerOption);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute("default", "api/login");
			});
		}
	}
}
