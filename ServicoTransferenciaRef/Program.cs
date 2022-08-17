using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ServicoTransferenciaRef
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
