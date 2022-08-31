using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicoTransferenciaRef.Repositorio;
using ServicoTransferenciaRef.Settings;

namespace ServicoTransferenciaRef
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var teste = _configuration.GetSection("ConnectionStrings").GetSection("mysql").Get<ConnectionStringSettings>();
            services.AddRouting();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton(teste);
            services.AddScoped<IArquivoRepositorio, ArquivoRepositorioCSV>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
