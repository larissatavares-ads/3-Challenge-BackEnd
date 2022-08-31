using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ServicoTransferenciaRef
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //IWebHost host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
