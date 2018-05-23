using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace UnAventon
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo que se ejecuta en cada request de la aplicacion.
        /// </summary>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if ((Context.User != null) && (!String.IsNullOrEmpty(Context.User.Identity.Name)))
            {
                String username = Context.User.Identity.Name;

                //Guardo el usuario en el Context.
                Bol.Usuario u = new Bol.Usuario();
                u = new Bol.Usuario().GetUsuarioByEmail(username);
                Context.Items.Add("Usuario", u);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}