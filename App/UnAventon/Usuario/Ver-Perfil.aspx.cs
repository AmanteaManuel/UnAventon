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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!Page.IsPostBack)
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

            #endregion

            #region " Autos "

            List<Bol.Vehiculo> vehiculos = Bol.Vehiculo.GetAllByUsuarioId(ActiveUsuario.Id);
            rptVehiculos.DataSource = vehiculos;
            rptVehiculos.DataBind();

            #endregion
        }

        protected void btnBorraVehiculo_Click(object sender, EventArgs e)
        {

        }
    }
}