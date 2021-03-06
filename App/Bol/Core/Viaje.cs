﻿using Bol.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Transactions;

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
        private int _lugaresDisponiblesActual;
        private DateTime _fechaSalida;
        private string _horaSalida;
        private double _precio;
        private Ciudad _destino;
        private Ciudad _origen;
        private Usuario _usuario;
        private int _usuarioId;
        private List<Usuario> _postulantes;
        private bool _siActivo;
        private int _estadoViaje;
        private int _usuarioPasajeroId;

        #endregion

        #region " Properties "


        //public enum EstadoViaje: int { Pendiente = 1, Aceptado = 2, Rechazado = 3}

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

        public bool SiPagado
        { get; set; }

        //solo usarla para el ver perfil
        public int EstadoViaje
        {
            get
            {
                return _estadoViaje;
            }
            set { _estadoViaje = value; }
        }

        //solo usarla para el ver perfil
        public int UsuarioPasajeroId
        {
            get
            {
                return _usuarioPasajeroId;
            }
            set { _usuarioPasajeroId = value; }
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

        public bool SiActivo
        {
            get
            {
                return _siActivo;
            }
            set
            {
                _siActivo = value;
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
                return new Bol.Vehiculo().LoadById(_vehiculoId);
            }
            set
            {
                _vehiculo = value;
            }
        }

        public int DestinoId
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

        public int OrigenId
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

        public Ciudad Destino
        {
            get
            {
                return Bol.Core.Ciudad.GetById(_destinoId);
            }
            set
            {
                _destino = value;
            }
        }

        public Ciudad Origen
        {
            get
            {
                return Bol.Core.Ciudad.GetById(_origenId);
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

        public int LugaresDisponiblesActual
        {
            get
            {
                return _lugaresDisponiblesActual;
            }
            set
            {
                _lugaresDisponiblesActual = value;
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

        public string ShortDate
        {
            get
            {
                return FechaSalida.ToString("dd/MM/yyy");
            }
        }

        public double Precio
        {
            get
            {
                return Math.Round(_precio,2);
            }
            set
            {
                _precio = value;
            }
        }

        public string HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }

        public Usuario Usuario
        {
            get
            {
                return new Bol.Usuario().GetInstanceById(UsuarioId);
            }
            set
            {
                _usuario = value;
            }
        }

        public List<Usuario> Postulantes
        {
            get
            {
                return Bol.Usuario.GetPostulantesByViajeId(Id);
            }
        }

        public List<Usuario> Pasajeros
        {
            get
            {
                return Bol.Usuario.GetPasajerosByViajeId(Id);
            }
        }

        public string NombreChofer
        {
            get
            {
                Bol.Usuario u = new Bol.Usuario().GetInstanceById(UsuarioId);
                return u.Nombre + " " + u.Apellido;
            }
        }
        #endregion

        #region " Views "

        public static List<Viaje> GetAllViajesByVehiculoId(int id)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllViajesByVehiculoId(id);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public static List<Viaje> GetAllViajesByVehiculoIdValidator(int id)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllViajesByVehiculoIdValidator(id);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

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

        public List<Viaje> GetAllByUsuarioId(int id)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllByUsuarioId(id);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        private static List<Viaje> GetAllByUsuarioIdAndFecha(int id, DateTime fecha)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllByUsuarioIdAndFecha(id, fecha);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public static List<Viaje> GetPostulacionesByUsuarioId(int id)
        {
            DataSet userdr;
            userdr = new Dal.Core.Viaje().GetPostulacionesByUsuarioId(id);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillList(userdr);
            else
                return null;
        }

        public static List<Viaje> GetAllByFiltrosAndNowToOneMonth(int CiudadDestinoId, int ciudadSalidaId, DateTime fechaActual, DateTime fechaUnMes)
        {
            DataSet Viajedr;
            Viajedr = new Dal.Core.Viaje().GetAllByFiltrosAndNowToOneMonth(CiudadDestinoId, ciudadSalidaId, fechaActual, fechaUnMes);
            if (Viajedr.Tables[0].Rows.Count > 0)
                return FillList(Viajedr);
            else
                return null;
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
                    oBol.DestinoId = Convert.ToInt32(dr["CiudadDestinoId"]);

                if (dr.Table.Columns.Contains("VehiculoId") && !Convert.IsDBNull(dr["VehiculoId"]))
                    oBol._vehiculoId = Convert.ToInt32(dr["VehiculoId"]);

                if (dr.Table.Columns.Contains("CiudadOrigenId") && !Convert.IsDBNull(dr["CiudadOrigenId"]))
                    oBol.OrigenId = Convert.ToInt32(dr["CiudadOrigenId"]);

                if (dr.Table.Columns.Contains("Duracion") && !Convert.IsDBNull(dr["Duracion"]))
                    oBol.Duracion = Convert.ToString(dr["Duracion"]);

                if (dr.Table.Columns.Contains("LugaresDisponibles") && !Convert.IsDBNull(dr["LugaresDisponibles"]))
                    oBol.LugaresDisponibles = Convert.ToInt32(dr["LugaresDisponibles"]);

                if (dr.Table.Columns.Contains("LugaresDisponiblesActual") && !Convert.IsDBNull(dr["LugaresDisponiblesActual"]))
                    oBol.LugaresDisponiblesActual = Convert.ToInt32(dr["LugaresDisponiblesActual"]);

                if (dr.Table.Columns.Contains("FechaSalida") && !Convert.IsDBNull(dr["FechaSalida"]))
                    oBol.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);

                if (dr.Table.Columns.Contains("Precio") && !Convert.IsDBNull(dr["Precio"]))
                    oBol.Precio = Convert.ToDouble(dr["Precio"]);

                if (dr.Table.Columns.Contains("HoraSalida") && !Convert.IsDBNull(dr["HoraSalida"]))
                    oBol.HoraSalida = Convert.ToString(dr["HoraSalida"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("SiActivo") && !Convert.IsDBNull(dr["SiActivo"]))
                    oBol.SiActivo = Convert.ToBoolean(dr["SiActivo"]);

                if (dr.Table.Columns.Contains("EstadoViaje") && !Convert.IsDBNull(dr["EstadoViaje"]))
                    oBol.EstadoViaje = Convert.ToInt32(dr["EstadoViaje"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioPasajeroId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("SiPagado") && !Convert.IsDBNull(dr["SiPagado"]))
                    oBol.SiPagado = Convert.ToBoolean(dr["SiPagado"]);

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        private static List<Viaje> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
        }

        #endregion

        #region " CRUD "

        public static int Create(Viaje viaje, int usuarioId)
        {
            int outId = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ValidarViaje(viaje, usuarioId);
                    //obtener viajes del usuario para la fecha del nuevo viaje

                    //preguntar si el viaje(nuevo) <> a la (hora del viaje salida + duracion) de todos los viajes del dia

                    outId = new Dal.Core.Viaje().Create(
                    viaje._origenId,
                    viaje._destinoId,
                    viaje.Duracion,
                    viaje.LugaresDisponibles,
                    viaje._vehiculoId,
                    viaje.FechaSalida,
                    viaje._horaSalida,
                    viaje.Precio,
                    viaje.Descripcion,
                    usuarioId
                    );

                    viaje.Id = outId;
                    scope.Complete();
                    return viaje.Id;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Delete (int viajeId)
        {
            try
            {
                new Dal.Core.Viaje().Delete(viajeId);
            }
            catch (Exception e) { throw new Exception("Error al borrar viaje. " + e.Message); }
        }

        private static void ValidarViaje(Viaje viaje, int usuarioId)
        {
            //obtengo todos los viajes en la fecha para ese usuario
            List<Viaje> viajes = GetAllByUsuarioIdAndFecha(usuarioId, viaje.FechaSalida);

            if (viajes != null)
            {
                int cont = 0;
                //por cada viaje obtenido
                foreach (var v in viajes)
                {
                    //obtengo la hora de salida y la casteo a datetime
                    DateTime horaInicio = Convert.ToDateTime(v.HoraSalida);

                    //obtengo la hora de Fin y la casteo a datetime
                    DateTime horaFin = horaInicio.AddHours(Convert.ToDouble(v.Duracion));

                    //si la hora de salida del viaje a validar esta en el lapso de tiempo de otro viaje
                    //tiro error
                    if (Convert.ToDateTime(viaje.HoraSalida) > horaInicio || Convert.ToDateTime(viaje.HoraSalida) < horaFin)
                        cont++;
                }
                if(cont > 0 )
                    throw new Exception("Los viajes que se colapsaban por superposicion horaria no fueron publicados.");
            }
            
        }

        public static void Update(Viaje viaje, int viajeId)
        {
            
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ValidarViaje(viaje, viajeId);

                    new Dal.Core.Viaje().Update(
                    viaje._origenId,
                    viaje._destinoId,
                    viaje.Duracion,
                    viaje.LugaresDisponibles,
                    viaje._vehiculoId,
                    viaje.FechaSalida,
                    viaje._horaSalida,
                    viaje.Precio,
                    viaje.Descripcion,
                    viajeId
                    );

                    scope.Complete();
                }
            }
            catch (Exception e) { throw new Exception("No se pudo Modificar el viaje."); }
        }

        public static void RestarUnLUgar(int viajeId)
        {
            try
            {
                new Dal.Core.Viaje().RestarUnLUgar(viajeId);
            }
            catch (Exception e) { throw new Exception("Error al restar asiento. " + e.Message); }
        }

        public static void SumarUnLUgar(int viajeId)
        {
            try
            {
                new Dal.Core.Viaje().SumarUnLUgar(viajeId);
            }
            catch (Exception e) { throw new Exception("Error al sumnar asiento. "); }
        }

        public static void Pagar(int viajeId)
        {
            try
            {
                new Dal.Core.Viaje().Pagar(viajeId);
            }
            catch (Exception e) { throw new Exception("Error al pagar el viaje. ");
            }
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

        #region " Validaciones "

        public static bool ValidarCreacionDeViaje(int usuarioId)
        {
            List<Viaje> viajes = new Bol.Viaje().GetAllByUsuarioId(usuarioId);
            List<Postulacion> postulaciones = Bol.Core.Postulacion.GetAllByUsuarioAddFechaId(usuarioId);

            if (postulaciones != null)
            {
                //si adeuda alguna calificacion
                foreach (Postulacion p in postulaciones)
                {
                    if (p.FechaSalida.AddHours(p.Duracion) < DateTime.Now)
                        if (p.SiCalificado == false)
                            return false;
                }
            }  

            if (viajes != null)
            {
                foreach (Viaje v in viajes)
                {
                    //si hay algun viaje que no esta pagado retorno false
                    if (v.FechaSalida.AddHours(Convert.ToInt32(v.Duracion)) < DateTime.Now)
                        if (v.SiPagado == false)
                            return false;
                }
            }

            return true;
        }

        #endregion
    }
}
