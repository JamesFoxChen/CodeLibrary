using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using PT.Ayl.Services;

namespace PT.Ayl.Services
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            RouteTable.Routes.Add(new ServiceRoute("Account", new WebServiceHostFactory(), typeof(AccountService)));
        }
    }
}
