using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace App.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Api Demo IdentityServer";
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:7000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
        
    }
}
