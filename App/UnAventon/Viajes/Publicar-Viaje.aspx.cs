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
    public partial class Publicar_Viaje : UnAventonPage
    {
        
        #region " Methods "

        private void PreparePage()
        {
            //Cargo las provincias para cargar los ddl
            List<Provincia> provincias = new List<Provincia>();
            provincias = Provincia.GetAll();
            List<Vehiculo> vehiculos = Vehiculo.GetAllByUsuarioId(1);


            CargarDDLProvincia(provincias, (DropDownList)ddlProvinciaDestino);
            CargarDDLProvincia(provincias, (DropDownList)ddlProvinciaSalida);
            //TODO obtener usuario del contexto y pasarle id del usuario iniciado
            CargarDDLVehiculos(vehiculos, (DropDownList)ddlVehiculo);
        }

        private void CargarDDLProvincia(List<Provincia> lista, DropDownList ddl)
        {
            string[] listaString = new string[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                listaString[i] = lista[i].Descripcion;
            }
            ddl.DataSource = listaString;
            ddl.DataBind();
        }

        private void CargarDDLCiudad(List<Ciudad> lista, DropDownList ddl)
        {
            string[] listaString = new string[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                listaString[i] = lista[i].Descripcion;
            }
            ddl.DataSource = listaString;
            ddl.DataBind();
        }

        private void CargarDDLVehiculos(List<Vehiculo> lista, DropDownList ddl)
        {
            string[] listaString = new string[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                listaString[i] = lista[i].Descripcion;
            }
            ddl.DataSource = listaString;
            ddl.DataBind();
        }

        #endregion

        #region " Events "

        protected void Page_Load(object sender, EventArgs e)
        {
            PreparePage();
            this.Master.FindControl("divMsjAlerta").Visible = false;
        }       

        protected void btnPublicarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (Page.IsValid)
                {

                    Viaje viaje = new Viaje(
                        1,//Convert.ToInt32(ddlCiudadSalida.SelectedIndex),
                        2,//Convert.ToInt32(ddlCiudadDestino.SelectedIndex), 
                        tbDuracion.Text,
                        Convert.ToInt32(tbLugaresDisponibles.Text),
                        1,//ddlVehiculo.SelectedIndex,
                        tbFecha.SelectedDate,
                        tbHoraSalida.Text,
                        Convert.ToDouble(tbPrecio.Text),
                        tbDescripcion.Text);

                    Viaje.Create(viaje);

                    this.Master.FindControl("divMsjOk").Visible = true;
                    Literal liMensaje = (Literal)this.Master.FindControl("liMsjOK");
                    liMensaje.Text = "Viaje publicado con éxito";
                }
            }
            catch (Exception ex)
            {
                this.Master.FindControl("divMsjAlerta").Visible = true;
                Literal liMensaje = (Literal)this.Master.FindControl("liMensajeAlerta");
                liMensaje.Text = "Error al publicar viaje " + ex.Message;
            }
        }

        //cuando se produice un cambio en las provincias se refresca las ciudades cargadas
        protected void ddlProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaDestino.SelectedIndex > 0)
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                ciudades = Ciudad.GetAllByProvinciaId(ddlProvinciaDestino.SelectedIndex);
                CargarDDLCiudad(ciudades, (DropDownList)ddlCiudadDestino);
                // upDestinos.Update();
            }
        }

        //cuando se produice un cambio en las provincias se refresca las ciudades cargadas
        protected void ddlProvinciaSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaSalida.SelectedIndex > 0)
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                ciudades = Ciudad.GetAllByProvinciaId(ddlProvinciaSalida.SelectedIndex);
                CargarDDLCiudad(ciudades, (DropDownList)ddlCiudadSalida);
                //upDestinos.Update();

            }
        }

        #endregion

        #region " Validation "



        #endregion
    }
}