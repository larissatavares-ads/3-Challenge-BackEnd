using ServicoTransferenciaRef.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Repositorio
{
    public interface IArquivoRepositorio
    {
        Task CriarArquivo(Arquivo arquivo);
        Task<List<Arquivo>> RecuperarArquivos();
    }
}
