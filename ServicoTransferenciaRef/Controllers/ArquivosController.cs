using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using ServicoTransferenciaRef.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Controllers
{
    public class ArquivosController
    {
        //Classe para processar os arquivos cadastrados
        public IActionResult ExibeFormulario()
        {
            new ArquivoRepositorioCSV();
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }
        //public IActionResult Transferencia()
        //{
        //    var _repo = new ArquivoRepositorioCSV();
        //    var html = ExibeFormulario();
        //    return html;
        //}
    }
}
