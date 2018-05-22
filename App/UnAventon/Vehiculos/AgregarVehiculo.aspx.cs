using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnAventon.Vehiculos
{
    public partial class AgregarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            /*try
            {
                Validate("CrearVehiculo");
                if (Page.IsValid)
                {
                    Bol.Vehiculo u = new Bol.Vehiculo();
                    u.Marca = tbMarca.Text;
                    u.Modelo = tbModelo.Text;
                    u.Patente = tbPatente.Text;
                    u.Color = tbColor.Text;
                    u.Asientos = tbAsientos.Text;
                    u.Descripcion = tbDescripcion.Text;
                    //u.SiActivo = true;   lo dejo porque no se que hace

                    Bol.Vehiculo.Create(u);

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el vehiculo", ex);
            } */
        }
    }
}