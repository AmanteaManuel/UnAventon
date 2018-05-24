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
                //No hacer esto NUNCA
                rptViajes.DataSource = new Dal.Core.Viaje().GetAll();
                rptViajes.DataBind();
            }            
        }
    }
}