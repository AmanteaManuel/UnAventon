using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Ver_Viaje : UnAventonPage
    {
        public Bol.Viaje Viaje
        {
            get
            {
                object o = ViewState["Viaje"] as object;
                return (o != null) ? (Bol.Viaje)o : null;
            }
            set { ViewState["Viaje"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {                  
                        string idEncriptado = Request.QueryString["id"];
                        int id = Convert.ToInt32(new Bol.Core.Service.Tools().Desencripta(idEncriptado));
                        int IdDesencriptado = Convert.ToInt32(id);
                        Viaje = new Bol.Viaje().GetInstanceById(IdDesencriptado);
                        PreparePage();
                    }
                    else
                        throw new Exception("Error en la Url. ");
                }
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        private void PreparePage()
        {            
            liCudadOrigen.Text = Viaje.Origen.Descripcion;
            liCiudadDestino.Text = Viaje.Destino.Descripcion;
            liPrecio.Text = Viaje.Precio.ToString();
            if (Viaje.Descripcion != "")
            {
                divDescripcion.Visible = true;
                tbComentario.Text = Viaje.Descripcion;
            }
            else
                divDescripcion.Visible = false;

            liDuracion.Text = Viaje.Duracion;
            liFecha.Text = Viaje.FechaSalida.Date.ToShortDateString();
            liHora.Text = Viaje.HoraSalida;
            liLugares.Text = Viaje.LugaresDisponibles.ToString();
            
        }
    }
}