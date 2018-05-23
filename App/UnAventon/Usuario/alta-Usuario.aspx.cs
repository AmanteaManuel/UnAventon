using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnAventon.Usuario
{
    public partial class alta_Usuario : System.Web.UI.Page
    {
        #region " Properties "

        public Bol.Usuario Usuario
        {
            get
            {
                object o = ViewState["Usuario"] as object;
                return (o != null) ? (Bol.Usuario)o : null;
            }
            set { ViewState["Usuario"] = value; }
        }

        #endregion

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
                if (Bol.Core.Service.Tools.IsNumber(tbFechaNacimiento.Text))
                    try
                    {
                        Convert.ToDateTime(tbFechaNacimiento.Text);
                    }
                    catch (Exception)
                    {
                        Literal liMensaje = (Literal)this.Master.FindControl("liMensajeAlerta");
                        liMensaje.Text = "Fecha Invalida ingrese una fecha con formato correcto dd/mm/aaa";                        
                    }


            args.IsValid = false;
            tbFechaNacimiento.Attributes.Add("class", "form-group has-error");


        }          
                
        #endregion

        #region " Events "

        protected void Page_Load(object sender, EventArgs e)
        {
            //Deja la pagina en blanco(sin datos)
            ClearPage();

            // obtengo id de la url
            string id;
            if (Request.QueryString["id"] != null)
            {
                id =new Bol.Core.Service.Tools().Desencripta(Request.QueryString["id"]);
                int IdDesencriptado = Convert.ToInt32(id);
                Usuario = new Bol.Usuario().GetInstanceById(IdDesencriptado);
            }

            // si url vacia pagina es alta sino edicion           
            
            //si es alta
            if (Usuario == null)
            {
                liTitulo.Text = "Registrar Usuario. ";
                liSubTitulo.Text = "En esta pagina podra registrarse al sistema. ";
                btnRegistrarse.Visible = true;
                btnModificar.Visible = false;                
            }
            //si es modificacion
            else
            {
                liTitulo.Text = "Modificar Usuario. ";
                liSubTitulo.Text = "En esta pagina podra modificar sus datos Personales. ";
                btnRegistrarse.Visible = false;
                btnModificar.Visible = true;

                //Cargo los datos del usuario en los texbox.
                tbApellido.Text = Usuario.Apellido;
                tbNombre.Text = Usuario.Nombre;
                tbNombreUsuario.Text = Usuario.NombreUsuario;
                tbContrasenia.Text = Usuario.Contraseña;
                tbDni.Text = Usuario.Dni;
                tbEmail.Text = Usuario.Email;
                tbEmail.Enabled = false;

            }
        }

        /// <summary>
        /// Metodo que deja la pagina en blanco
        /// </summary>
        private void ClearPage()
        {
            tbApellido.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbNombreUsuario.Text = string.Empty;
            tbContrasenia.Text = string.Empty;
            tbDni.Text = string.Empty;
            tbEmail.Text = string.Empty;            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (Page.IsValid)
                {
                    //si existe el usuario
                    Bol.Usuario uexist = new Bol.Usuario().GetUsuarioByEmail(tbEmail.Text);
                    if (uexist != null)
                    {
                        Bol.Usuario user = new Bol.Usuario();
                        user.Apellido = tbApellido.Text;
                        user.Contraseña = tbContrasenia.Text;
                        user.Dni = tbDni.Text;
                        user.Email = tbEmail.Text;
                        user.FechaNacimiento = Convert.ToDateTime(tbFechaNacimiento.Text);
                        user.Nombre = tbNombre.Text;
                        user.NombreUsuario = tbNombreUsuario.Text;
                        user.SiActivo = true;

                        Bol.Usuario.Create(user);

                        //Redirijo
                        Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
                    }
                    else
                        throw new Exception("El usuario ya existe. ");
                }
                else
                    throw new Exception("Error al insertar usuario. ");
            }
            catch (Exception ex)
            {                
                Literal liMensaje = (Literal)this.Master.FindControl("liMensajeAlerta");
                liMensaje.Text = "Error al crear usuario"+ ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (Page.IsValid)
                {
                    Bol.Usuario user = new Bol.Usuario();
                    user.Apellido = tbApellido.Text;
                    user.Contraseña = tbContrasenia.Text;
                    user.Dni = tbDni.Text;
                    user.Email = tbEmail.Text;
                    user.FechaNacimiento = Convert.ToDateTime(tbFechaNacimiento.Text);
                    user.Nombre = tbNombre.Text;
                    user.NombreUsuario = tbNombreUsuario.Text;
                    user.SiActivo = true;

                    Bol.Usuario.Update(user);

                    //Redirijo
                    Response.Redirect("Listado-de-Viajes.aspx");
                }
                else
                    throw new Exception("El usuario ya existe");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario", ex);
            }
        }

        #endregion

        #region " Methods "



        #endregion


    }
}