using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoTransferenciaRef.Models
{
    public class Arquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Conta { get; set; }
        public double Agencia { get; set; }
        public string Banco { get; set; }
        public decimal Valor { get; set; }
        public string Data_transacao { get; set; }
        public ListaDeTransacoes Lista { get; set; }

        //public string Detalhes()
        //{
        //    var stringBuilder = new StringBuilder();
        //    stringBuilder.AppendLine("Detalhes da transferencia");
        //    stringBuilder.AppendLine("===========================");
        //    stringBuilder.AppendLine($"Titular: {Nome}");
        //    stringBuilder.AppendLine($"Conta: {Conta}");
        //    stringBuilder.AppendLine($"Agencia: {Agencia}");
        //    stringBuilder.AppendLine($"Banco: {Banco}");
        //    stringBuilder.AppendLine($"Valor: {Valor}");
        //    stringBuilder.AppendLine($"Data: {Data_transacao}");
        //    return stringBuilder.ToString();
        //}
        public override string ToString()
        {
            return $"{Id} | {Nome} | {Conta} | {Agencia} | {Banco} | {Valor} | {Data_transacao}";
        }
    }
}
