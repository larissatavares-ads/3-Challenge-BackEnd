namespace ServicoTransferenciaRef.Models
{
    public class Conexao
    {
        //Abaixo uma string que carrega dados da conexão
        public string conec = "SERVER=localhost; DATABASE=transacoes; UID=root; PWD=leia2612; PORT=;";
        public MysqlConnection con = null;
    }
}
