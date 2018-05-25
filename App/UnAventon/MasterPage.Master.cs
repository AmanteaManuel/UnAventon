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
            string path = HttpContext.Current.Request.Url.AbsolutePath;            

            if (path.Contains("alta-Usuario.aspx"))
                lbModificarDatos.Enabled = false;

            if (path.Contains("Publicar-Viaje.aspx"))
                lbPublicarViaje.Enabled = false;

            if (path.Contains("Listado-de-Viajes.aspx"))
                lbListarViajes.Enabled = false;

            if (path.Contains("Ver-Perfil.aspx"))
                lbVerPerfil.Enabled = false;

        }

        protected void lbVerPerfil_Click(object sender, EventArgs e)
        {
            string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(@ActiveUsuario.Id));
            Response.Redirect("~/Usuario/Ver-Perfil.aspx?id=" + idEncriptado);
        }

        protected void lbListarViajes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
        }

        protected void lbModificarDatos_Click(object sender, EventArgs e)
        {
            string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(@ActiveUsuario.Id));
            Response.Redirect("~/Usuario/alta-Usuario.aspx?id="+ idEncriptado);
        }

        protected void lbPublicarViaje_Click(object sender, EventArgs e)
        {
            string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(@ActiveUsuario.Id));
            Response.Redirect("~/Viajes/Publicar-Viaje.aspx?id=" + idEncriptado);
        }
        protected void lbRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vehiculos/AgregarVehiculo.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("~/Home.aspx");
        }

    }
}