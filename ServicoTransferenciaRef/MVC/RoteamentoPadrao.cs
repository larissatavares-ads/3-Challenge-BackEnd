using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoTransferenciaRef.MVC
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            //GetType e GetMethods fazem parte de uma API do .NET chamda Reflection
            //rota padrão: /<Classe>Logica/Metodo
            //{classe}/{metodo}

            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));
            var nomeCompleto = $"ServicoTransferenciaRef.Controllers.{classe}Controller";

            var tipo = Type.GetType(nomeCompleto);
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);
            
            return requestDelegate.Invoke(context);
        }
    }
}
