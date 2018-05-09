using System;
using System.Collections.Generic;
using System.Text;

namespace Bol
{
    public abstract class Persona
    {

        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private string _email;



        #endregion

        #region " Properties "

        /// <summary>
        /// Identificador univoco de la bd
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }            
        }

        /// <summary>
        /// Codigo de la persona
        /// </summary>
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        /// <summary>
        /// Descripcion de la persona
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        /// <summary>
        /// Fecha de nacimiento de la persona
        /// </summary>
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        /// <summary>
        /// email de la persona
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        #endregion

        #region " Views "


        #endregion
    }
}
