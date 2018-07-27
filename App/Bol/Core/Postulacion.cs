using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Core
{
    [Serializable]
    public class Postulacion
    {
        public int UsuarioId { get; set; }

        public int ViajeId { get; set; }

        public int EstadoViaje { get; set; }

        public bool SiCalificado { get; set; }

        public bool SiCalifico { get; set; }

        public DateTime FechaSalida { get; set; }

        public int Duracion { get; set; }


        internal static Postulacion FillObject(DataRow dr)
        {
            Postulacion oBol = new Postulacion();

            try
            {
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("ViajeId") && !Convert.IsDBNull(dr["ViajeId"]))
                    oBol.ViajeId = Convert.ToInt32(dr["ViajeId"]);

                if (dr.Table.Columns.Contains("EstadoViaje") && !Convert.IsDBNull(dr["EstadoViaje"]))
                    oBol.EstadoViaje = Convert.ToInt32(dr["EstadoViaje"]);

                if (dr.Table.Columns.Contains("SiCalificado") && !Convert.IsDBNull(dr["SiCalificado"]))
                    oBol.SiCalificado = Convert.ToBoolean(dr["SiCalificado"]);

                if (dr.Table.Columns.Contains("FechaSalida") && !Convert.IsDBNull(dr["FechaSalida"]))
                    oBol.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);

                if (dr.Table.Columns.Contains("Duracion") && !Convert.IsDBNull(dr["Duracion"]))
                    oBol.Duracion = Convert.ToInt32(dr["Duracion"]);

                if (dr.Table.Columns.Contains("SiCalifico") && !Convert.IsDBNull(dr["SiCalifico"]))
                    oBol.SiCalifico = Convert.ToBoolean(dr["SiCalifico"]);
            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        private static List<Postulacion> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
        }

        public static List<Postulacion> GetAllPostulacionesAceptados(int usuarioId)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllPostulacionesAceptados(usuarioId);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public static Postulacion GetByViajeANDusuarioId(int usuarioId, int viajeId)
        {
            DataSet userdr;
            userdr = new Dal.Core.Usuario().GetByViajeANDusuarioId(usuarioId, viajeId);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillObject(userdr.Tables[0].Rows[0]);
            else
                return null;            
        }

        public static List<Postulacion> GetAllByUsuarioAddFechaId(int usuarioId)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllByUsuarioAddFechaId(usuarioId);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public static List<Postulacion> GetAllPostulacionesByViajeId(int viajeId)
        {
            try
            {
                Dal.Core.Viaje dal = new Dal.Core.Viaje();
                DataSet ds = dal.GetAllPostulacionesByViajeId(viajeId);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        /// <summary>
        /// Este metodo vuelve atras el estado de las calificaciones para que un usuario pueda calificar
        /// a su chofer, y al mismo tiempo ser calificado
        /// </summary>
        /// <param name="pasajeroId"></param>
        /// <param name="viajeId"></param>
        public static void MetodoQueHaceTrampa(int pasajeroId, int viajeId)
        {
            try
            {
                new Dal.Core.Viaje().MetodoQueHaceTrampa(pasajeroId, viajeId);
            }
            catch (Exception)
            {
                throw new Exception("Error en la 'calificacion'. ");
            }
        }
    }
}
