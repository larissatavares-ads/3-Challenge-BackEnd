﻿using Dapper;
using MySql.Data.MySqlClient;
using ServicoTransferenciaRef.Models;
using ServicoTransferenciaRef.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.Repositorio
{
    public class ArquivoRepositorio : IArquivoRepositorio
    {
        private static string nomeArquivoCSV = "Repositorio\\arquivos.csv";

        private ListaDeTransacoes _transferencia;
        public IEnumerable<Arquivo> Todos => _transferencia.Arquivos;
        
        public ArquivoRepositorio()
        {
            var arrayTransferencia = new List<Arquivo>();

            using (
                var file = File.OpenText(nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textoArquivo = file.ReadLine();
                    if (string.IsNullOrEmpty(textoArquivo))
                    {
                        continue;
                    }
                    var infoArquivo = textoArquivo.Split(';');
                    var arquivo = new Arquivo
                    {
                        Id = Convert.ToInt32(infoArquivo[1]),
                        Nome = infoArquivo[2],
                        Conta = Convert.ToDouble(infoArquivo[3]),
                        Agencia = Convert.ToDouble(infoArquivo[4]),
                        Banco = infoArquivo[5],
                        Valor = Convert.ToDecimal(infoArquivo[6]),
                        Data_transacao = infoArquivo[7]
                    };
                    switch (infoArquivo[0])
                    {
                        case "transferencia":
                            arrayTransferencia.Add(arquivo);
                            break;
                    }
                }
            }

            _transferencia = new ListaDeTransacoes("Transferencia", arrayTransferencia.ToArray());
        }

        
        public static Arquivo CreateList(string[][] linhas)
        {
            var arrayTransferencia = new Arquivo();
            foreach (string[] line in linhas)
            {
                arrayTransferencia = new Arquivo
                {
                    Nome = line[0],
                    Conta = Convert.ToDouble(line[1]),
                    Agencia = Convert.ToDouble(line[2]),
                    Banco = line[3],
                    Valor = Convert.ToDecimal(line[4]),
                    Data_transacao = line[5]
                };
            }
            return arrayTransferencia;
        }
        
        
        
        //==============================CONNECTION-STRING==============================
        private string _connectionString { get; }
        public ArquivoRepositorio(ConnectionStringSettings settings)
        {
            _connectionString = settings.ConnectionString();
        }
        
        public async Task CriarArquivo(Arquivo arquivo)
        {
            using (IDbConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                await conexao
                    .ExecuteAsync($"INSERT INTO Arquivo (Nome, Conta, Agencia, Banco, Valor, Data_transacao) VALUES (@Nome, @Conta, @Agencia, @Banco, @Valor, @Data_transacao);", arquivo);
            }
        }
        
        public async Task<List<Arquivo>> RecuperarArquivos()
        {
            using (IDbConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                var lista = (await conexao.QueryAsync<Arquivo>("SELECT * FROM arquivo;")).ToList();
                return lista;
            }
        }
    }
}
