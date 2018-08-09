using CPMS.Web.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CPMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:4000")
                .Build();
    }
}
