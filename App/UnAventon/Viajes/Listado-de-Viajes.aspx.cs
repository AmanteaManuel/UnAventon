using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Listado_de_Viajes : UnAventonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
              
            }            
        }

        protected void rptViajes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaUnMes = fechaActual.AddMonths(1);
            List<Bol.Viaje> viajes = new Bol.Viaje().GetAllFromNowToOneMonth(fechaActual, fechaUnMes);
            rptViajes.DataSource = viajes;
            rptViajes.DataBind();            
        }
    }
}