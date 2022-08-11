using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using ServicoTransferenciaRef.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef
{
    public class Startup : HTMLUtils
    {
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("/Servico/Transferencia", ExibeFormulario);
            builder.MapRoute("/Cadastro/Incluir", ProcessaArquivo);
            var rotas = builder.Build();

            app.UseRouter(rotas);
        }
        public Task ProcessaArquivo(HttpContext context)
        {
            var arquivo = new Arquivo()
            {
                Nome = context.Request.Form["nome"],
                Conta = Convert.ToDouble(context.Request.Form["conta"]),
                Agencia = Convert.ToDouble(context.Request.Form["agencia"]),
                Banco = context.Request.Form["banco"],
                Valor = Convert.ToDecimal(context.Request.Form["valor"]),
                Data = context.Request.Form["data"]
            };
            var _repo = new ArquivoRepositorioCSV();
            _repo.Incluir(arquivo);
            var html = CarregaArquivoHTML("sucesso");
            return context.Response.WriteAsync(html);
        }
        public Task ExibeFormulario(HttpContext context)
        {
            var _repo = new ArquivoRepositorioCSV();
            var html = CarregaArquivoHTML("formulario");

            foreach (var arquivo in _repo.Transferencias.Arquivos)
            {
                html = html.Replace($"#NOVO-ARQUIVO#", $"<li>{arquivo.Id} | {arquivo.Nome} | {arquivo.Conta} | {arquivo.Agencia} | {arquivo.Banco} | {arquivo.Valor} | {arquivo.Data}</li>#NOVO-ARQUIVO#");
            }
            html = html.Replace("#NOVO-ARQUIVO#", "");
            return context.Response.WriteAsync(html);
        }
        public Task Roteamento(HttpContext context)
        {
            var _repo = new ArquivoRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                { "/Servico/Transferencia", ArquivosTransferencia }
            };
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("ERRO 404\n" +
                "Caminho inexistente.");
        }
        public Task ArquivosTransferencia(HttpContext context)
        {
            var _repo = new ArquivoRepositorioCSV();
            return context.Response.WriteAsync(_repo.Transferencias.ToString());
        }
    }
}
