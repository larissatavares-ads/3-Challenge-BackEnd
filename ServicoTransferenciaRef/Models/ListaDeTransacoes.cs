using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoTransferenciaRef.Models
{
    public class ListaDeTransacoes
    {

        private List<Arquivo> _arquivos;
        public string Nome { get; set; }
        public IEnumerable<Arquivo> Arquivos
        {
            get { return _arquivos; }
        }
        public ListaDeTransacoes(string nome, params Arquivo[] arquivos)
        {
            Nome = nome;
            _arquivos = arquivos.ToList();
            _arquivos.ForEach(a => a.Lista = this);
        }
        public override string ToString()
        {
            var linhas = new StringBuilder();
            linhas.AppendLine(Nome);
            linhas.AppendLine("=========");
            foreach (var arquivo in Arquivos)
            {
                linhas.AppendLine(arquivo.ToString());
            }
            return linhas.ToString();
        }
    }
}
