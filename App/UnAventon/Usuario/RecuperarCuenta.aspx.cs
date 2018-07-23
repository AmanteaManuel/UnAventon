using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Usuario
{
    public partial class RecuperarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                HtmlGenericControl divMsjOk = (HtmlGenericControl)this.Master.FindControl("divMsjOk");
                divMsjOk.Visible = false;
                HtmlGenericControl divMsjAlerta = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divMsjAlerta.Visible = false;

                #region " bloqueo de botones "

                LinkButton lbModificarDatos = (LinkButton)this.Master.FindControl("lbModificarDatos");
                LinkButton lbPublicarViaje = (LinkButton)this.Master.FindControl("lbPublicarViaje");
                LinkButton lbListarViajes = (LinkButton)this.Master.FindControl("lbListarViajes");
                LinkButton lbVerPerfil = (LinkButton)this.Master.FindControl("lbVerPerfil");
                LinkButton lbRegistrarVehiculo = (LinkButton)this.Master.FindControl("lbRegistrarVehiculo");
                LinkButton lbMisViajes = (LinkButton)this.Master.FindControl("lbMisViajes");

                lbModificarDatos.CssClass = "links not-allowed";
                lbModificarDatos.Enabled = false;
                lbPublicarViaje.Enabled = false;
                lbPublicarViaje.CssClass = "links not-allowed";
                lbListarViajes.Enabled = false;
                lbListarViajes.CssClass = "links not-allowed";
                lbVerPerfil.Enabled = false;
                lbVerPerfil.CssClass = "links not-allowed";
                lbRegistrarVehiculo.Enabled = false;
                lbRegistrarVehiculo.CssClass = "links not-allowed";
                lbMisViajes.Enabled = false;
                lbMisViajes.CssClass = "links not-allowed";
                lbRegistrarVehiculo.Enabled = false;
                lbRegistrarVehiculo.CssClass = "links not-allowed";

                #endregion



                if (!Page.IsPostBack)
                {
                    //Deja la pagina en blanco(sin datos)
                    ClearPage();
                }

                }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearPage()
        {
            tbContraseniaVieja.Text = string.Empty;
            tbContrasenia.Text = string.Empty;
            tbRepitaContraseña.Text = string.Empty;
            tbFechaNacimiento.Text = string.Empty;         
            tbEmail.Text = string.Empty;
        }

        protected void cvContraseniaVieja_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbContraseniaVieja.CssClass = "form-control";
            cvContraseniaNueva.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbContrasenia.Text))
            {
                args.IsValid = false;
                tbContraseniaVieja.CssClass = "form-control error";
                cvContraseniaVieja.ErrorMessage = "Debe ingresar la contraseña anterior para recuperar la cuenta.";
            }
        }

        protected void cvFechaNacimiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbFechaNacimiento.CssClass = "form-control";
            cvFechaNacimiento.ErrorMessage = string.Empty;
            if (!string.IsNullOrEmpty(tbFechaNacimiento.Text))
                try
                {
                    DateTime f = Convert.ToDateTime(tbFechaNacimiento.Text);
                    if (f.Year > 2000)
                    {
                        args.IsValid = false;
                        tbFechaNacimiento.CssClass = "form-control error";
                        cvFechaNacimiento.ErrorMessage = "El usuario debe ser mayor de edad.";
                        throw new Exception("El usuario debe ser mayor de edad. ");
                    }
                }
                catch (Exception)
                {
                    args.IsValid = false;
                    tbFechaNacimiento.CssClass = "form-control error";

                    Literal liMensaje = (Literal)this.Master.FindControl("liMensajeAlerta");
                    liMensaje.Text = "Fecha Invalida ingrese una fecha con formato correcto dd/mm/aaa";
                }
            else
            {
                args.IsValid = false;
                tbFechaNacimiento.CssClass = "form-control error";
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbEmail.CssClass = "form-control";
            cvEmail.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                args.IsValid = false;
                tbEmail.CssClass = "form-control error";
                cvEmail.ErrorMessage = "Debe ingresar su email para recuperar la cuenta. ";
            }
        }

        protected void cvContraseniaNueva_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbContrasenia.CssClass = "form-control";
            cvContraseniaNueva.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbContrasenia.Text))
            {
                args.IsValid = false;
                tbContrasenia.CssClass = "form-control error";
                cvContraseniaNueva.ErrorMessage = "Debe ingresar la contraseña";
            }
        }

        protected void cvRepitaContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbRepitaContraseña.CssClass = "form-control";
            cvRepitaContraseña.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbRepitaContraseña.Text) || (tbContrasenia.Text != tbRepitaContraseña.Text))
            {
                if ((tbContrasenia.Text != tbRepitaContraseña.Text))
                {
                    cvRepitaContraseña.ErrorMessage = "Las contraseñas deben coincidir";
                    tbContrasenia.CssClass = "form-control error";
                }
                args.IsValid = false;
                tbRepitaContraseña.CssClass = "form-control error";
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (Page.IsValid)
                {
                    //si existe el usuario
                    Bol.Usuario uexist = Bol.Usuario.GetUsuarioByEmail(tbEmail.Text);
                    if (uexist != null)
                    {
                        if
                            (
                            uexist.FechaNacimiento != Convert.ToDateTime(tbFechaNacimiento.Text) ||
                            uexist.Contraseña != tbContraseniaVieja.Text ||
                            uexist.Email != tbEmail.Text
                            )
                        {
                            throw new Exception("Los datos ingresados no coinciden con ningun usuario registrado.");
                        }
                        else
                        {
                            Bol.Usuario.ReActivarUsuario(tbEmail.Text);
                        }

                        //Redirijo
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                        throw new Exception("El usuario no existe. ");
                }
                else
                    throw new Exception("Uno o mas campos son incorrectos. ");
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