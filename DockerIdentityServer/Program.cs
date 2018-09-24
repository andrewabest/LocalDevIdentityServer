using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DockerIdentityServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IdentityServer";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:80")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
