using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Financas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //inicializando a sincronização e com isso cria automaticamente as tabelas no bd
            WebSecurity.InitializeDatabaseConnection("FinancasContext", "Usuarios", "Id", "Nome", true);
        }
    }
}
