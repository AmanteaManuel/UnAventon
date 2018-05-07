using System;
using System.Collections.Generic;
using System.Text;

namespace Bol
{
    public class Usuario : Persona
    {
        #region " atributes "

        private string _nombreUsuario;
        private string _contraseña;
        private Chofer _chofer;
        private Pasajero _pasajero;

        #endregion

        #region " Properties "

        /// <summary>
        /// nombre de usuario en el sistema
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }


        public Chofer Chofer
        {
            get
            {
                return _chofer;
            }
            set
            {
                _chofer = value;
            }
        }

        public Pasajero Pasajero
        {
            get
            {
                return _pasajero;
            }
            set
            {
                _pasajero = value;
            }
        }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Contraseña
        {
            get
            {
                return _contraseña;
            }
            set
            {
                _contraseña = value;
            }
        }

        #endregion
    }
}
