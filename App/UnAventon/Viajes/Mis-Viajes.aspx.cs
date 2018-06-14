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


                    #region " Pruebas "

                    #endregion                   

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
    }
}