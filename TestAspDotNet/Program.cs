using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TestAspDotNet
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true)
				.Build();

			CreateWebHostBuilder(args)
				.UseConfiguration(config)
				.Build()
				.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
