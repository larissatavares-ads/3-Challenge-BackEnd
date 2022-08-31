namespace ServicoTransferenciaRef.Settings
{
    public class ConnectionStringSettings
    {
        public string IP { get; set; }
        public string Banco { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public string ConnectionString()
        {
            return $"Server={IP};Database={Banco};Uid={Usuario};Pwd={Senha};";
        }
    }
}
