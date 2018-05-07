using System;
using System.Collections.Generic;
using System.Text;

namespace Bol
{
    public class Vehiculo
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private string _color;
        private string _marca;
        private string _modelo;
        private string _patente;
        private int _asientosDisponibles;        

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
        /// Color del auto
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <summary>
        /// Marca del auto
        /// </summary>
        public string Marca
        {
            get
            {
                return _marca;
            }
            set
            {
                _marca = value;
            }
        }

        /// <summary>
        /// Modelo del auto
        /// </summary>
        public string Modelo
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value;
            }
        }

        /// <summary>
        /// Patente del auto
        /// </summary>
        public string Patente
        {
            get
            {
                return _patente;
            }
            set
            {
                _patente = value;
            }
        }

        /// <summary>
        /// Asientos disponibles del auto
        /// </summary>
        public int AsientosDisponibles
        {
            get
            {
                return _asientosDisponibles;
            }
            set
            {
                _asientosDisponibles = value;
            }
        }

        #endregion

        #region " Views "

        public Vehiculo LoadById(int vehiculoId)
        {
            throw new NotImplementedException();
        }

        public List<Vehiculo> GetAllByUsuarioId(int usuarioId)
        {
            return null;
        }

        #endregion
    }
}
