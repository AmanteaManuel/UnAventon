using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Usuario
{
    public partial class alta_Usuario : UnAventonPage
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

        

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbNombre.CssClass = "form-control";
            cvNombre.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                args.IsValid = false;
                tbNombre.CssClass = "form-control error";
            }

        }

        protected void cvApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbApellido.CssClass = "form-control";
            cvApellido.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                args.IsValid = false;
                tbApellido.Attributes.Add("class", "form-control error");
                tbApellido.CssClass = "form-control error";
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
            }
        }

        protected void cvContrasenia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbContrasenia.CssClass = "form-control";
            cvContrasenia.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbContrasenia.Text))
            {
                args.IsValid = false;
                tbContrasenia.CssClass = "form-control error";
            }
        }

        protected void cvRepitaContraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbRepitaContraseña.CssClass = "form-control";
            cvNombre.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbRepitaContraseña.Text) || (tbContrasenia.Text != tbRepitaContraseña.Text))
            {
                args.IsValid = false;
                tbRepitaContraseña.CssClass = "form-control error";
            }
        }

        protected void cvDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbDni.CssClass = "form-control";
            cvDni.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbDni.Text) || (!Bol.Core.Service.Tools.IsNumber(tbDni.Text)))
            {
                args.IsValid = false;
                tbDni.CssClass = "form-control error";
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
                
        #endregion

        #region " Events "

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Deja la pagina en blanco(sin datos)
                ClearPage();

                // obtengo id de la url            
                if (Request.QueryString["id"] != null)
                {
                    string idEncriptado = Request.QueryString["id"];
                    int id = Convert.ToInt32(new Bol.Core.Service.Tools().Desencripta(idEncriptado));
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
                    tbContrasenia.Text = Usuario.Contraseña;
                    tbRepitaContraseña.Text = Usuario.Contraseña;
                    tbDni.Text = Usuario.Dni;
                    tbEmail.Text = Usuario.Email;
                    tbEmail.Enabled = false;
                    tbFechaNacimiento.Text = Usuario.FechaNacimiento.ToString("dd/MM/yyyy");

                }
            }
        }

        /// <summary>
        /// Metodo que deja la pagina en blanco
        /// </summary>
        private void ClearPage()
        {
            tbApellido.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbContrasenia.Text = string.Empty;
            tbRepitaContraseña.Text = string.Empty;
            tbFechaNacimiento.Text = string.Empty;
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
                    Bol.Usuario uexist = Bol.Usuario.GetUsuarioByEmail(tbEmail.Text);
                    if (uexist == null)
                    {
                        Bol.Usuario user = new Bol.Usuario();
                        user.Apellido = tbApellido.Text;
                        user.Contraseña = tbContrasenia.Text;
                        user.Dni = tbDni.Text;
                        user.Email = tbEmail.Text;
                        user.FechaNacimiento = Convert.ToDateTime(tbFechaNacimiento.Text);
                        user.Nombre = tbNombre.Text;
                        
                        user.SiActivo = true;

                        Bol.Usuario.Create(user);

                        //Redirijo
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                        throw new Exception("El usuario ya existe. ");
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearUsuario");
                if (Page.IsValid)
                {
                    ActiveUsuario.Apellido = tbApellido.Text;
                    ActiveUsuario.Contraseña = tbContrasenia.Text;
                    ActiveUsuario.Dni = tbDni.Text;
                    ActiveUsuario.Email = tbEmail.Text;
                    ActiveUsuario.FechaNacimiento = Convert.ToDateTime(tbFechaNacimiento.Text);
                    ActiveUsuario.Nombre = tbNombre.Text;
                    Bol.Usuario.Update(ActiveUsuario);                    

                    //Redirijo
                    Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
                }
                else
                    throw new Exception("Uno o mas campos son incorrectos");
            }
            catch (Exception ex)
            {
                HtmlGenericControl divalert = (HtmlGenericControl)this.Master.FindControl("divMsjAlerta");
                divalert.Visible = true;
                Literal lialert = (Literal)this.Master.FindControl("liMensajeAlerta");
                lialert.Text = ex.Message;                
            }
        }

        #endregion

        #region " Methods "



        #endregion


    }
}