using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Unity.Microsoft.DependencyInjection;

namespace ctep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
            .UseKestrel()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .UseUnityServiceProvider()
            .UseStartup<Startup>()
            .Build();

            webHost.Run();
        }
    }
}
