﻿using System.IO;

namespace ServicoTransferenciaRef.Views
{
    public class HTMLUtils
    {
        public static string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"Views/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
