using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        //estan comentadas las validaciones de asientos disponibles y descripcion para que no se rompa
        #region "Validate"     
        protected void cvMarca_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbMarca.Attributes.Add("class", "form-group");
            cvMarca.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbMarca.Text) || string.IsNullOrWhiteSpace(tbMarca.Text))
            {
                args.IsValid = false;
                tbMarca.Attributes.Add("class", "form-group has-error");
            }
        }   

        protected void cvModelo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbModelo.Attributes.Add("class", "form-group");
            cvModelo.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbModelo.Text))
            {
                args.IsValid = false;
                tbModelo.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvPatente_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPatente.Attributes.Add("class", "form-group");
            cvPatente.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPatente.Text))
            {
                args.IsValid = false;
                tbPatente.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvColor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbColor.Attributes.Add("class", "form-group");
            cvColor.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbColor.Text))
            {
                args.IsValid = false;
                tbColor.Attributes.Add("class", "form-group has-error");
            }
        }

        protected void cvAsientos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbAsientos.Attributes.Add("class", "form-group");
            cvAsientos.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbAsientos.Text))
            {
                args.IsValid = false;
                tbAsientos.Attributes.Add("class", "form-group");
            }
        }


        #endregion  

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearPage();

            string id;
            if (Request.QueryString["id"] != null)
            {
                id = new Bol.Core.Service.Tools().Desencripta(Request.QueryString["id"]);
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
                tbAsientos.Text =Convert.ToString(Vehiculo.AsientosDisponibles); 
                

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
                Validate("CrearVehiculo");
                if (Page.IsValid)
                {
                    Bol.Vehiculo v = new Bol.Vehiculo();
                    v.Marca = tbMarca.Text;
                    v.Modelo = tbModelo.Text;
                    v.Patente = tbPatente.Text;
                    v.Color = tbColor.Text;
                    v.AsientosDisponibles = Convert.ToInt32(tbAsientos.Text);  // Aca se rompe
                    //v.SiActivo = true; //sirve para ver si esta dado de alta

                    Bol.Vehiculo.Create(v);

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el vehiculo", ex);
            } 
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate("CrearVehiculo");             
                if (Page.IsValid)
                {
                    Bol.Vehiculo vehiculo = new Bol.Vehiculo();
                    vehiculo.Marca = tbMarca.Text;
                    vehiculo.Modelo = tbModelo.Text;
                    vehiculo.Patente = tbPatente.Text;
                    vehiculo.Color = tbColor.Text;
                    vehiculo.AsientosDisponibles = Convert.ToInt32(tbAsientos.Text);
                    //vehiculo.SiActivo = true;

                    Bol.Vehiculo.Update(vehiculo);

                    //Redirijo
                    Response.Redirect("Listado-de-Viajes.aspx");
                }
                else
                    throw new Exception("El vehiculo ya existe");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar vehiculo", ex);
            }
        }

        #endregion

        #region "Methods"
        #endregion
    }
}