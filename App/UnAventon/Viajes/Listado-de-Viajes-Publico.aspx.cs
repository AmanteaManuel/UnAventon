using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Listado_de_Viajes_Publico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DateTime fechaActual = DateTime.Now;
                    DateTime fechaUnMes = fechaActual.AddMonths(1);

                    List<Bol.Viaje> viajes = new Bol.Viaje().GetAllFromNowToOneMonth(fechaActual, fechaUnMes);

                    //Bindeo el objeto
                    rptViajes.DataSource = viajes;
                    rptViajes.DataBind();

                    hlregsitrarse.NavigateUrl = "~/Usuario/alta-Usuario.aspx";
                }
                catch (Exception ex)
                {
                    HtmlGenericControl divalert = (HtmlGenericControl)Page.Master.FindControl("divMsjAlerta");
                    divalert.Visible = true;
                    Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                    lialert.Text = "Error al listar Viajes: " + ex.Message;
                }

            }
        }
    }
}