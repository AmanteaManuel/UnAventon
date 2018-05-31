using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Bol
{
    [Serializable]
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
        private int _usuarioId;
        private List<Viaje> viajes;

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

        public int UsuarioId
        {
            get
            {
                return _usuarioId;
            }
            set { _usuarioId = value; }
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

        public List<Viaje> Viajes
        {
            get
            {
                return Bol.Viaje.GetAllViajesByVehiculoId(Id);
            }           
        }

        #endregion

        #region " Views "

        public Vehiculo LoadById(int usuarioId)
        {
            return FillObject(
                (new Dal.Core.Vehiculo().GetInstanceById(usuarioId)).Tables[0].Rows[0]);
        }

        public static List<Vehiculo> GetAllByUsuarioId(int usuarioId)
        {
            try
            {
                Dal.Core.Vehiculo dal = new Dal.Core.Vehiculo();
                DataSet ds = dal.GetAllByUsuarioId(usuarioId);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        #endregion

        #region " Fill "

        internal static Vehiculo FillObject(DataRow dr)
        {
            Vehiculo oBol = new Vehiculo();

            try
            {
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    oBol.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("Codigo") && !Convert.IsDBNull(dr["Codigo"]))
                    oBol.Codigo = Convert.ToInt32(dr["Codigo"]);

                if (dr.Table.Columns.Contains("Color") && !Convert.IsDBNull(dr["Color"]))
                    oBol.Color = Convert.ToString(dr["Color"]);

                if (dr.Table.Columns.Contains("Marca") && !Convert.IsDBNull(dr["Marca"]))
                    oBol.Marca = Convert.ToString(dr["Marca"]);

                if (dr.Table.Columns.Contains("Modelo") && !Convert.IsDBNull(dr["Modelo"]))
                    oBol.Modelo = Convert.ToString(dr["Modelo"]);

                if (dr.Table.Columns.Contains("Patente") && !Convert.IsDBNull(dr["Patente"]))
                    oBol.Patente = Convert.ToString(dr["Patente"]);

                if (dr.Table.Columns.Contains("Asientos") && !Convert.IsDBNull(dr["Asientos"]))
                    oBol.AsientosDisponibles = Convert.ToInt32(dr["Asientos"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        /// <summary>
        /// Recupera una lista con todas los Usuario
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<Vehiculo> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;

        }

        #endregion

        #region " CRUD "

        public static int Create(Vehiculo vehiculo, int usuarioId)
        {
            int outId = 0;
            try
            {
                //Bol.Usuario u = new Bol.Usuario().GetUsuarioByEmail(usuario.Email);

                outId = new Dal.Core.Vehiculo().Create(vehiculo.Color,
                                                       vehiculo.Marca,
                                                       vehiculo.Modelo,
                                                       vehiculo.Patente,
                                                       vehiculo.AsientosDisponibles,
                                                       usuarioId);

                vehiculo.Id = outId;                               
                return vehiculo.Id;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }
        public static void Update(Vehiculo vehiculo, int usuarioId)
        {
            try
            {
                List<Viaje> viajes = Viaje.GetAllViajesByVehiculoId(vehiculo.Id);
                if (viajes == null)
                    new Dal.Core.Vehiculo().Update(
                    vehiculo.Color,
                    vehiculo.Marca,
                    vehiculo.Modelo,
                    vehiculo.Patente,
                    vehiculo.AsientosDisponibles,
                    vehiculo.Id,
                    usuarioId);
                else
                    throw new Exception("El vehiculo tiene viajes en curso. ");
            }
            catch (Exception e) { throw new Exception("Error en el Update del vehiculo. " + e.Message); }
        }

        public static void Delete(int vehiculoId)
        {
            try
            {
                List<Viaje> viajes = Viaje.GetAllViajesByVehiculoId(vehiculoId);
                if (viajes == null)
                    new Dal.Core.Vehiculo().Delete(vehiculoId);
                else
                    throw new Exception("El vehiculo tiene viajes en curso. ");
            }
            catch (Exception e) { throw new Exception("Error en la eliminacion del vehiculo. " + e.Message); }
        }

        #endregion

        #region " Contructor "

        public Vehiculo() { }

        #endregion
    }
}