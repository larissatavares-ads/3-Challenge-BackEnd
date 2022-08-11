using ServicoTransferenciaRef.Models;
using System.Collections.Generic;

namespace ServicoTransferenciaRef.Repositorio
{
    public interface IArquivoRepositorio
    {
        ListaDeTransacoes Transferencias { get; }
        IEnumerable<Arquivo> Todos { get; }
        void Incluir(Arquivo arquivo);
    }
}
