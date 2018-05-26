using System;
using System.Collections.Generic;
using System.Globalization;
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
                DateTime fechaActual = DateTime.Now;
                DateTime fechaUnMes = fechaActual.AddMonths(1);

                //List<Bol.Viaje> viajes = new Bol.Viaje().GetAllFromNowToOneMonth(fechaActual, fechaUnMes);

                //borrar es para probar
                #region " prueba "lista" "

                List<Bol.Viaje> viajes = new List<Bol.Viaje>();
                Bol.Viaje v =new Bol.Viaje().GetInstanceById(1);               

                for (int i = 0; i < 4; i++)                                 
                    viajes.Add(v);                 

                #endregion

                //Bindeo el objeto
                rptViajes.DataSource = viajes;
                rptViajes.DataBind();
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