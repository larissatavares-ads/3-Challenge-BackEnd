using System;

namespace ServicoTransferenciaRef.Models
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
