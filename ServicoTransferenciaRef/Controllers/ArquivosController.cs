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
    public class ArquivosController : Controller
    {
        //Classe para processar os arquivos cadastrados
        public IEnumerable<Arquivo> Arquivos { get; set; }

        public IActionResult Transferencia()
        {
            var _repo = new ArquivoRepositorioCSV();
            ViewBag.Arquivos = _repo.Transferencia.Arquivos;
            return View("formulario");
        }
        //public IActionResult ExibeLista()
        //{
        //    var _repo = new ArquivoRepositorioCSV();
        //    ViewBag.Arquivos = _repo.Transferencia.Arquivos; 
        //    return View("formulario");
        //}
    }
}
