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

        /// <summary>
        /// Usuario activo en el contexto de la aplicacion.
        /// </summary>
        protected Bol.Usuario @ActiveUsuario
        {
            get
            {
                if (Context.Items["Usuario"] != null)
                    return (Bol.Usuario)Context.Items["Usuario"];
                throw new Exception("No se pudo obtener el usuario del contexto.");
            }
        }

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
            Response.Redirect("~/Usuario/alta-Usuario.aspx?id=");
        }

        protected void lbPublicarViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Viajes/Publicar-Viaje?=");
        }
    }
}