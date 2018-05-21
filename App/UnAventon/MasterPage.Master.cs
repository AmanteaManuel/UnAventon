using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnAventon
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            //string userName = HttpContext.Current.User.Identity.Name;
        }

        protected void lbVerPerfil_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbCrearViaje_Click(object sender, EventArgs e)
        {

        }

        protected void lbListarViajes_Click(object sender, EventArgs e)
        {

        }

        protected void lbModificarDatos_Click(object sender, EventArgs e)
        {
            //string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(Persona.Id));
            Response.Redirect("alta-Usuario.aspx?id=");
        }
    }
}