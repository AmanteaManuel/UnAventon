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
        public Bol.Usuario Usuario
        {
            get
            {
                object o = ViewState["Usuario"] as object;
                return (o != null) ? (Bol.Usuario)o : null;
            }
            set { ViewState["Usuario"] = value; }
        }

        #region " Methods "

        private void PreparePage()
        {
            //Cargo las provincias para cargar los ddl
            List<Provincia> provincias = new List<Provincia>();
            provincias = Provincia.GetAll();
            List<Vehiculo> vehiculos = Vehiculo.GetAllByUsuarioId(ActiveUsuario.Id);

            CargarDDLProvincia(provincias, (DropDownList)ddlProvinciaDestino);
            CargarDDLProvincia(provincias, (DropDownList)ddlProvinciaSalida);            
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
            try
            {
                string[] listaString = new string[lista.Count];
                for (int i = 0; i < lista.Count; i++)
                {
                    listaString[i] = lista[i].Descripcion;
                }
                ddl.DataSource = listaString;
                ddl.DataBind();
            }
            catch (Exception)
            {
                throw new Exception("Error al listar vehículos");
            }
            
        }

        #endregion

        #region " Events "

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string idEncriptado = Request.QueryString["id"];
                        int id = Convert.ToInt32(new Bol.Core.Service.Tools().Desencripta(idEncriptado));
                        int IdDesencriptado = Convert.ToInt32(id);
                        Usuario = new Bol.Usuario().GetInstanceById(IdDesencriptado);
                        PreparePage();
                    }
                    else
                        throw new Exception("No hay usuario en el contexto. ");
                }
            }
            catch (Exception ex)
            {

                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;                
            }

        }

        protected void btnPublicarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("PublicarViaje");
                if (Page.IsValid)
                {

                    Viaje viaje = new Viaje(
                        1,//Convert.ToInt32(ddlCiudadSalida.SelectedIndex),
                        2,//Convert.ToInt32(ddlCiudadDestino.SelectedIndex), 
                        tbDuracion.Text,
                        Convert.ToInt32(tbLugaresDisponibles.Text),
                        1007,//ddlVehiculo.SelectedIndex,
                        tbFecha.SelectedDate,
                        tbHoraSalida.Text,
                        Convert.ToDouble(tbPrecio.Text),
                        tbDescripcion.Text);

                    Viaje.Create(viaje);

                    this.Master.FindControl("divMsjOk").Visible = true;
                    Literal liMensaje = (Literal)this.Master.FindControl("liMsjOK");
                    liMensaje.Text = "Viaje publicado con éxito";
                }
                else
                    throw new Exception("Error al publicar viaje ");
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;                            
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

        protected void cvProvSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlProvinciaSalida.Attributes.Add("class", "form-group");
            cvProvSalida.ErrorMessage = string.Empty;

            if (ddlProvinciaSalida.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlProvinciaSalida.Attributes.Add("class", "form-group error");
                ddlProvinciaSalida.CssClass= "form-group error";
            }
        }

        protected void cvCiduadSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlCiudadSalida.Attributes.Add("class", "group ");
            cvCiudadDestino.ErrorMessage = string.Empty;

            if (ddlCiudadSalida.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlCiudadSalida.Attributes.Add("class", "form-group error");
                ddlCiudadSalida.CssClass = "form-group error";
            }
        }

        protected void cvProvDestino_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlProvinciaDestino.Attributes.Add("class", "form-group ");
            cvProvDestino.ErrorMessage = string.Empty;

            if (ddlProvinciaDestino.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlProvinciaDestino.Attributes.Add("class", "form-group error");
                ddlProvinciaDestino.CssClass = "form-group error";
            }
        }

        protected void cvCiudadDestino_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlCiudadDestino.Attributes.Add("class", "form-group ");
            cvCiudadDestino.ErrorMessage = string.Empty;

            if (ddlCiudadDestino.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlCiudadDestino.Attributes.Add("class", "form-group error");
            }
        }

        protected void cvDuracion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbDuracion.Attributes.Add("class", "form-group");
            cvDuracion.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbDuracion.Text))
            {
                args.IsValid = false;
                tbDuracion.Attributes.Add("class", "form-group error");
                tbDuracion.CssClass = "form-group error";
            }
        }

        protected void cvLugaresDisponibles_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbLugaresDisponibles.Attributes.Add("class", "form-group");
            cvLugaresDisponibles.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbLugaresDisponibles.Text))
            {
                args.IsValid = false;
                tbLugaresDisponibles.Attributes.Add("class", "form-group error");
                tbLugaresDisponibles.CssClass = "form-group error";
            }
        }

        protected void cvVehiulo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlVehiculo.Attributes.Add("class", "form-group ");
            cvVehiulo.ErrorMessage = string.Empty;

            if (ddlVehiculo.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlVehiculo.Attributes.Add("class", "form-group error");
                ddlVehiculo.CssClass = "form-group error";
            }
        }

        protected void cvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbFecha.Attributes.Add("class", "form-group");
            //cvFecha.ErrorMessage = string.Empty;

            if (tbFecha.SelectedDate != null || tbFecha.SelectedDate < DateTime.Now)
            {
                args.IsValid = false;
                tbFecha.Attributes.Add("class", "form-group error");
                tbFecha.CssClass = "form-group error";
            }
        }

        protected void cvHoraSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbHoraSalida.Attributes.Add("class", "form-group");
            cvHoraSalida.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbHoraSalida.Text))
            {
                args.IsValid = false;
                tbHoraSalida.Attributes.Add("class", "form-group error");
                tbHoraSalida.CssClass = "form-group error";
            }
        }

        protected void cvPrecio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPrecio.Attributes.Add("class", "form-group");
            cvPrecio.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPrecio.Text))
            {
                args.IsValid = false;
                tbPrecio.Attributes.Add("class", "form-group error");
                tbPrecio.CssClass = "form-group error";
            }
        }

        protected void cvTipoViaje_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlTipoViaje.Attributes.Add("class", "form-group ");
            cvTipoViaje.ErrorMessage = string.Empty;

            if (ddlTipoViaje.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlTipoViaje.Attributes.Add("class", "form-group error");
                ddlTipoViaje.CssClass = "form-group error";
            }
        }

        #endregion
    }
}