using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Mis_Viajes : UnAventonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DateTime fechaActual = DateTime.Now;
                    DateTime fechaUnMes = fechaActual.AddMonths(1);

                    List<Bol.Viaje> viajes = new Bol.Viaje().GetAllByUsuarioId(ActiveUsuario.Id);
                    if (viajes == null || viajes.Count <= 0)
                        throw new Exception("El usuario no tiene viajes publicados.");

                    //Bindeo el objeto
                    rptMisViajes.DataSource = viajes;
                    rptMisViajes.DataBind();
                }
                catch (Exception ex)
                {
                    HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                    divalert.Visible = true;
                    Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                    lialert.Text = "Error al listar Viajes: " + ex.Message;
                }

            }
        }


        protected void lbDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void rptViajes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(((LinkButton)e.CommandSource).CommandArgument, out id);

                if (e.CommandName.ToUpper().Equals("DETALLE"))
                {
                    string idenc = new Bol.Core.Service.Tools().Encripta(id.ToString());
                    Response.Redirect(Page.ResolveUrl("~/Viajes/Ver-Viaje.aspx?Id=" + idenc), true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void rptMisViajes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Bol.Viaje v = (Bol.Viaje)e.Item.DataItem;
            if (v == null)
                return;
            
            List<Bol.Core.Postulacion> postulantes = Bol.Core.Postulacion.GetAllPostulacionesByViajeId(v.Id);
            bool SiAdeudaCalificacion = false;
            if (postulantes != null)
            {
                //si alguno de los usuarios no fue calificado
                foreach (var p in postulantes)
                {
                    if (p.SiCalificado == false)
                    {
                        SiAdeudaCalificacion = true;
                        break;
                    }
                }               
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbSiPagado = (Label)e.Item.FindControl("lbSiPagado");
                Label lbSiCalificado = (Label)e.Item.FindControl("lbSiCalificado");

                //si el viaje ya fue pagado
                if (v.SiPagado == true)
                {
                    lbSiPagado.Text = "Pagado";
                    lbSiPagado.CssClass = "font-Green";
                }
                else
                {
                    lbSiPagado.CssClass = "font-Red";
                    lbSiPagado.Text = "Pago Pendiente";
                }

                if (postulantes != null)
                {
                    //si adeuda al menos 1 calificacion
                    if (SiAdeudaCalificacion == true)
                    {
                        lbSiCalificado.Text = "Calificacion Pendiente";
                        lbSiCalificado.CssClass = "font-Red";
                    }
                    else
                    {
                        lbSiCalificado.Text = "Usuarios Calificados";
                        lbSiCalificado.CssClass = "font-Green";
                    }
                }
                else
                {
                    lbSiCalificado.Text = "Sin Postulantes";
                    lbSiCalificado.CssClass = "font-Yellow";
                }
                
            }
        }
    }
}