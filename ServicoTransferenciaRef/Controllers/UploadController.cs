using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Repositorio;
using ServicoTransferenciaRef.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Controllers
{

    //Classe para processar o upload e cadastro dos arquivos
    public class UploadController
    {
        public IActionResult Incluir(Arquivo arquivo)
        {
            var _repo = new ArquivoRepositorioCSV();
            _repo.Incluir(arquivo);
            //var html = HTMLUtils.CarregaArquivoHTML("sucesso");
            var html = new ViewResult { ViewName = "sucesso" };
            return html;
        }
    }
}
