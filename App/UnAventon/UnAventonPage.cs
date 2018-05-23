using System;

namespace UnAventon
{
    public class UnAventonPage : System.Web.UI.Page
    {

        /// <summary>
        /// Usuario activo en el contexto de la aplicacion.
        /// </summary>
        protected Bol.Usuario @ActiveUsuario
        {
            get
            {
                if (Context.Items["Usuario"] != null)
                    return (Bol.Usuario)Context.Items["Usuario"];
                throw new Exception("No se pudo obtener el usuario del contexto.");
            }
        }

    }
}