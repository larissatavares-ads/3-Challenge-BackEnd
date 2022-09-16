using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServicoTransferenciaRef.Controllers
{
    public class HomeNewController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _arquivoRepositorio.RecuperarArquivos());
        }
    }
}