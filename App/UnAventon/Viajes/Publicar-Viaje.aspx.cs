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

        internal List<Bol.Viaje> viajesAgregados
        {
            get
            {
                object o = ViewState["viajesAgregados"] as object;
                return (o != null) ? (List<Viaje>)o : new List<Viaje>();
            }
            set { ViewState["viajesAgregados"] = value; }
        }

        //public List<Bol.Viaje> viajesAgregados;
        

        #region " Methods "

        private void PreparePage()
        {
            viajesAgregados = new List<Viaje>();
            //Cargo las provincias para cargar los ddl
            List<Provincia> provincias = new List<Provincia>();
            provincias = Provincia.GetAll();            

            List<Vehiculo> vehiculos = Vehiculo.GetAllByUsuarioId(ActiveUsuario.Id);

            LoadDropDownList(ddlProvinciaDestino, provincias, "Descripcion", "ID", "Seleccione...");
            LoadDropDownList(ddlProvinciaSalida, provincias, "Descripcion", "ID", "Seleccione...");
            LoadDropDownList(ddlVehiculo, vehiculos, "Modelo", "ID", "Seleccione...");            
        }

        private void LoadDropDownList(DropDownList list, object dataSource, string text, string value, string valoramostrarpordefecto)
        {
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataSource = dataSource;
            list.DataBind();            

            list.Items.Insert(0, new ListItem(valoramostrarpordefecto, string.Empty));
        }

        #endregion

        #region " Events "

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HtmlGenericControl divMsjOk = (HtmlGenericControl)this.Master.FindControl("divMsjOk");
                divMsjOk.Visible = false;
                HtmlGenericControl divMsjAlerta = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divMsjAlerta.Visible = false;

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
                Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
            }

        }

        protected void btnPublicarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("PublicarViaje");
                if (Page.IsValid)
                {
                    //Es un viaje Frecuente
                    if(ddlTipoViaje.SelectedValue == "2")
                    {
                        foreach (var v in this.viajesAgregados)
                        {
                            v.Precio = (v.Precio / v.LugaresDisponibles);
                            Viaje.Create(v);
                        }

                    }
                    else
                    {
                        Viaje viaje = new Viaje(
                        Convert.ToInt32(ddlCiudadSalida.SelectedValue),
                        Convert.ToInt32(ddlCiudadDestino.SelectedValue),
                        tbDuracion.Text,
                        Convert.ToInt32(tbLugaresDisponibles.Text),
                        ddlVehiculo.SelectedIndex,
                        tbFecha.SelectedDate,
                        tbHoraSalida.Text,
                        Convert.ToDouble(tbPrecio.Text),
                        tbDescripcion.Text);

                        viaje.Precio = (viaje.Precio / viaje.LugaresDisponibles);
                        Viaje.Create(viaje);
                    }

                    this.Master.FindControl("divMsjOk").Visible = true;
                    Literal liMensaje = (Literal)this.Master.FindControl("liMsjOK");
                    liMensaje.Text = "Viaje publicado con éxito";

                    Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
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
                ciudades = Ciudad.GetAllByProvinciaId(Convert.ToInt32(ddlProvinciaDestino.SelectedValue));
                LoadDropDownList(ddlCiudadDestino, ciudades, "Descripcion", "ID", "Seleccione...");                
            }
        }

        //cuando se produice un cambio en las provincias se refresca las ciudades cargadas
        protected void ddlProvinciaSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaSalida.SelectedIndex > 0)
            {
                List<Ciudad> ciudades = new List<Ciudad>();                
                ciudades = Ciudad.GetAllByProvinciaId(Convert.ToInt32(ddlProvinciaSalida.SelectedValue));
                LoadDropDownList(ddlCiudadSalida, ciudades, "Descripcion", "ID", "Seleccione...");
                
            }
        }

        protected void ddlTipoViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlTipoViaje.SelectedValue) > Convert.ToInt32("0"))
                {
                    //frecuente
                    if (ddlTipoViaje.SelectedValue == "2")
                    {
                        divViajesAgregados.Visible = true;
                        btnAgregarViaje.Visible = true;
                    }
                    else
                    {
                        divViajesAgregados.Visible = false;
                        btnAgregarViaje.Visible = false;

                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener datos del tipo del viaje. ");
            }

        }

        protected void btnAgregarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("PublicarViaje");
                if (Page.IsValid)
                {
                    Viaje viaje = new Viaje(
                        Convert.ToInt32(ddlCiudadSalida.SelectedValue),
                        Convert.ToInt32(ddlCiudadDestino.SelectedValue),
                        tbDuracion.Text,
                        Convert.ToInt32(tbLugaresDisponibles.Text),
                        ddlVehiculo.SelectedIndex,
                        tbFecha.SelectedDate,
                        tbHoraSalida.Text,
                        Convert.ToDouble(tbPrecio.Text),
                        tbDescripcion.Text);

                    viajesAgregados.Add(viaje);

                    rptViajesAgregados.DataSource = this.viajesAgregados;
                    rptViajesAgregados.DataBind();

                    this.Master.FindControl("divMsjOk").Visible = true;
                    Literal liMensaje = (Literal)this.Master.FindControl("liMsjOK");
                    liMensaje.Text = "Viaje Agregado con éxito";
                }
                else
                    throw new Exception("Error al Agregar viaje. ");
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        #endregion

        #region " Validation "      

        protected void cvProvSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlProvinciaSalida.CssClass = "form-control";
            cvProvSalida.ErrorMessage = string.Empty;

            if (ddlProvinciaSalida.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlProvinciaSalida.CssClass= "form-control error";
            }
        }

        protected void cvCiduadSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlCiudadSalida.CssClass = "form-control";
            cvCiudadDestino.ErrorMessage = string.Empty;

            if (ddlCiudadSalida.SelectedIndex == ddlCiudadDestino.SelectedIndex)
            {
                args.IsValid = false;
                ddlCiudadSalida.CssClass = "form-control error";
            }
        }

        protected void cvProvDestino_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlProvinciaDestino.CssClass = "form-control";
            cvProvDestino.ErrorMessage = string.Empty;

            if (ddlProvinciaDestino.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlProvinciaDestino.CssClass = "form-control error";
            }
        }

        protected void cvCiudadDestino_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlCiudadDestino.CssClass = "form-control";
            cvCiudadDestino.ErrorMessage = string.Empty;

            if (ddlCiudadSalida.SelectedIndex == ddlCiudadDestino.SelectedIndex)
            {
                args.IsValid = false;
                ddlCiudadDestino.CssClass = "form-control error";
            }
        }

        protected void cvDuracion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbDuracion.CssClass = "form-control";
            cvDuracion.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbDuracion.Text))
            {
                args.IsValid = false;
                tbDuracion.CssClass = "form-control error";
            }
        }

        protected void cvLugaresDisponibles_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbLugaresDisponibles.CssClass = "form-control";
            cvLugaresDisponibles.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbLugaresDisponibles.Text))
            {
                args.IsValid = false;
                tbLugaresDisponibles.CssClass = "form-control error";
            }
        }

        protected void cvVehiulo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlVehiculo.CssClass = "form-control";
            cvVehiulo.ErrorMessage = string.Empty;

            if (ddlVehiculo.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlVehiculo.CssClass = "form-control error";
            }
        }

        protected void cvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbFecha.CssClass = "form-control";
            //cvFecha.ErrorMessage = string.Empty;

            if ((tbFecha.SelectedDate.Date == DateTime.MinValue.Date) || tbFecha.SelectedDate < DateTime.Now)
            {
                args.IsValid = false;
                tbFecha.CssClass = "form-control error";
            }
        }

        protected void cvHoraSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbHoraSalida.CssClass = "form-control";
            cvHoraSalida.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbHoraSalida.Text))
            {
                args.IsValid = false;
                tbHoraSalida.CssClass = "form-control error";
            }
        }

        protected void cvPrecio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPrecio.CssClass = "form-control";
            cvPrecio.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPrecio.Text))
            {
                args.IsValid = false;
                tbPrecio.CssClass = "form-control error";
            }
        }

        protected void cvTipoViaje_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ddlTipoViaje.CssClass = "form-control";
            cvTipoViaje.ErrorMessage = string.Empty;

            if (ddlTipoViaje.SelectedIndex <= 0)
            {
                args.IsValid = false;
                ddlTipoViaje.CssClass = "form-control error";
            }
        }

        #endregion
    
    }
}