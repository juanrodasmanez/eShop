using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

           // var config = new ConfigurationBuilder()
           //.SetBasePath(System.IO.Directory.GetCurrentDirectory())
           //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            IConfigurationRoot config = configBuilder.Build();
            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Info($"Start running...");

                CreateWebHostBuilder(args).Build().Run();

                logger.Info($"Start stoped...");
                logger.Error($"Error...");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            finally 
            {
                LogManager.Shutdown();
            }

            
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();
    }
}
