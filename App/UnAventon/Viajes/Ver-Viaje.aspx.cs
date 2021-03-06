﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Viajes
{
    public partial class Ver_Viaje : UnAventonPage
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

        public String pasajerocalificacionId
        {
            get
            {
                object o = ViewState["pasajerocalificacionId"];
                return (o == null) ? String.Empty : (string)o;
            }
            set
            {
                ViewState["pasajerocalificacionId"] = value;
            }
        }

        public String PreguntaId
        {
            get
            {
                object o = ViewState["PreguntaId"];
                return (o == null) ? String.Empty : (string)o;
            }
            set
            {
                ViewState["PreguntaId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    //oculto los mensajes
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
                            Viaje = new Bol.Viaje().GetInstanceById(IdDesencriptado);
                            PreparePage();


                        }
                        else
                            throw new Exception("Error en la Url. ");
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
        }

        private void PreparePage()
        {             
            //si el usuario activo es el dueño del viaje
            if (Viaje.UsuarioId == ActiveUsuario.Id)
            {
                tbHiddenId.Text = Viaje.Id.ToString();
                btnPregunta.Visible = false;

                if(Viaje.FechaSalida > DateTime.Now)
                    btnPagar.Visible = true;

                if(Viaje.SiPagado == true)
                {
                    btnPagar.Visible = true;
                    btnPagar.CssClass = "boton_personalizado not-allowed";
                    btnPagar.ToolTip = "El viaje ya esta pagado.";
                }

                if(DateTime.Now.Date < Viaje.FechaSalida)
                {
                    btnEliminarViaje.Enabled = true;
                    btnEliminarViaje.CssClass = "boton_personalizado";
                    btnEliminarViaje.ToolTip = "";

                    //si el viaje ya fue eleiminado
                    if(Viaje.SiActivo == false)
                    {
                        btnEliminarViaje.Enabled = false;
                        btnEliminarViaje.CssClass = "boton_personalizado not-allowed";

                        btnModificar.Enabled = false;
                        btnModificar.CssClass = "boton_personalizado not-allowed";

                        btnPagar.Visible = false;

                        btnEliminarViaje.ToolTip = "El viaje ya fue eliminado";
                    }
                }
                else
                {
                    btnEliminarViaje.Enabled = false;
                    btnEliminarViaje.CssClass = "boton_personalizado not-allowed";
                    btnEliminarViaje.ToolTip = "No se puede eliminar un viaje ya ocurrido";
                }

                divPostulacion.Visible = true;                
                btnModificar.Visible = true;
                btnPostularse.Visible = false;
            }
            //si el usuario activo no es el dueño del viaje
            else
            {
                divPostulacion.Visible = false;
                btnEliminarViaje.Visible = false;
                btnModificar.Visible = false;               
                btnPagar.Visible = false;
                tbPreguntar.Visible = true;

                //obtengo postulantes del viaje
                List<Bol.Usuario> postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);

                if(postulantes != null)
                {
                    //si el usuario esta postulado
                    if (postulantes.Exists(x => x.Id == ActiveUsuario.Id))
                    {
                        Bol.Usuario u = Bol.Usuario.GetPostulanteByViajeId(ActiveUsuario.Id, Viaje.Id);

                        btnPostularse.Visible = false;
                        divEstadoPostulacion.Visible = true;

                        //seteo el estado del viaje
                        if (u.EstadoViaje == 1)
                        {
                            liEstado.Text = "Pendiente";
                            liEstado.CssClass = "font-Yellow";
                        }
                        if (u.EstadoViaje == 2)
                        {
                            liEstado.Text = "Aceptado";
                            liEstado.CssClass = "font-Green";
                        }
                        if (u.EstadoViaje == 3)
                        {
                            liEstado.Text = "Rechazado";
                            liEstado.CssClass = "font-Red";
                        }                        
                    }

                }
                //si el usuario no esta postulado
                else
                {
                    btnPostularse.Visible = true;
                    divEstadoPostulacion.Visible = false;
                }
            }          
            
            divDatosUsuario.Visible = false;
            liCudadOrigen.Text = Viaje.Origen.Descripcion;
            liCiudadDestino.Text = Viaje.Destino.Descripcion;
            liPrecio.Text = Viaje.Precio.ToString();
            liPrecioTotal.Text = (Viaje.Precio * Convert.ToDouble(Viaje.LugaresDisponibles)).ToString();
            if (Viaje.Descripcion != "")
            {
                divDescripcion.Visible = true;
                tbComentario.Text = Viaje.Descripcion;
            }
            else
                divDescripcion.Visible = false;

            liDuracion.Text = Viaje.Duracion;
            liFecha.Text = Viaje.FechaSalida.Date.ToShortDateString();
            liHora.Text = Viaje.HoraSalida;
            liLugares.Text = Viaje.LugaresDisponibles.ToString();
            liLugaresDisponibles.Text = Viaje.LugaresDisponiblesActual.ToString();

            if(Viaje.SiActivo)
            {
                liEstadoDelViaje.Text = "Activo";
                liEstadoDelViaje.CssClass = "font-Green";
            }
            else
            {
                liEstadoDelViaje.Text = "Eliminado";
                liEstadoDelViaje.CssClass = "font-Red";
            }

            if(Viaje.SiPagado)
            {
                liPagado.Text = "Pagado";
                liPagado.CssClass = "font-Green";
            }
            else
            {
                liPagado.Text = "Adeuda Pago";
                liPagado.CssClass = "font-Red";
            }

            Bol.Vehiculo v = Viaje.Vehiculo;
            liAuto.Text = v.Marca + " " + v.Modelo + " " + v.Patente;



            List<Bol.Pregunta> preguntas = Bol.Pregunta.GetAllByViajeId(Viaje.Id);
            if (preguntas != null && preguntas.Count > 0)
            {
                rptPreguntas.DataSource = preguntas;
                rptPreguntas.DataBind();
            }

            List<Bol.Usuario> Postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);
            List<Bol.Usuario> postulantesCargados = new List<Bol.Usuario>();

            if (Postulantes == null || Postulantes.Count <= 0) return;
            int estado;
            bool siCalificado;
            bool siCalifico;
            foreach (var p in Postulantes)
            {
                estado = p.EstadoViaje;
                siCalificado = p.SiCalificado;
                siCalifico = p.SiCalifico;

                Bol.Usuario pos = new Bol.Usuario().GetInstanceById(p.Id);
                pos.EstadoViaje = estado;
                pos.SiCalificado = siCalificado;
                pos.SiCalifico = siCalifico;
                postulantesCargados.Add(pos);
            }

            rptListaPostulantes.DataSource = postulantesCargados;
            rptListaPostulantes.DataBind();
        }

        protected void rptListaPostulantes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(((LinkButton)e.CommandSource).CommandArgument, out id);                

                if (e.CommandName.ToUpper().Equals("ACEPTAR"))
                {
                    Bol.Usuario u = Bol.Usuario.GetPostulanteByViajeId(id, Viaje.Id);

                    if (Viaje.LugaresDisponiblesActual > 0)
                    {
                        Bol.Usuario.AceptarPostulacion(id, Viaje.Id);
                        Bol.Viaje.RestarUnLUgar(Viaje.Id);
                        upGeneral.Update();
                        Response.Redirect(Request.RawUrl); // agregue esto por las dudas haya cagado algo
                    }
                    else
                        throw new Exception("El Viaje no tiene asientos libres.");
                    
                }
                if (e.CommandName.ToUpper().Equals("RECHAZAR"))
                {
                    Bol.Usuario.RechazarPostulacion(id, Viaje.Id);
                    upGeneral.Update();
                    Response.Redirect(Request.RawUrl); // agregue esto por las dudas haya cagado algo
                }

                if (e.CommandName.ToUpper().Equals("ELIMINAR"))
                {
                    Bol.Usuario u = Bol.Usuario.GetPostulanteByViajeId(id, Viaje.Id);
                    //Aceptado
                    if (u.EstadoViaje == 2)
                    {

                        Bol.Usuario.EliminarPostulacion(id, Viaje.Id);
                        Bol.Viaje.SumarUnLUgar(Viaje.Id);
                        Bol.Usuario.RestarReputacionChofer(ActiveUsuario.Id);
                        upGeneral.Update();
                        Response.Redirect(Request.RawUrl); // agregue esto por las dudas haya cagado algo
                    }
                    else
                    {
                        Bol.Usuario.EliminarPostulacion(id, Viaje.Id);
                        upGeneral.Update();
                        Response.Redirect(Request.RawUrl); // agregue esto por las dudas haya cagado algo
                    }
                                     
                }
                if (e.CommandName.ToUpper().Equals("DATOS"))
                {
                    divDatosUsuario.Visible = true;
                    Bol.Usuario usuario = new Bol.Usuario().GetInstanceById(id);
                    liEmail.Text = " " + usuario.Email;
                    liNombre.Text = " "+usuario.Nombre;
                    liApellido.Text = " " + usuario.Apellido;
                    liReputacion.Text = " " + Convert.ToString(usuario.ReputacioPasajero);                    
                }
                if (e.CommandName.ToUpper().Equals("CALIFICACION"))
                {                   
                    pasajerocalificacionId = id.ToString();
                    ScriptManager.RegisterStartupScript(upGeneral, upGeneral.GetType(), "id", "Calificacion()",true);
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
        private void Ejecutar()
        {
           
            ClientScript.RegisterStartupScript(GetType(), "id", "Calificacion()", true);
        }

        protected void rptListaPostulantes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Bol.Usuario u = (Bol.Usuario)e.Item.DataItem;
            if (u == null)
                return;            
            //if (e.Item.ItemType == ListItemType.Header)
            //{
            //    HtmlGenericControl divAccionesPostulacioncol = (HtmlGenericControl)e.Item.FindControl("divAccionesPostulacioncol");

            //    if (Viaje.UsuarioId == ActiveUsuario.Id)
            //        divAccionesPostulacioncol.Visible = true;
            //    else
            //        divAccionesPostulacioncol.Visible = false;
            //}

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {   
                LinkButton lbAceptar = (LinkButton)e.Item.FindControl("lbAceptar");
                LinkButton lbRechazar = (LinkButton)e.Item.FindControl("lbRechazar");
                LinkButton lbEliminar = (LinkButton)e.Item.FindControl("lbEliminar"); //Agruegue esto 
                LinkButton lbDatos = (LinkButton)e.Item.FindControl("lbDatos");
                Label liEstado = (Label)e.Item.FindControl("liEstado"); 
                LinkButton lbCalifiacion = (LinkButton)e.Item.FindControl("lbCalifiacion");

                //si el usuario logueado es igual al usuario que creo el viaje
                if (Viaje.UsuarioId == ActiveUsuario.Id)
                {
                    liEstado.Visible = true;
                    liEstado.CssClass = "";

                    //Usuario Pendiente
                    if (u.EstadoViaje == 1)
                    {
                        lbDatos.CssClass = "UpdateButton not-allowed";
                        lbDatos.ToolTip = "No se pueden ver los datos de un usuario Pendiente";
                        lbDatos.Enabled = false;

                        liEstado.Text = "Pendiente";
                        liEstado.CssClass = "font-Yellow";

                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "No se puede calificar un pasajero que no fue Aceptado. ";

                    }

                    //Usuario aceptado
                    if (u.EstadoViaje == 2)
                    {
                        lbAceptar.CssClass = "UpdateButton not-allowed";
                        lbRechazar.CssClass = "DeleteButton not-allowed";
                        lbRechazar.ToolTip = "El postulante ya fue Aceptado. ";
                        lbAceptar.ToolTip = "El postulante ya fue Aceptado. ";
                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;

                        liEstado.Text = "Aceptado";
                        liEstado.CssClass = "font-Green";

                        if (u.SiCalificado)
                        {
                            lbCalifiacion.Enabled = false;
                            lbCalifiacion.CssClass = "UpdateButton not-allowed";
                            lbCalifiacion.ToolTip = "El usuario ya fue calificado. ";
                        }
                    }
                    //Usuario Rechazado
                    if (u.EstadoViaje == 3)
                    {
                        lbAceptar.CssClass = "UpdateButton not-allowed";
                        lbAceptar.ToolTip = "El postulante ya fue Rechazado. ";

                        lbRechazar.CssClass = "DeleteButton not-allowed";
                        lbRechazar.ToolTip = "El postulante ya fue Rechazado. ";

                        lbEliminar.CssClass = "DeleteButton not-allowed";  //Agregue esto


                        lbDatos.CssClass = "DeleteButton not-allowed";

                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;
                        lbEliminar.Enabled = false;                       //Agregue esto
                        lbDatos.Enabled = false;
                        liEstado.Text = "Rechazado";
                        liEstado.CssClass = "font-Red";

                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "No se puede calificar un pasajero rechazado. ";
                    }
                    //Usuario Eliminado
                    if (u.EstadoViaje == 4)
                    {

                        lbAceptar.CssClass = "UpdateButton not-allowed";
                        lbAceptar.ToolTip = "El postulante fue Eliminado. ";

                        lbRechazar.CssClass = "DeleteButton not-allowed";
                        lbRechazar.ToolTip = "El postulante fue Eliminado. ";

                        lbEliminar.CssClass = "DeleteButton not-allowed";
                        lbEliminar.ToolTip = "El postulante ya fue Eliminado";  // Agregue esto

                        lbDatos.CssClass = "DeleteButton not-allowed";

                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;
                        lbEliminar.Enabled = false;                                     //Agregue esto
                        lbDatos.Enabled = false;
                        liEstado.Text = "Eliminado";
                        liEstado.CssClass = "font-Red";

                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "No se puede calificar un pasajero Eliminado. ";

                    }
                    if ((Viaje.FechaSalida.AddHours(Convert.ToDouble(Viaje.Duracion))) > DateTime.Now)//el viaje no paso
                    {
                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "El viaje aun no sucedio. ";
                    }
                }              
            }
        }

        protected void btnEliminarViaje_Click(object sender, EventArgs e)
        {
            List<Bol.Usuario> postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);
            //si no hay postulantes en el viaje
            if(postulantes != null)
            {
                //elimino los postulantes del viaje
                foreach (var p in postulantes)
                {
                    Bol.Usuario.EliminarPostulacion(p.Id,Viaje.Id);
                }
                //bajo la reputacion del usuario
                Bol.Usuario.RestarReputacionChofer(ActiveUsuario.Id);
                //borro viaje
                Bol.Viaje.Delete(Viaje.Id);
                Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
            }
            //si hay postulantes en el viaje
            else
            {
                Bol.Viaje.Delete(Viaje.Id);
                Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
            }              
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Bol.Usuario> Postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);
                if (Postulantes == null)
                {
                    string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(Viaje.Id));
                    Response.Redirect("~/Viajes/Publicar-Viaje.aspx?id=" + idEncriptado);
                }
                else
                    throw new Exception("El viaje ya tiene postulantes. ");
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        protected void btnPostularse_Click(object sender, EventArgs e)
        {
            try
            {
                
                Bol.Usuario Postulante = Bol.Usuario.GetPostulanteByViajeId(ActiveUsuario.Id, Viaje.Id);
                //pregunto si el postulante ya esta postulado
                if (Postulante == null)
                {
                    if(Viaje.LugaresDisponiblesActual > 0)
                    {
                        Bol.Usuario.CreatePostulacion(ActiveUsuario.Id, Viaje.Id);
                        HtmlGenericControl divMsjOk = (HtmlGenericControl)this.Master.FindControl("divMsjOk");
                        divMsjOk.Visible = true;
                        Literal liMsjOk = (Literal)this.Master.FindControl("liMsjOk");
                        liMsjOk.Text = "Postulacion Exitosa";
                        Response.Redirect(Request.RawUrl);                        
                        liMsjOk.Text = "Postulacion Exitosa";
                    }

                    else
                        throw new Exception("El viaje no dispone lugares.");
                }
                else
                    throw new Exception("Ya esta postulado a este viaje.");                
                
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        protected void btnAceptarComentario_Click(object sender, EventArgs e)
        {
            try
            {
                //si no esta calificado
                if (!radioCalificacionBuena.Checked & !radioCalificacionMala.Checked)
                    throw new Exception("Debe seleccionar una calificación");
                else//esta calificado
                { 
                    //si hay al menos una calificaion
                    if (radioCalificacionBuena.Checked | radioCalificacionMala.Checked)
                    {
                        //si ingreso un comentario
                        if (tbmessage.Text != "")
                        {
                            int idpasajero = Convert.ToInt32(pasajerocalificacionId);
                            //sumo calificaion si fue buena 
                            if (radioCalificacionBuena.Checked)
                            {
                                Bol.Usuario.SumarReputacionPasajero(idpasajero);
                                Bol.Usuario.InsertCalificacion(idpasajero, tbmessage.Text,true);
                                Bol.Usuario.SETSiCalificado(Viaje.Id, idpasajero);
                                Bol.Usuario.SETSiCalifico(Viaje.Id, idpasajero);  
                            }                                                          
                            if(radioCalificacionMala.Checked)
                            {
                                Bol.Usuario.RestarReputacionPasajero(idpasajero);
                                Bol.Usuario.InsertCalificacion(idpasajero, tbmessage.Text, true);
                                Bol.Usuario.SETSiCalificado(Viaje.Id, idpasajero);
                                Bol.Usuario.SETSiCalifico(Viaje.Id, idpasajero);
                            }
                               
                        }
                        else
                            throw new Exception("Debe ingresar un comentario");

                        Response.Redirect(Request.RawUrl);
                    }
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

        protected void btnResponder_Click(object sender, EventArgs e)
        {

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {               
                ValidarPago();
                if(Page.IsValid)
                {
                    Bol.Viaje.Pagar(Convert.ToInt32(tbHiddenId.Text));
                    Response.Redirect(Request.RawUrl);
                }
                else
                    throw new Exception("Todos los campos del pago son obligatorios.");
               
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        private void ValidarPago()
        {
            
            tbNombreTarjeta.CssClass = "";
            
            //Nombre
            if (string.IsNullOrEmpty(tbNombreTarjeta.Text))
            {                
                tbNombreTarjeta.CssClass = "error";
                throw new Exception("Ingrese el Nombre de la tarjeta.");
            }

            //Numero
            tbNumeroTarjeta.CssClass = "";
            if (string.IsNullOrEmpty(tbNumeroTarjeta.Text) && Bol.Core.Service.Tools.IsNumber(tbNumeroTarjeta.Text))
            {
                if (tbNumeroTarjeta.Text.Count() != 16)
                {
                    tbNumeroTarjeta.CssClass = "error";
                    throw new Exception("Numero de tarjeta invalido.");                    
                    
                }
            }

            //Fecha
            tbFechaVencimiento.CssClass = "";
            string[] vectorfecha = new string[2];
            DateTime fechaVencimiento = DateTime.MinValue.Date;

            if (tbFechaVencimiento.Text != "")
            {
                if (!tbFechaVencimiento.Text.Contains('/'))
                    throw new Exception("Formato de fecha invalido.");
                vectorfecha = tbFechaVencimiento.Text.Split('/');
                fechaVencimiento = new DateTime(Convert.ToInt32("20" + vectorfecha[1]), Convert.ToInt32(vectorfecha[0]), 1);
            }
            else
            {               
                tbFechaVencimiento.CssClass = "error";
                throw new Exception("Ingrese la fecha de vencimiento.");
            }

            if (fechaVencimiento < DateTime.Now)
            {                        
                tbFechaVencimiento.CssClass = "error";
                throw new Exception("La tarjeta esta vencida");
            }

            tbCodigoSeguridad.CssClass = "";

            if (string.IsNullOrEmpty(tbCodigoSeguridad.Text) && Bol.Core.Service.Tools.IsNumber(tbCodigoSeguridad.Text))
            {
                if (tbCodigoSeguridad.Text.Count() != 3)
                {
                    tbCodigoSeguridad.CssClass = "error";
                    throw new Exception("Codigo incorrecto, debe ser numero y de 3 digitos");
                }
            }

            ddlBanco.CssClass = "";          

            if (ddlBanco.SelectedIndex <= 0)
            {                
                ddlBanco.CssClass = "error";
                throw new Exception("Debe elegir un banco.");
            }            
        }

        protected void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            tbNombreTarjeta.Text = "";
            tbNumeroTarjeta.Text = "";
            ddlBanco.SelectedIndex = 0;
            tbFechaVencimiento.Text = "";
            tbCodigoSeguridad.Text = "";
        }


        protected void rptPreguntas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                //id de la pregunta
                int id;
                int.TryParse(((LinkButton)e.CommandSource).CommandArgument, out id);

                if (e.CommandName.ToUpper().Equals("RESPUESTA"))
                {
                    Bol.Respuesta respuesta = new Bol.Respuesta();

                    respuesta.Fecha = DateTime.Now;
                    respuesta.UsuarioId = ActiveUsuario.Id;
                    PreguntaId = id.ToString();

                    ScriptManager.RegisterStartupScript(rptPreguntas, rptPreguntas.GetType(), "id", "Responder()", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rptPreguntas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Bol.Pregunta pregunta = (Bol.Pregunta)e.Item.DataItem;
            if (pregunta == null)
                return;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {                
                Label lbPregunta = (Label)e.Item.FindControl("lbPregunta");
                Label lbRespuesta = (Label)e.Item.FindControl("lbRespuesta");
                LinkButton btnResponder = (LinkButton)e.Item.FindControl("lbResponder");

                btnResponder.Visible = false;
                lbPregunta.Text = pregunta.Descripcion;

                //si tiene respuesta
                if (pregunta.RespuestaId != null)
                {
                    Bol.Respuesta respuesta = Bol.Respuesta.GetInstanceById(pregunta.RespuestaId);
                    lbRespuesta.Text = respuesta.Descripcion;
                    btnResponder.Visible = false;
                }
                else
                {
                    lbRespuesta.Text = "";
                    if (ActiveUsuario.Id == Viaje.UsuarioId)
                        btnResponder.Visible = true; 
                }
            }

        }

        /// <summary>
        /// abro script pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagar_Click1(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "id", "Pago()", true);
        }

        /// <summary>
        /// abro modal pregunta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPregunta_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "id", "Preguntar()", true);
        }


        /// <summary>
        /// evento que la respuesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptarRespuesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbResponder.Text != "")
                {
                    Bol.Respuesta respuesta = new Bol.Respuesta();
                    respuesta.Descripcion = tbResponder.Text;
                    respuesta.Fecha = DateTime.Now;
                    respuesta.UsuarioId = ActiveUsuario.Id;
                    respuesta.PreguntaId = Convert.ToInt32(PreguntaId);

                    Bol.Respuesta.Create(respuesta);
                    Response.Redirect(Request.RawUrl);
                }
                else
                    throw new Exception("Ingrese un texto a Responder.");

            }


            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
        }

        /// <summary>
        /// evento que ejhecuta la pregunta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPreguntar.Text != "")
                {
                    Bol.Pregunta pregunta = new Bol.Pregunta();
                    pregunta.Descripcion = tbPreguntar.Text;
                    pregunta.Fecha = DateTime.Now;
                    pregunta.UsuarioId = ActiveUsuario.Id;
                    pregunta.ViajeId = Viaje.Id;

                    Bol.Pregunta.Create(pregunta);
                    Response.Redirect(Request.RawUrl);
                }
                else
                    throw new Exception("Ingrese un texto a Preguntar.");

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