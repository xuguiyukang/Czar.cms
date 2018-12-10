using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Sample01
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IWebHostBuilder whb = CreateWebHostBuilder(args);
            IWebHost wh = whb.Build();
            wh.Run();

            /*CreateWebHostBuilder(args).Build().Run();*/
        }
        /*
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
                        */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            IWebHostBuilder whb = WebHost.CreateDefaultBuilder(args);
            whb.ConfigureAppConfiguration((a, b) =>
            {
                var env = a.HostingEnvironment;
                b.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true).AddJsonFile("Content.json", optional: false, reloadOnChange: false).AddEnvironmentVariables();

            });
            return whb.UseStartup<Startup>();
        }

    }
}
