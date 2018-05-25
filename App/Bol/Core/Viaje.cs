using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bol
{
    [Serializable]
    public class Viaje
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private Vehiculo _vehiculo;
        private int _vehiculoId;
        private int _destinoId;
        private int _origenId;
        private string _duracion;
        private int _lugaresDisponibles;
        private DateTime _fechaSalida;
        private string _horaSalida;
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
            set { _id = value; }
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

        public int Destino
        {
            get
            {
                return _destinoId;
            }
            set
            {
                _destinoId = value;
            }
        }        

        public int Origen
        {
            get
            {
                return _origenId;
            }
            set
            {
                _origenId = value;
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

        public Viaje GetInstanceById(int id)
        {
            try
            {
                return FillObject((new Dal.Core.Viaje().GetInstanceById(id)).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Cargar Viaje. " + ex.Message);
            }
        }

        public List<Viaje> GetAll()
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAll();
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public List<Viaje> GetAllFromNowToOneMonth(DateTime fechaActual, DateTime fechaUnMes)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllFromNowToOneMonth(fechaActual, fechaUnMes);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        #endregion

        #region " Fill "

        internal static Viaje FillObject(DataRow dr)
        {
            Viaje oBol = new Viaje();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    oBol.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Descripcion") && !Convert.IsDBNull(dr["Descripcion"]))
                    oBol.Descripcion = Convert.ToString(dr["Descripcion"]);
             
                if (dr.Table.Columns.Contains("CiudadDestinoId") && !Convert.IsDBNull(dr["CiudadDestinoId"]))
                    oBol.Destino = Convert.ToInt32(dr["CiudadDestinoId"]);

                if (dr.Table.Columns.Contains("VehiculoId") && !Convert.IsDBNull(dr["VehiculoId"]))
                    oBol._vehiculoId = Convert.ToInt32(dr["VehiculoId"]);

                if (dr.Table.Columns.Contains("CiudadOrigenId") && !Convert.IsDBNull(dr["CiudadOrigenId"]))
                    oBol.Origen = Convert.ToInt32(dr["CiudadOrigenId"]);

                if (dr.Table.Columns.Contains("Duracion") && !Convert.IsDBNull(dr["Duracion"]))
                    oBol.Duracion = Convert.ToString(dr["Duracion"]);

                if (dr.Table.Columns.Contains("LugaresDisponibles") && !Convert.IsDBNull(dr["LugaresDisponibles"]))
                    oBol.LugaresDisponibles = Convert.ToInt32(dr["LugaresDisponibles"]);

                if (dr.Table.Columns.Contains("FechaSalida") && !Convert.IsDBNull(dr["FechaSalida"]))
                    oBol.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);

                if (dr.Table.Columns.Contains("Precio") && !Convert.IsDBNull(dr["Precio"]))
                    oBol.Precio = Convert.ToDouble(dr["Precio"]);               

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        private static List<Viaje> FillList(DataSet ds)
        {
            //if (ds.Tables[0].Rows.Count > 0)
                //return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
        }

        #endregion

        #region " CRUD "

        public static int Create(Viaje viaje)
        {
            int outId = 0;
            try
            {
                
                outId = new Dal.Core.Viaje().Create(
                viaje._origenId,
                viaje._destinoId,
                viaje.Duracion,
                viaje.LugaresDisponibles,
                viaje._vehiculoId,
                viaje.FechaSalida,
                viaje._horaSalida,
                viaje.Precio,
                viaje.Descripcion
                );

                viaje.Id = outId;
                return viaje.Id;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        #endregion

        #region " Constructor "

        public Viaje(
            int CiudadSalidaId,
            int CiudadDestinoId,
            string Duracion,
            int LugaresDisponibles,
            int vehiculoId,
            DateTime fecha,
            string horaSalida,
            double precio,
            string Descripcion)
        {
            this._origenId = CiudadSalidaId;
            this._destinoId = CiudadDestinoId;
            this._duracion = Duracion;
            this._lugaresDisponibles = LugaresDisponibles;
            this._vehiculoId = vehiculoId;
            this._fechaSalida = fecha;
            this._horaSalida = horaSalida;
            this._precio = precio;
            this._descripcion = Descripcion;
        }

        public Viaje() { }


        #endregion
    }
}
