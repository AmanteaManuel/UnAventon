using Bol.Core;
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

                    List<Provincia> provincias = new List<Provincia>();
                    provincias = Provincia.GetAll();

                    LoadDropDownList(ddlProvDestino, provincias, "Descripcion", "ID", "Seleccione...");
                    LoadDropDownList(ddlProvSalida, provincias, "Descripcion", "ID", "Seleccione...");



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

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            if ((ddlCiudadDestino.SelectedIndex != 0) && (ddlCiudadSalida.SelectedIndex != 0))
            {
                DateTime fechaActual = DateTime.Now;
                DateTime fechaUnMes = fechaActual.AddMonths(1);

                List<Bol.Viaje> viajes = Bol.Viaje.GetAllByFiltrosAndNowToOneMonth(Convert.ToInt32(ddlCiudadDestino.SelectedValue), Convert.ToInt32(ddlCiudadSalida.SelectedValue), fechaActual, fechaUnMes);

                rptViajes.DataSource = viajes;
                rptViajes.DataBind();
            }
        }

        protected void ddlProvSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvSalida.SelectedIndex > 0)
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                ciudades = Ciudad.GetAllByProvinciaId(Convert.ToInt32(ddlProvSalida.SelectedValue));
                LoadDropDownList(ddlCiudadSalida, ciudades, "Descripcion", "ID", "Seleccione...");
                upBusqueda.Update();
            }
        }

        protected void ddlProvDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvDestino.SelectedIndex > 0)
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                ciudades = Ciudad.GetAllByProvinciaId(Convert.ToInt32(ddlProvDestino.SelectedValue));
                LoadDropDownList(ddlCiudadDestino, ciudades, "Descripcion", "ID", "Seleccione...");
                upBusqueda.Update();
            }
        }

        private void LoadDropDownList(DropDownList list, object dataSource, string text, string value, string valoramostrarpordefecto)
        {
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataSource = dataSource;
            list.DataBind();

            list.Items.Insert(0, new ListItem(valoramostrarpordefecto, string.Empty));
        }
    }
}