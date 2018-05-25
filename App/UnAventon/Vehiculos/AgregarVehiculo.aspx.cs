using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon.Vehiculos
{
    public partial class AgregarVehiculo : UnAventonPage
    {
        #region "Properties" 
        public Bol.Vehiculo Vehiculo
        {
            get
            {
                object o = ViewState["Vehiculo"] as object;
                return (o != null) ? (Bol.Vehiculo)o : null;
            }
            set { ViewState["Vehiculo"] = value; }
        }
        #endregion

        #region "Validate"     

        protected void cvMarca_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbMarca.Attributes.Add("class", "form-group");
            cvMarca.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbMarca.Text) || string.IsNullOrWhiteSpace(tbMarca.Text))
            {
                args.IsValid = false;
                tbMarca.Attributes.Add("class", "form-group error");
            }
        }   

        protected void cvModelo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbModelo.Attributes.Add("class", "form-group");
            cvModelo.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbModelo.Text))
            {
                args.IsValid = false;
                tbModelo.Attributes.Add("class", "form-group error");
            }
        }

        protected void cvPatente_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPatente.Attributes.Add("class", "form-group");
            cvPatente.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPatente.Text))
            {
                args.IsValid = false;
                tbPatente.Attributes.Add("class", "form-group error");
            }
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbColor.Attributes.Add("class", "form-group");
            cvColor.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbColor.Text))
            {
                args.IsValid = false;
                tbColor.Attributes.Add("class", "form-group error");
            }
        }

        protected void cvAsientos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbAsientos.Attributes.Add("class", "form-group");
            cvAsientos.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbAsientos.Text))
            {
                args.IsValid = false;
                tbAsientos.Attributes.Add("class", "form-group error");
            }
        }


        #endregion  

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ClearPage();

                string id = new Bol.Core.Service.Tools().Encripta("1004");
                if (Request.QueryString["id"] != null)
                {
                    id = new Bol.Core.Service.Tools().Desencripta(id);
                    //id = new Bol.Core.Service.Tools().Desencripta(Request.QueryString["id"]);
                    int IdDesencriptado = Convert.ToInt32(id);
                    Vehiculo = new Bol.Vehiculo().LoadById(IdDesencriptado);
                }
                if (Vehiculo == null)
                {
                    liTitulo.Text = "Registrar Vehiculo. ";
                    liSubTitulo.Text = "En esta pagina podra registrarse al sistema. ";
                    btnRegistrar.Visible = true;
                    btnModificar.Visible = false;
                }
                else
                {
                    liTitulo.Text = "Modificar Vehiculo. ";
                    liSubTitulo.Text = "En esta pagina podra modificar los datos de sus vehiculos. ";
                    btnRegistrar.Visible = false;
                    btnModificar.Visible = true;

                    //Cargo los datos del vehiculo en los texbox.
                    tbMarca.Text = Vehiculo.Marca;
                    tbModelo.Text = Vehiculo.Modelo;
                    tbPatente.Text = Vehiculo.Patente;
                    tbColor.Text = Vehiculo.Color;
                    tbAsientos.Text = Convert.ToString(Vehiculo.AsientosDisponibles);

                }
            }
        }

        private void ClearPage()
        {
            tbMarca.Text = string.Empty;
            tbModelo.Text = string.Empty;
            tbPatente.Text = string.Empty;
            tbColor.Text = string.Empty;
            tbAsientos.Text = string.Empty;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {                
                Validate("GroupRegistrarVehiculo");
                if (Page.IsValid)
                {
                    Bol.Vehiculo v = new Bol.Vehiculo();
                    v.Marca = tbMarca.Text;
                    v.Modelo = tbModelo.Text;
                    v.Patente = tbPatente.Text;
                    v.Color = tbColor.Text;
                    v.AsientosDisponibles = Convert.ToInt32(tbAsientos.Text);

                    Bol.Vehiculo.Create(v, ActiveUsuario.Id);
                    
                    //tendriamos que mostrar un mensaje de ok para cuando la operacion es exitosa
                    Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("GroupRegistrarVehiculo");
                if (Page.IsValid)
                {
                    Vehiculo.Marca = tbMarca.Text;
                    Vehiculo.Modelo = tbModelo.Text;
                    Vehiculo.Patente = tbPatente.Text;
                    Vehiculo.Color = tbColor.Text;
                    Vehiculo.AsientosDisponibles = Convert.ToInt32(tbAsientos.Text);

                    Bol.Vehiculo.Update(Vehiculo, ActiveUsuario.Id);

                    //Redirijo
                    Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
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

        #endregion

        #region "Methods"
        #endregion
    }
}