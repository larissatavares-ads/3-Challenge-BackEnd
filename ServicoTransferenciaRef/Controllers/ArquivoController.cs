using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Controllers
{
    [ApiController]
    [Route("Arquivo")]
    public class ArquivoController : ControllerBase
    {
        private IArquivoRepositorio _arquivoRepositorio;
        public ArquivoController(IArquivoRepositorio repo)
        {
            _arquivoRepositorio = repo;
        }
        [HttpPost]
        public async Task<IActionResult> CriarArquivo(Arquivo arquivo)
        {
            await _arquivoRepositorio.CriarArquivo(arquivo);
            return Ok(arquivo);
        }
        [HttpGet]
        public async Task<IActionResult> RecuperarArquivo()
        {
            var lista = await _arquivoRepositorio.RecuperarArquivos();
            return Ok(lista);
        }

    }
}
