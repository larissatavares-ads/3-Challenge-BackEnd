using System;
using System.Collections;
using System.Collections.Generic;
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
        public string Data { get; set; }
        public ListaDeTransacoes Lista { get; set; }

        public static IList<Arquivo> CreateList(string[][] linhas)
        {
            List<Arquivo> arquivos = new List<Arquivo>();
            foreach (string[] line in linhas)
            {
                arquivos.Add(new Arquivo
                {
                    Id = Convert.ToInt32(line[1]),
                    Nome = line[2],
                    Conta = Convert.ToDouble(line[3]),
                    Agencia = Convert.ToDouble(line[4]),
                    Banco = line[5],
                    Valor = Convert.ToDecimal(line[6]),
                    Data = line[7]
                });
            }
            return arquivos;
        }

        public string Detalhes()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Detalhes da transferencia");
            stringBuilder.AppendLine("===========================");
            stringBuilder.AppendLine($"Titular: {Nome}");
            stringBuilder.AppendLine($"Conta: {Conta}");
            stringBuilder.AppendLine($"Agencia: {Agencia}");
            stringBuilder.AppendLine($"Banco: {Banco}");
            stringBuilder.AppendLine($"Valor: {Valor}");
            stringBuilder.AppendLine($"Data: {Data}");
            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            return $"{Id} | {Nome} | {Conta} | {Agencia} | {Banco} | {Valor} | {Data}";
        }
    }
}
