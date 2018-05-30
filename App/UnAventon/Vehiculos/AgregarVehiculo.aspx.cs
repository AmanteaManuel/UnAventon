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
            tbMarca.CssClass = "form-control";
            cvMarca.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbMarca.Text) || string.IsNullOrWhiteSpace(tbMarca.Text))
            {
                args.IsValid = false;                
                tbMarca.CssClass = "form-control error";
            }
        }   

        protected void cvModelo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbModelo.CssClass= "form-control";
            cvModelo.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbModelo.Text))
            {
                args.IsValid = false;
                tbModelo.CssClass= "form-control error";
            }
        }

        protected void cvPatente_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPatente.CssClass= "form-control";
            cvPatente.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPatente.Text))
            {
                args.IsValid = false;
                tbPatente.CssClass= "form-control error";
            }
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbColor.CssClass= "form-control";
            cvColor.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbColor.Text))
            {
                args.IsValid = false;
                tbColor.CssClass= "form-control error";
            }
        }

        protected void cvAsientos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbAsientos.CssClass= "form-control";
            cvAsientos.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbAsientos.Text) || (Bol.Core.Service.Tools.IsNumber(tbAsientos.Text) == false))
            {
                args.IsValid = false;
                tbAsientos.CssClass= "form-control error";
            }
        }


        #endregion  

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ClearPage();               
                if (Request.QueryString["id"] != null)
                {
                    string id = new Bol.Core.Service.Tools().Desencripta(Request.QueryString["id"]);                    
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
                else
                    throw new Exception(" Error al registrar Vehículo ");

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
                else
                    throw new Exception(" Error al modificar Vehículo ");
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