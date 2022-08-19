using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;

namespace ServicoTransferenciaRef.Controllers
{

    //Classe para processar o upload e cadastro dos arquivos
    public class CadastroController : Controller
    {
        public IActionResult Incluir(Arquivo arquivo)
        {
            var _repo = new ArquivoRepositorioCSV();
            _repo.Incluir(arquivo);
            var html = new ViewResult { ViewName = "sucesso" };
            return html;
        }
        public IActionResult ExibeFormulario()
        {
            var _repo = new ArquivoRepositorioCSV();
            ViewBag.Arquivos = _repo.Transferencia.Arquivos;
            return View("formulario");
            //var html = new ViewResult { ViewName = "formulario" };
            //return html;
        }
    }
}
