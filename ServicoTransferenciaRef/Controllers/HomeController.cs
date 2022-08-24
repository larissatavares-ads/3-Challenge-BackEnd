using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Controllers
{
    public class HomeController : Controller
    {
        //Classe para processar os arquivos cadastrados
        public IEnumerable<Arquivo> Arquivos { get; set; }

        public IActionResult Incluir(Arquivo arquivo)
        {
            var repo = new ArquivoRepositorioCSV();
            repo.Incluir(arquivo);
            var html = new ViewResult { ViewName = "sucesso" };
            return html;
        }
        public IActionResult ExibeFormulario()
        {
            var _repo = new ArquivoRepositorioCSV();
            ViewBag.Arquivos = _repo.Transferencia.Arquivos;
            return View("Index");
        }


        [HttpPost("pegarArquivo")]
        public async Task<IActionResult> PegarArquivo()
        {
            try
            {
                string conteudo = await PegarConteudoDoArquivo(HttpContext);
                string[][] linhas = conteudo.ToString().Split('\n').Select(l => l.Split(';')).ToArray();
                // Continuar a partir daqui
                List<Arquivo> arquivos = Arquivo.CreateList(linhas).ToList();
                return Ok(new BaseRetorno { Mensagem = "Transações importadas com sucesso" });
            }
            catch (BusinessException ex)
            {
                return BadRequest(new BaseRetorno { Mensagem = ex.Message, Status = 1 });
            }
        }

        private async Task<string> PegarConteudoDoArquivo(HttpContext httpContext)
        {
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            byte[] request = new byte[(int)(HttpContext.Request.ContentLength ?? 0)];
            await httpContext.Request.Body.ReadAsync(request, 0, request.Length);
            string bodyComplete = Encoding.UTF8.GetString(request);
            if (bodyComplete.Length < 21)
                throw new BusinessException("O arquivo deve ter algum conteudo dentro");
            string base64 = uTF8Encoding.GetString(request).Remove(0, 23);

            // onde transforma de base64 para array de byte
            byte[] arquivoBinario = Convert.FromBase64String(base64);
            StringBuilder conteudo = new StringBuilder();
            foreach (byte b in arquivoBinario)
            {
                conteudo.Append((char)b);
            }
            return conteudo.ToString();
        }

    }
}
