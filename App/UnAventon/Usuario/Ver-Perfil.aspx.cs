using Bol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Usuario
{
    public partial class Ver_Perfil : UnAventonPage
    {
        public String ChoferCalifacacionId
        {
            get
            {
                object o = ViewState["ChoferCalifacacionId"];
                return (o == null) ? String.Empty : (string)o;
            }
            set
            {
                ViewState["ChoferCalifacacionId"] = value;
            }
        }

        public String ViajeACalificarId
        {
            get
            {
                object o = ViewState["ViajeACalificarId"];
                return (o == null) ? String.Empty : (string)o;
            }
            set
            {
                ViewState["ViajeACalificarId"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PreparePage();
                }
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = "Error al Cargar el Perfil: " + ex.Message;
            }
        }

        private void PreparePage()
        {
            #region " Datos Personales "

            liApellido.Text = ActiveUsuario.Apellido;
            liNombre.Text = ActiveUsuario.Nombre;
            liDni.Text = ActiveUsuario.Dni;
            liEmail.Text = ActiveUsuario.Email;
            liReputacionChofer.Text = ActiveUsuario.ReputacionChofer.ToString();
            liReputacionPasajero.Text = ActiveUsuario.ReputacioPasajero.ToString();
            liFechaNacimiento.Text = ActiveUsuario.FechaNacimiento.ToString("dd/MM/yyyy");

            #endregion

            #region " Autos "

            List<Bol.Vehiculo> vehiculos = Bol.Vehiculo.GetAllByUsuarioId(ActiveUsuario.Id);
            rptVehiculos.DataSource = vehiculos;
            rptVehiculos.DataBind();

            #endregion

            List<Bol.Viaje> postulaciones = Bol.Viaje.GetPostulacionesByUsuarioId(ActiveUsuario.Id);
            rptPostulaciones.DataSource = postulaciones;
            rptPostulaciones.DataBind();

            divDatosChofer.Visible = false;


        }

        protected void rptVehiculos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(((LinkButton)e.CommandSource).CommandArgument, out id);
                List<Viaje> viajes = Viaje.GetAllViajesByVehiculoIdValidator(id);

                if (e.CommandName.ToUpper().Equals("DELETE"))
                {

                    if (viajes == null)
                    {
                        Bol.Vehiculo.Delete(id);
                        string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(@ActiveUsuario.Id));
                        Response.Redirect("~/Usuario/Ver-Perfil.aspx?id=" + idEncriptado);
                    }
                    else
                        throw new Exception("El vehiculo Tiene Viajes en curso. ");
                }
                if (e.CommandName.ToUpper().Equals("UPDATE"))
                {
                    if (viajes == null)
                    {
                        string idEncriptado = new Bol.Core.Service.Tools().Encripta(Convert.ToString(id));
                        Response.Redirect("~/Vehiculos/AgregarVehiculo.aspx?id=" + idEncriptado);
                    }
                    else
                        throw new Exception("El vehiculo Tiene Viajes en curso. ");

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

        protected void rptPostulaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Bol.Viaje v = (Bol.Viaje)e.Item.DataItem;
                if (v == null)
                    return;

                Label liEstado = (Label)e.Item.FindControl("liEstado");
                LinkButton lbCalifiacion = (LinkButton)e.Item.FindControl("lbCalifiacion");
                LinkButton lbDatos = (LinkButton)e.Item.FindControl("lbDatos");
                LinkButton lbBaja = (LinkButton)e.Item.FindControl("lbBaja");
                Bol.Core.Postulacion postulacion = Bol.Core.Postulacion.GetByViajeANDusuarioId(ActiveUsuario.Id, v.Id);

                if (v.EstadoViaje == 1)
                {
                    liEstado.Text = "Pendiente";
                    liEstado.CssClass = "font-Yellow";

                    lbDatos.Enabled = false;
                    lbDatos.CssClass = "UpdateButton not-allowed";

                    lbCalifiacion.Enabled = false;
                    lbCalifiacion.CssClass = "UpdateButton not-allowed";

                }
                if (v.EstadoViaje == 2)
                {
                    liEstado.Text = "Aceptado";
                    liEstado.CssClass = "font-Green";
                    if(postulacion.SiCalifico)
                    {
                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "el chofer ya fue calificado";

                    }
                }
                if (v.EstadoViaje == 3)
                {
                    liEstado.Text = "Rechazado";
                    liEstado.CssClass = "font-Red";
                    lbDatos.Enabled = false;
                    lbDatos.CssClass = "UpdateButton not-allowed";

                    lbCalifiacion.Enabled = false;
                    lbCalifiacion.CssClass = "UpdateButton not-allowed";
                }
                if (v.EstadoViaje == 4)
                {
                    liEstado.Text = "Eliminado";
                    liEstado.CssClass = "font-Red";

                    lbDatos.Enabled = false;
                    lbDatos.CssClass = "UpdateButton not-allowed";

                    lbCalifiacion.Enabled = false;
                    lbCalifiacion.CssClass = "UpdateButton not-allowed";

                    lbBaja.Enabled = false;
                    lbBaja.CssClass = "UpdateButton not-allowed";
                }

                if ((v.FechaSalida.AddHours(Convert.ToDouble(v.Duracion))) > DateTime.Now)//el viaje no paso
                {
                    lbCalifiacion.Enabled = false;
                    lbCalifiacion.CssClass = "UpdateButton not-allowed";
                    lbCalifiacion.ToolTip = "El viaje aun no sucedio. ";
                }
                else//el viaje ya ocurrio
                {
                    if (v.EstadoViaje == 2)//si  fue aceptado
                    {
                        if (!postulacion.SiCalifico)
                        {
                            lbCalifiacion.Enabled = true;
                            lbCalifiacion.CssClass = "UpdateButton";
                        }
                        else
                        {
                            lbCalifiacion.Enabled = false;
                            lbCalifiacion.CssClass = "UpdateButton not-allowed";
                            lbCalifiacion.ToolTip = "El Chofer ya fue calificado. ";
                        }
                    }
                    else//si no fue aceptado
                    {
                        lbCalifiacion.Enabled = false;
                        lbCalifiacion.CssClass = "UpdateButton not-allowed";
                        lbCalifiacion.ToolTip = "Solo los usuarios que realizaron el viaje pueden calificar. ";
                    }
                }
            }
        }

        protected void rptPostulaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                if (e.CommandName.ToUpper().Equals("DATOS"))
                {
                    Bol.Viaje viaje = new Viaje().GetInstanceById(id);


                    divDatosChofer.Visible = true;
                    Bol.Usuario usuario = new Bol.Usuario().GetInstanceById(viaje.UsuarioId);
                    liEmail.Text = " " + "";
                    liNombre.Text = " " + "";
                    liApellido.Text = " " + "";
                    liReputacion.Text = " " + "";
                }
                if (e.CommandName.ToUpper().Equals("BAJA"))
                {
                    Bol.Viaje viaje = new Viaje().GetInstanceById(id);
                    Bol.Core.Postulacion u = Bol.Core.Postulacion.GetByViajeANDusuarioId(id, viaje.Id);

                    //Aceptado
                    if (u.EstadoViaje == 2)
                    {
                        Bol.Usuario.EliminarPostulacion(id, viaje.Id);
                        Bol.Viaje.SumarUnLUgar(viaje.Id);
                        Bol.Usuario.RestarReputacionPasajero(ActiveUsuario.Id);
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        Bol.Usuario.EliminarPostulacion(id, viaje.Id);
                        Response.Redirect(Request.RawUrl);
                    }
                }
                if (e.CommandName.ToUpper().Equals("CALIFICACION"))
                {
                    Bol.Viaje v = new Viaje().GetInstanceById(id);
                    ChoferCalifacacionId = v.UsuarioId.ToString();
                    ViajeACalificarId = v.Id.ToString();
                    ClientScript.RegisterStartupScript(GetType(), "id", "Calificacion()", true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lbeliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Bol.Usuario.EliminarUsuario(ActiveUsuario.Id);
                Response.Redirect("~/Home.aspx");
            }
            catch (Exception ex)
            {

                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;
            }
            
        }

        protected void rptVehiculos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {                
                Bol.Vehiculo v = (Bol.Vehiculo)e.Item.DataItem;
                if (v == null)
                    return;

                Label liEstadoVehiculo = (Label)e.Item.FindControl("liEstadoVehiculo");

                if (v.SiActivo == true)
                {
                    liEstadoVehiculo.Text = "Activo";
                    liEstadoVehiculo.CssClass = "font-Green";
                }
                else
                {
                    liEstadoVehiculo.Text = "Eliminado";
                    liEstadoVehiculo.CssClass = "font-Red";
                }
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
                            //sumo calificaion si fue buena     
                            if (radioCalificacionBuena.Checked)
                            {
                                Bol.Usuario.SumarReputacionChofer(Convert.ToInt32(ChoferCalifacacionId));
                                Bol.Usuario.InsertCalificacion(Convert.ToInt32(ChoferCalifacacionId), tbmessage.Text, true);
                                Bol.Usuario.SETSiCalificado(Convert.ToInt32(ViajeACalificarId), ActiveUsuario.Id);
                                Bol.Usuario.SETSiCalifico(Convert.ToInt32(ViajeACalificarId),ActiveUsuario.Id);
                                Response.Redirect(Request.RawUrl);
                            }
                            if (radioCalificacionMala.Checked)//resto si la calificaion fue mala
                            {
                                Bol.Usuario.RestarReputacionChofer(Convert.ToInt32(ChoferCalifacacionId));
                                Bol.Usuario.InsertCalificacion(Convert.ToInt32(ChoferCalifacacionId), tbmessage.Text, true);
                                Bol.Usuario.SETSiCalificado(Convert.ToInt32(ViajeACalificarId), ActiveUsuario.Id);
                                Bol.Usuario.SETSiCalifico(Convert.ToInt32(ViajeACalificarId), ActiveUsuario.Id);
                                Response.Redirect(Request.RawUrl);
                            }
                        }
                        else
                            throw new Exception("Debe ingresar un comentario");
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
    }
}