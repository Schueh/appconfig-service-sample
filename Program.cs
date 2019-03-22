using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace AppConfigServiceSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>{
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options => 
                    {
                        string environment = hostingContext.HostingEnvironment.EnvironmentName;

                        options.Connect(settings["ConnectionStrings:AppConfig"])
                               .Use("*", environment)
                               .Watch("MySettings:Foo", environment, TimeSpan.FromSeconds(5))
                               .Watch("MySettings:Bar", environment, TimeSpan.FromSeconds(5));

                    });
                })
                .UseStartup<Startup>();
    }
}
