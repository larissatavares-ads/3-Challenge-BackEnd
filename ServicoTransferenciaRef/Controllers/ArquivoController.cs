using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Controllers
{
    [ApiController]
    [Route("arquivo")]
    public class ArquivoController : ControllerBase
    {
        private IArquivoRepositorio _arquivoRepositorio;
        public ArquivoController(IArquivoRepositorio repo)
        {
            _arquivoRepositorio = repo;
        }
        

    }
}
