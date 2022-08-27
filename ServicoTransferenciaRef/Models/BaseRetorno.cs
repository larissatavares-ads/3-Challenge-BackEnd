using Microsoft.AspNetCore.Mvc;

namespace ServicoTransferenciaRef.Models
{
    public class BaseRetorno
    {
        public string Mensagem { get; set; }
        public int Status { get; set; }
    }
}
