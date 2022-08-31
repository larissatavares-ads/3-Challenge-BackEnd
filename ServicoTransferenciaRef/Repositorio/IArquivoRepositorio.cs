using ServicoTransferenciaRef.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Repositorio
{
    public interface IArquivoRepositorio
    {
        ListaDeTransacoes Transferencia { get; }
        IEnumerable<Arquivo> Todos { get; }
        void Incluir(Arquivo arquivo);
        Task CriarArquivo(Arquivo arquivo);
        Task<List<Arquivo>> RecuperarArquivos();
    }
}
