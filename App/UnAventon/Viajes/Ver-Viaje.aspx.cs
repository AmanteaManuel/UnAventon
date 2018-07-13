using System;
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

        protected void Page_Load(object sender, EventArgs e)
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

        private void PreparePage()
        {             
            //si el usuario activo es el dueño del viaje
            if (Viaje.UsuarioId == ActiveUsuario.Id)
            {
                if(DateTime.Now.Date < Viaje.FechaSalida)
                {
                    btnEliminarViaje.Enabled = true;
                    btnEliminarViaje.CssClass = "boton_personalizado";
                    btnEliminarViaje.ToolTip = "";
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

            Bol.Vehiculo v = Viaje.Vehiculo;
            liAuto.Text = v.Marca + " " + v.Modelo + " " + v.Patente;


            List<Bol.Usuario> Postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);
            List<Bol.Usuario> postulantesCargados = new List<Bol.Usuario>();
            if (Postulantes == null || Postulantes.Count <= 0) return;
            int estado;
            foreach (var p in Postulantes)
            {
                estado = p.EstadoViaje;
                Bol.Usuario pos = new Bol.Usuario().GetInstanceById(p.Id);
                pos.EstadoViaje = estado;
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
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                        throw new Exception("El Viaje no tiene asientos libres.");
                }
                if (e.CommandName.ToUpper().Equals("RECHAZAR"))
                {
                    Bol.Usuario.RechazarPostulacion(id, Viaje.Id);
                    Response.Redirect(Request.RawUrl);
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
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        Bol.Usuario.EliminarPostulacion(id, Viaje.Id);
                        Response.Redirect(Request.RawUrl);
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
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
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
                LinkButton lbDatos = (LinkButton)e.Item.FindControl("lbDatos");
                Label liEstado = (Label)e.Item.FindControl("liEstado");

                //si el usuario logueado es igual al usuario que creo el viaje
                if (Viaje.UsuarioId == ActiveUsuario.Id)
                {      
                    liEstado.Visible = true;
                    liEstado.CssClass = "";

                    //Usuario Pendiente
                    if (u.EstadoViaje == 1)
                    {
                        lbDatos.CssClass = "UpdateButton not-allowed";

                        lbRechazar.ToolTip = "El postulante aun no fue evaluado. ";
                        lbDatos.Enabled = false;
                        liEstado.Text = "Pendiente";
                        liEstado.CssClass = "font-Yellow";
                        
                    }

                    //Usuario aceptado
                    if (u.EstadoViaje == 2)
                    {
                        lbAceptar.CssClass = "UpdateButton not-allowed";
                        lbRechazar.CssClass = "DeleteButton not-allowed";

                        lbRechazar.ToolTip = "El postulante ya fue evaluado. ";
                        lbAceptar.ToolTip = "El postulante ya fue evaluado. ";
                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;
                        liEstado.Text = "Aceptado";
                        liEstado.CssClass = "font-Green";
                    }

                    //Usuario Rechazado
                    if (u.EstadoViaje == 3)
                    {
                        lbAceptar.CssClass = "UpdateButton not-allowed";
                        lbRechazar.CssClass = "DeleteButton not-allowed";
                        lbDatos.CssClass = "DeleteButton not-allowed";
                        lbRechazar.ToolTip = "El postulante ya fue evaluado. ";
                        lbAceptar.ToolTip = "El postulante ya fue evaluado. ";

                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;
                        lbDatos.Enabled = false;
                        liEstado.Text = "Rechazado";
                        liEstado.CssClass = "font-Red";
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

        protected void btnResponder_Click(object sender, EventArgs e)
        {

        }

        protected void btnResponder_Click1(object sender, EventArgs e)
        {

        }
    }
}