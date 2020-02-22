using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SofoTest {
    public class Program {
        public static void Main(string[] args) {
            //CreateWebHostBuilder(args).Build().Run();
            var host = new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseKestrel(serverOptions => {
                        // Set properties and call methods on options
                    })
                    //.UseIISIntegration()
                    .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder => {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
