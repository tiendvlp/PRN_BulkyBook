using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BulkyBook.AppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        public static IWebHost CreateHostBuilder(string[] args)
        {
            return new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;

                 // find the shared folder in the parent folder
                 var sharedFolder = Path.Combine(env.ContentRootPath, "..", "Shared");

                 //load the SharedSettings first, so that appsettings.json overrwrites it
                 config
                     .AddJsonFile(Path.Combine(sharedFolder, "SharedSettings.json"), optional: true)
                     .AddJsonFile("appsettings.json", optional: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                 config.AddEnvironmentVariables();
             })
             .ConfigureLogging((ctx, log) => { /* elided for brevity */ })
             .UseDefaultServiceProvider((ctx, opts) => { /* elided for brevity */ })
             .UseStartup<Startup>()
             .Build();
        }
    }
}
