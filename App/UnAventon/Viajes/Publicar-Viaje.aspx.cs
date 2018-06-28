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
        public Bol.Viaje Viaje
        {
            get
            {
                object o = ViewState["Viaje"] as object;
                return (o != null) ? (Bol.Viaje)o : null;
            }
            set { ViewState["Viaje"] = value; }
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

        private void LoadDatos(Viaje V)
        {
            //Cargo DDL
            object o = null;
            EventArgs ea = null;
            int ProvDestino = Ciudad.GetById(V.DestinoId).ProvinciaId;
            int ProvSalida = Ciudad.GetById(V.OrigenId).ProvinciaId;
            ddlProvinciaDestino.SelectedValue = ProvDestino.ToString();
            ddlProvinciaSalida.SelectedValue = ProvSalida.ToString();
            ddlProvinciaDestino_SelectedIndexChanged(o,ea);
            ddlProvinciaSalida_SelectedIndexChanged(o, ea);
            ddlCiudadDestino.SelectedValue = V.DestinoId.ToString();
            ddlCiudadSalida.SelectedValue = V.OrigenId.ToString();
            ddlVehiculo.SelectedValue = V.Vehiculo.Id.ToString();

            tbDuracion.Text = V.Duracion;
            tbLugaresDisponibles.Text = V.LugaresDisponibles.ToString();                    
            tbFecha.SelectedDate = V.FechaSalida;
            tbHoraSalida.Text = V.HoraSalida;
            tbPrecio.Text = (V.Precio * V.LugaresDisponibles).ToString();
            tbDescripcion.Text = V.Descripcion;
            ddlTipoViaje.SelectedValue = "1";
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
                lbFecha.Text = "Fecha";

                if (!IsPostBack)
                {
                    // Si es modificacion
                    if (Request.QueryString["id"] != null)
                    {
                        liTitulo.Text = "Modificar Viaje";
                        liSubtitulo.Text = "En esta página podrá modificarun viaje.";

                        string idEncriptado = Request.QueryString["id"];
                        int id = Convert.ToInt32(new Bol.Core.Service.Tools().Desencripta(idEncriptado));
                        int IdDesencriptado = Convert.ToInt32(id);
                        Viaje = new Bol.Viaje().GetInstanceById(IdDesencriptado);
                        PreparePage();
                        ddlTipoViaje.Enabled = false;
                        ddlTipoViaje.Visible = false;
                        LoadDatos(Viaje);
                        btnModificar.Visible = true;
                        btnPublicarViaje.Visible = false;
                        lbFecha.Text = "Fecha";
                    }
                    //si es nueva publicacion
                    else
                    {
                        liTitulo.Text = "Publicar Viaje";
                        liSubtitulo.Text = "En esta página podrá publicar nuevos viajes.";

                        PreparePage();
                        btnPublicarViaje.Visible = true;
                        btnModificar.Visible = false;
                    }
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
                            Viaje.Create(v, ActiveUsuario.Id);
                        }
                    }
                    if (ddlTipoViaje.SelectedValue == "1")
                    {
                        Viaje viaje = new Viaje(
                        Convert.ToInt32(ddlCiudadSalida.SelectedValue),
                        Convert.ToInt32(ddlCiudadDestino.SelectedValue),
                        tbDuracion.Text,
                        Convert.ToInt32(tbLugaresDisponibles.Text),
                        Convert.ToInt32(ddlVehiculo.SelectedValue),
                        tbFecha.SelectedDate,
                        tbHoraSalida.Text,
                        Convert.ToDouble(tbPrecio.Text),
                        tbDescripcion.Text);
                        viaje.Precio = (viaje.Precio / viaje.LugaresDisponibles);

                        Viaje.Create(viaje, ActiveUsuario.Id);
                    }
                    if (ddlTipoViaje.SelectedValue == "3")
                    {
                        //todo validacion
                        Validate("DiasCheck");
                        if (Page.IsValid)
                        {

                            DateTime desde = DateTime.Now;
                            DateTime hasta = tbFecha.SelectedDate;

                            //agregar los dias de la semana segun los chbks
                            List<DayOfWeek> dayOfWeeks =new List<DayOfWeek>();
                            //DayOfWeek[] dias = new DayOfWeek[7];

                            //TODO falta arreglar solo esto.
                            #region " Carga de dias "

                            //cargo los dias en el vector
                            if (cbklunes.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Monday);

                            if (cbkmartes.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Tuesday);

                            if (cbkmiercoles.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Wednesday);                           

                            if (cbkjueves.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Thursday);

                            if (cbkviernes.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Friday);

                            if (cbksabado.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Saturday);

                            if (cbkdomingo.Checked == true)
                                dayOfWeeks.Add(DayOfWeek.Sunday);

                            DayOfWeek[] dias = dayOfWeeks.ToArray();
                            #endregion

                            //obtengo todos los dias para ese periodo de tiempo
                            List<DateTime> fechas = GetDias(desde, hasta, dias);

                            foreach (var f in fechas)
                            {
                                Viaje viaje = new Viaje(
                                Convert.ToInt32(ddlCiudadSalida.SelectedValue),
                                Convert.ToInt32(ddlCiudadDestino.SelectedValue),
                                tbDuracion.Text,
                                Convert.ToInt32(tbLugaresDisponibles.Text),
                                Convert.ToInt32(ddlVehiculo.SelectedValue),
                                f,
                                tbHoraSalida.Text,
                                Convert.ToDouble(tbPrecio.Text),
                                tbDescripcion.Text);
                                viaje.Precio = (viaje.Precio / viaje.LugaresDisponibles);

                                Viaje.Create(viaje, ActiveUsuario.Id);
                            }
                        }
                        else
                            throw new Exception("Debe seleccionar al menos un día de la semana.");

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

        private List<DateTime> GetDias(DateTime desde, DateTime hasta, DayOfWeek[] tipoDias)
        {
            List<DateTime> lsDias = new List<DateTime>();
            for (int i = 0; i < tipoDias.Length; i++)
            {
                var fechaInicial = desde;
                var fechaFinal = hasta;
                var totalDias = (fechaFinal - fechaInicial).TotalDays;
                
                //while(fechaInicial.Year <= fechaFinal.Year && fechaInicial.Month <= fechaFinal.Month && fechaInicial.Day <= fechaFinal.Day)
                while(fechaInicial.Date <= fechaFinal.Date)
                {

                    if (fechaInicial.DayOfWeek == tipoDias[i])
                    {
                        lsDias.Add(fechaInicial);
                    }

                    fechaInicial = fechaInicial.AddDays(1);
                }

            }
            return lsDias;
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
                        lbFecha.Text = "Fecha";
                    }
                    //Ocasional
                    if (ddlTipoViaje.SelectedValue == "1")
                    {
                        divViajesAgregados.Visible = false;
                        btnAgregarViaje.Visible = false;
                        lbFecha.Text = "Fecha";

                    }
                    //Periodico
                    if(ddlTipoViaje.SelectedValue == "3")
                    {
                        divViajesDiarios.Visible = true;
                        divViajesAgregados.Visible = false;
                        btnAgregarViaje.Visible = false;
                        lbFecha.Text = "Fecha Hasta";
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
            tbFecha.CssClass = "nomargin trasnparent-background";            

            if ((tbFecha.SelectedDate.Date == DateTime.MinValue.Date) || tbFecha.SelectedDate < DateTime.Now)
            {
                if(tbFecha.SelectedDate < DateTime.Now)
                {
                    cvFecha.ErrorMessage = "No puede seleccionar una fecha anterior al dia de hoy.";
                }
                args.IsValid = false;
                tbFecha.CssClass = "nomargin trasnparent-background error";
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

        protected void ViajesDiarios_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int dias =0;
            
            if (cbklunes.Checked == true)
                dias++;

            if (cbkmartes.Checked == true)
                dias++;

            if (cbkmiercoles.Checked == true)
                dias++;

            if (cbkjueves.Checked == true)
                dias++;

            if (cbkviernes.Checked == true)
                dias++;

            if (cbksabado.Checked == true)
                dias++;

            if (cbkdomingo.Checked == true)
                dias++;
            
            cvTipoViaje.ErrorMessage = string.Empty;
            if (dias < 1)
            {                
                args.IsValid = false;
                cvTipoViaje.ErrorMessage = "Al menos debe seleccionar un día";
            }
        }
        #endregion

        protected void btnModificar_Click(object sender, EventArgs e)
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
                    Convert.ToInt32(ddlVehiculo.SelectedValue),
                    tbFecha.SelectedDate,
                    tbHoraSalida.Text,
                    Convert.ToDouble(tbPrecio.Text),
                    tbDescripcion.Text);
                    viaje.Precio = (viaje.Precio / viaje.LugaresDisponibles);

                    Bol.Viaje.Update(viaje, Viaje.Id);


                    this.Master.FindControl("divMsjOk").Visible = true;
                    Literal liMensaje = (Literal)this.Master.FindControl("liMsjOK");
                    liMensaje.Text = "Viaje Modificar con éxito";

                    Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
                }
                else
                    throw new Exception("Error al Modificar viaje ");
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }
    }
}