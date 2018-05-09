using System;
using System.Collections.Generic;
using System.Text;

namespace Bol
{
    public class Viaje
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private Vehiculo _vehiculo;
        private int _vehiculoId;
        private string _destino;
        private string _origen;
        private string _duracion;
        private int _lugaresDisponibles;
        private DateTime _fechaSalida;
        private double _precio;


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

        public Vehiculo Vehiculo
        {
            get
            {
                return Vehiculo.LoadById(_vehiculoId);
            }
            set
            {
                _vehiculo = value;
            }
        }

        public string Destino
        {
            get
            {
                return _destino;
            }
            set
            {
                _destino = value;
            }
        }

        public string Origen
        {
            get
            {
                return _origen;
            }
            set
            {
                _origen = value;
            }
        }
       
        public string Duracion
        {
            get
            {
                return _duracion;
            }
            set
            {
                _duracion = value;
            }
        }

        public int LugaresDisponibles
        {
            get
            {
                return _lugaresDisponibles;
            }
            set
            {
                _lugaresDisponibles = value;
            }
        }

        public DateTime FechaSalida
        {
            get
            {
                return _fechaSalida;
            }
            set
            {
                _fechaSalida = value;
            }
        }

        public double Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }

        #endregion

        #region " Views "

        public Viaje GetById()
        {
            return null;
        }

        public List<Viaje> GetAll()
        {
            return null;
        }

        #endregion
    }
}
