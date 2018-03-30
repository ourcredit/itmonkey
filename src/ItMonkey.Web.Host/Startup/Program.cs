using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using IConfiguration = AutoMapper.Configuration.IConfiguration;

namespace ItMonkey.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .AddJsonFile("server.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables().Build();
           
            var host = new WebHostBuilder()
                .UseConfiguration(conf)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
      
    }
}
