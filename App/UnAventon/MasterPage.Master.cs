using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            try
            {

                string path = HttpContext.Current.Request.Url.AbsolutePath;

                if (path.Contains("alta-Usuario.aspx"))
                {
                    lbModificarDatos.CssClass = "links not-allowed";
                    lbModificarDatos.Enabled = false;
                }

                if (path.Contains("Publicar-Viaje.aspx"))
                {
                    lbPublicarViaje.Enabled = false;
                    lbPublicarViaje.CssClass = "links not-allowed";
                }

                if (path.Contains("Listado-de-Viajes.aspx"))
                {
                    lbListarViajes.Enabled = false;
                    lbListarViajes.CssClass = "links not-allowed";
                }

                if (path.Contains("Ver-Perfil.aspx"))
                {
                    lbVerPerfil.Enabled = false;
                    lbVerPerfil.CssClass = "links not-allowed";
                }

                if (path.Contains("Agregar-Vehiculo.aspx"))
                {
                    lbRegistrarVehiculo.Enabled = false;
                    lbRegistrarVehiculo.CssClass = "links not-allowed";
                }

                if (path.Contains("Mis-Viajes.aspx"))
                {
                    lbMisViajes.Enabled = false;
                    lbMisViajes.CssClass = "links not-allowed";
                }

                if (path.Contains("AgregarVehiculo.aspx"))
                {
                    lbRegistrarVehiculo.Enabled = false;
                    lbRegistrarVehiculo.CssClass = "links not-allowed";
                }

                if(string.IsNullOrEmpty(ActiveUsuario.FotoPerfil))                
                    ActiveUsuario.FotoPerfil = "~/img/Fotos-Perfil/profile.png";
                           
                imgPerfil.ImageUrl = ActiveUsuario.FotoPerfil;

            }

            catch (Exception)
            {
                //HtmlGenericControl divalert = (HtmlGenericControl)Page.FindControl("divMsjAlerta");
                //divalert.Visible = true;
                //Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                //lialert.Text = "No se pudo obtener el usuario del contexto.";
            }
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
            Response.Redirect("~/Viajes/Publicar-Viaje.aspx");
        }
        protected void lbRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vehiculos/AgregarVehiculo.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            //Session.Abandon();
            ////Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            ////Response.AppendHeader("Cache-Control", "no-store");
            //ActiveUsuario.Id = -1;
            //Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            //Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            //Response.Redirect("~/Home.aspx");

            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Home.aspx", false);
        }

        protected void lbMisViajes_Click(object sender, EventArgs e)
        {            
            Response.Redirect("~/Viajes/Mis-Viajes.aspx");
        }
    }
}