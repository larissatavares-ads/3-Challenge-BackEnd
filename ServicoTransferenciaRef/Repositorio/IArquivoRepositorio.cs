using ServicoTransferenciaRef.Models;
using System.Collections.Generic;

namespace ServicoTransferenciaRef.Repositorio
{
    public interface IArquivoRepositorio
    {
        ListaDeTransacoes Transferencia { get; }
        IEnumerable<Arquivo> Todos { get; }
        void Incluir(Arquivo arquivo);
    }
}
