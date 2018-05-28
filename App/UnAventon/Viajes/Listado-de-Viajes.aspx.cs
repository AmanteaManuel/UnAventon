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


                    #region " Pruebas "

                    //List<Bol.Viaje> viajes = new List<Bol.Viaje>();
                    //Bol.Viaje v1 = new Bol.Viaje().GetInstanceById(1);
                    //Bol.Viaje v2 = new Bol.Viaje().GetInstanceById(6);
                    //Bol.Viaje v3 = new Bol.Viaje().GetInstanceById(1014);
                    //Bol.Viaje v4 = new Bol.Viaje().GetInstanceById(1015);
                    //viajes.Add(v1);
                    //viajes.Add(v2);
                    //viajes.Add(v3);
                    //viajes.Add(v4);

                    //string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(v1.Id));                    
                    //Response.Redirect("~/Viajes/Ver-Viaje.aspx?id=" + idEncriptado);

                    #endregion                   

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