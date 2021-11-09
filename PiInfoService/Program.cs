using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//dotnet publish
//scp -r .\bin\Debug\net5.0\publish\* pi@192.168.1.150:/home/pi/dotnet-deploy/
// dotnet publish; scp -r .\bin\Debug\net5.0\publish\* pi@192.168.1.150:/home/pi/dotnet-deploy/
//usage with ssh keyfile

namespace PiInfoService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://192.168.1.150:5000");
                });
    }
}
