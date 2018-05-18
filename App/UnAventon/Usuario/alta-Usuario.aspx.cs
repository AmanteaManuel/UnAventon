using System;
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
                if (Page.IsValid)
                {
                    Bol.Usuario u = new Bol.Usuario();
                    u.Apellido = tbApellido.Text;
                    u.Contraseña = tbContrasenia.Text;
                    u.Dni = tbDni.Text;
                    u.Email = tbEmail.Text;
                    u.FechaNacimiento = Convert.ToDateTime(tbFechaNacimiento.Text);
                    u.Nombre = tbNombre.Text;
                    u.NombreUsuario = tbNombreUsuario.Text;
                    u.SiActivo = true;

                    Bol.Usuario.Create(u);
                    
                }
                    
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

            tbNombre.Attributes.Add("class", "form-group");
            cvNombre.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                args.IsValid = false;
                tbNombre.Attributes.Add("class", "form-group has-error");
            }

        }

        protected void cvApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbApellido.Attributes.Add("class", "form-group");
            cvApellido.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                args.IsValid = false;
                tbApellido.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbEmail.Attributes.Add("class", "form-group");
            cvEmail.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                args.IsValid = false;
                tbEmail.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvContrasenia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbContrasenia.Attributes.Add("class", "form-group");
            cvContrasenia.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbContrasenia.Text))
            {
                args.IsValid = false;
                tbContrasenia.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvRepitaContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbRepitaContraseña.Attributes.Add("class", "form-group");
            cvNombre.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbRepitaContraseña.Text) || (tbContrasenia.Text != tbRepitaContraseña.Text))
            {
                args.IsValid = false;
                tbNombre.Attributes.Add("class", "form-group has-error");
            }
        }

        #endregion

        protected void cvDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbDni.Attributes.Add("class", "form-group");
            cvDni.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbDni.Text))
            {
                args.IsValid = false;
                tbDni.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvFechaNacimiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbFechaNacimiento.Attributes.Add("class", "form-group");
            cvFechaNacimiento.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbFechaNacimiento.Text))
            {
                args.IsValid = false;
                tbFechaNacimiento.Attributes.Add("class", "form-group has-error");
            }
        }
    }
}