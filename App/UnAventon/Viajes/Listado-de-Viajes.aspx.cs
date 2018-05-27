using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Listado_de_Viajes : UnAventonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    DateTime fechaActual = DateTime.Now;
                    DateTime fechaUnMes = fechaActual.AddMonths(1);

                    List<Bol.Viaje> viajes = new Bol.Viaje().GetAllFromNowToOneMonth(fechaActual, fechaUnMes);

                    //Bindeo el objeto
                    rptViajes.DataSource = viajes;
                    rptViajes.DataBind();
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
        
        protected void rptViajes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {           
        }

        protected void lbDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}