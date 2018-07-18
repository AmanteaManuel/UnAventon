﻿using Bol;
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
        private int choferCalifacacionId;
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
                List<Viaje> viajes = Viaje.GetAllViajesByVehiculoId(id);

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
                    
                }

                if ((v.FechaSalida.AddHours(Convert.ToDouble(v.Duracion))) < DateTime.Now)//el viaje no paso
                {
                    if ((v.EstadoViaje == 2) || (v.EstadoViaje == 3) || (v.EstadoViaje == 4))
                    {

                    }
                    lbCalifiacion.Enabled = false;
                    lbCalifiacion.CssClass = "UpdateButton not-allowed";
                    lbCalifiacion.ToolTip = "El viaje aun no sucedio. ";
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
                    divDatosChofer.Visible = true;
                    Bol.Usuario usuario = new Bol.Usuario().GetInstanceById(id);
                    liEmail.Text = " " + "";
                    liNombre.Text = " " + "";
                    liApellido.Text = " " + "";
                    liReputacion.Text = " " + "";
                }
                if (e.CommandName.ToUpper().Equals("BAJA"))
                {

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lbeliminarCuenta_Click(object sender, EventArgs e)
        {
            Bol.Usuario.EliminarUsuario(ActiveUsuario.Id);
            Response.Redirect("~/Home.aspx");
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
                if (!radioCalificacionBuena.Checked || !radioCalificacionBuena.Checked)
                    throw new Exception("Debe seleccionar una calificación");
                else//esta calificado
                {
                    //si hay al menos una calificaion
                    if (radioCalificacionBuena.Checked || radioCalificacionBuena.Checked)
                    {
                        //si ingreso un comentario
                        if (tbmessage.Text != "")
                        {
                            //sumo calificaion si fue buena     
                            if (radioCalificacionBuena.Checked)
                            {
                                Bol.Usuario.SumarReputacionChofer(choferCalifacacionId);
                                Bol.Usuario.InsertCalificacion(choferCalifacacionId, tbmessage.Text, true);
                            }                                                       
                            else//resto si la calificaion fue mala
                            {
                                Bol.Usuario.RestarReputacionChofer(choferCalifacacionId);
                                Bol.Usuario.InsertCalificacion(choferCalifacacionId, tbmessage.Text, true);
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