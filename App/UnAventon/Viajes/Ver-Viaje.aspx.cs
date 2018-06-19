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

            if (Viaje.UsuarioId == ActiveUsuario.Id)
                btnEliminarViaje.Visible = true;
            else
                btnEliminarViaje.Visible = false;

            divDatosUsuario.Visible = false;

            liCudadOrigen.Text = Viaje.Origen.Descripcion;
            liCiudadDestino.Text = Viaje.Destino.Descripcion;
            liPrecio.Text = Viaje.Precio.ToString();
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


            List<Bol.Usuario> Postulantes = Bol.Usuario.GetPostulantesByViajeId(Viaje.Id);
            List<Bol.Usuario> postulantesCargados = new List<Bol.Usuario>();
            if (Postulantes == null || Postulantes.Count <= 0) return;
            foreach (var p in Postulantes)
            {
                postulantesCargados.Add(new Bol.Usuario().GetInstanceById(p.Id));
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
                    Bol.Usuario.AceptarPostulacion(id, Viaje.Id);
                }
                if (e.CommandName.ToUpper().Equals("RECHAZAR"))
                {
                    Bol.Usuario.RechazarPostulacion(id, Viaje.Id);
                }

                if (e.CommandName.ToUpper().Equals("ELIMINAR"))
                {
                    Bol.Usuario.EliminarPostulacion(id, Viaje.Id);
                }
                if (e.CommandName.ToUpper().Equals("DATOS"))
                {
                    divDatosUsuario.Visible = true;
                    Bol.Usuario usuario = new Bol.Usuario().GetInstanceById(id);
                    liEmail.Text = usuario.Email;
                    liNombre.Text = usuario.Nombre;
                    liApellido.Text = usuario.Apellido;
                    liReputacion.Text = Convert.ToString(usuario.ReputacioPasajero);

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

            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlGenericControl divAccionesPostulacioncol = (HtmlGenericControl)e.Item.FindControl("divAccionesPostulacioncol");

                if (Viaje.UsuarioId == ActiveUsuario.Id)
                    divAccionesPostulacioncol.Visible = true;
                else
                    divAccionesPostulacioncol.Visible = false;
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {               
                HtmlGenericControl divAccionesPostulacionbtn = (HtmlGenericControl)e.Item.FindControl("divAccionesPostulacionbtn");
                LinkButton lbAceptar = (LinkButton)e.Item.FindControl("lbAceptar");
                LinkButton lbRechazar = (LinkButton)e.Item.FindControl("lbRechazar");
                LinkButton lbDatos = (LinkButton)e.Item.FindControl("lbDatos");

                //si el usuario legueado es igual al usuario que
                if (Viaje.UsuarioId == ActiveUsuario.Id)
                {
                    divAccionesPostulacionbtn.Visible = true;
                    //si el usuario fue aceptado o rechazado bloqueo los botones
                    if(u.EstadoViaje != 2)
                    {
                        lbAceptar.Enabled = false;
                        lbRechazar.Enabled = false;
                    }
                    if (u.EstadoViaje != 1)
                    {
                        lbDatos.Enabled = false;
                    }
                }
                else
                {
                    divAccionesPostulacionbtn.Visible = false;
                }
            }
        }

        protected void btnEliminarViaje_Click(object sender, EventArgs e)
        {
              //obtener los id de usuarios
              //borrar los usuarios
              //borrar viaje
              //descontar puntos 
        }
    }
}