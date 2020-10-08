using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication9
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            System.IO.StreamWriter Writer = System.IO.File.AppendText(@"C:/logs\App.log");

            Writer.WriteLine("App Started: " + DateTime.Now.ToString());
            Writer.Close();
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //throw new Exception();
        }

        private void Application_Error(object sender, EventArgs e)
        {
            System.IO.StreamWriter Writer = System.IO.File.AppendText(@"C:/logs\App2.log");
            Exception ex = HttpContext.Current.Server.GetLastError().GetBaseException();

            HttpContext.Current.Server.ClearError();
            Writer.WriteLine(ex.Message);
            Writer.Close();
        }

    }
}