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
    [ApiController]
    [Route("arquivo")]
    public class HomeController : Controller
    {
        //Classe para processar os arquivos cadastrados
        private IArquivoRepositorio _arquivoRepositorio { get; }
        public HomeController(IArquivoRepositorio arquivoRepositorio)
        {
            _arquivoRepositorio = arquivoRepositorio;
        }

        //=============================================CREATE===========================================================
        //CREATE
        [HttpPost]
        public async Task<IActionResult> CriarArquivo(Arquivo arquivo)
        {
            await _arquivoRepositorio.CriarArquivo(arquivo);
            return Ok(arquivo);
        }
        
        //CREATE
        public async Task<IActionResult> Incluir(Arquivo arquivo)
        {
            await _arquivoRepositorio.CriarArquivo(arquivo);
            await _arquivoRepositorio.RecuperarArquivos();
            var html = new ViewResult { ViewName = "sucesso" };
            return html;
        }
        
        //===============================================READ===========================================================
        //READ
        [HttpGet]
        public async Task<IActionResult> RecuperarArquivo()
        {
            var lista = await _arquivoRepositorio.RecuperarArquivos();
            return Ok(lista);
        }
        
        //READ
        public async Task<IActionResult> Index()
        {
            return View(await _arquivoRepositorio.RecuperarArquivos());
        }

        //READ
        [HttpPost("pegarArquivo")]
        public async Task<IActionResult> PegarArquivo()
        {
            try
            {
                string conteudo = await PegarConteudoDoArquivo(HttpContext);
                
                string[][] linhas = conteudo
                    .ToString()
                    .Split('\n')
                    .Select(l => l.Split(';'))
                    .ToArray();
               
                
                Arquivo arquivos = ArquivoRepositorio.CreateList(linhas);
                await Incluir(arquivos);

                return Ok(new BaseRetorno { Mensagem = "Transações importadas com sucesso" });
            }
            catch (BusinessException ex)
            {
                return BadRequest(new BaseRetorno { Mensagem = ex.Message, Status = 1 });
            }
        }
        
        //READ
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
