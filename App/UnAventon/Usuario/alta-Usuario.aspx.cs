using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnAventon.Usuario
{
    public partial class alta_Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (!Page.IsValid);
                    //throw new Exception("Verifique los datos");
            }
            catch (Exception ex)
            {

               // throw new Exception("Error al crear usuario", ex);
            }
            
        }

        #region " Validate "

        protected void cvNombreUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbNombreUsuario.Attributes.Add("class", "form-group");
            cvNombreUsuario.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbNombreUsuario.Text) || string.IsNullOrWhiteSpace(tbNombreUsuario.Text))
            {
                args.IsValid = false;
                tbNombreUsuario.Attributes.Add("class", "form-group has-error");   
            }
        }

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {

            //if (string.IsNullOrEmpty(iApellidos.Value))
            //{
            //    args.IsValid = false;
            //    cvApellidos.ErrorMessage = "El campo Apellido debe ser informado.";
            //    divApellidos.Attributes.Add("class", "form-group has-error");
            //}
            //else if (!Tools.IsLetter(iApellidos.Value.Replace(" ", "")))
            //{
            //    args.IsValid = false;
            //    cvApellidos.ErrorMessage = "El campo Apellido no puede contener números ni caracteres especiales.";
            //    divApellidos.Attributes.Add("class", "form-group has-error");
            //}
            //else
            //{
            //    cvApellidos.ErrorMessage = string.Empty;
            //    divApellidos.Attributes.Add("class", "form-group");
            //}

        }

        protected void cvApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void cvContrasenia_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void cvRepitaContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        #endregion
    }
}