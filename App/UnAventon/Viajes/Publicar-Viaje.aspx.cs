using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Bol;
using Bol.Core;

namespace UnAventon.Viajes
{
    public partial class Publicar_Viaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PreparePage();

            this.Master.FindControl("divMsjAlerta").Visible = false;
            
        }

        private void CargarDDL(List<Provincia>lista, DropDownList ddl)
        {
            string[] listaString = new string[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                listaString[i] = lista[i].Descripcion;
            }  
            ddl.DataSource = listaString;
            ddl.DataBind();
        }

        private void PreparePage()
        {
            //Cargo las provincias para cargar los ddl
            List<Provincia> provincias = new List<Provincia>();
            provincias = Provincia.GetAll();            
            CargarDDL(provincias, (DropDownList)ddlProvinciaDestino);
            CargarDDL(provincias, (DropDownList)ddlProvinciaSalida);
        }

        protected void btnPublicarViaje_Click(object sender, EventArgs e)
        {

        }

        //cuando se produice un cambio en las provincias se refresca las ciudades cargadas
        protected void ddlProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaDestino.SelectedIndex > 0)
            {
                List<Ciudad> provincias = new List<Ciudad>();
                provincias = Ciudad.GetAllByProvinciaId(ddlProvinciaDestino.SelectedIndex);
                //upDestinos.Update();
            }
        }

        //cuando se produice un cambio en las provincias se refresca las ciudades cargadas
        protected void ddlCiudadSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaSalida.SelectedIndex > 0)
            {
                List<Ciudad> provincias = new List<Ciudad>();
                provincias = Ciudad.GetAllByProvinciaId(ddlProvinciaSalida.SelectedIndex);
                //upDestinos.Update();
            }
        }
    }
}