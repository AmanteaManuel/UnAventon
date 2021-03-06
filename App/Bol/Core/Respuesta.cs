﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;


namespace Bol
{
    [Serializable]
    public class Respuesta
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private int _preguntaId;
        private DateTime _fecha;
        private int _usuarioId;

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
            set
            {
                _id = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
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

        public int UsuarioId { get; set; }

        public int PreguntaId { get; set; }

        #endregion

        #region " Views "

        public static List<Respuesta> GetAllByViajeId(int id)
        {
            try
            {
                Dal.Core.Respuesta dal = new Dal.Core.Respuesta();
                DataSet ds = dal.GetAllByViajeId(id);
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        public static Respuesta GetInstanceById(int? id)
        {
            try
            {
                return FillObject((new Dal.Core.Respuesta().GetInstanceById(id)).Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Cargar Viaje. " + ex.Message);
            }
        }

        #endregion

        #region " Fill "

        private static Respuesta FillObject(DataRow dr)
        {
            Respuesta oBol = new Respuesta();

            try
            {
                //ID
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    oBol.Id = Convert.ToInt32(dr["Id"]);

                //Apellido
                if (dr.Table.Columns.Contains("Codigo") && !Convert.IsDBNull(dr["Codigo"]))
                    oBol.Codigo = Convert.ToInt32(dr["Codigo"]);

                //Nombre
                if (dr.Table.Columns.Contains("Descripcion") && !Convert.IsDBNull(dr["Descripcion"]))
                    oBol.Descripcion = Convert.ToString(dr["Descripcion"]);

                if (dr.Table.Columns.Contains("PreguntaId") && !Convert.IsDBNull(dr["PreguntaId"]))
                    oBol.PreguntaId = Convert.ToInt32(dr["PreguntaId"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Fecha") && !Convert.IsDBNull(dr["Fecha"]))
                    oBol.Fecha = Convert.ToDateTime(dr["Fecha"]);

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        /// <summary>
        /// Recupera una lista con todas los Usuario
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<Respuesta> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
        }

        #endregion

        #region " CRUD "

        public static int Create(Respuesta respuesta)
        {
            int outId = 0;
            try
            {                

                outId = new Dal.Core.Respuesta().Create(                
                respuesta.Fecha,
                respuesta.Descripcion,                
                respuesta.UsuarioId,
                respuesta.PreguntaId 
                );

                
                respuesta.Id = outId;
                Bol.Respuesta.ActulizarPreguntaId(respuesta.PreguntaId, respuesta.Id);
                return respuesta.Id;
            }
            catch (Exception) { throw new Exception("Error en Insert  Respuesta"); }
        }

        private static void ActulizarPreguntaId(int preguntaId, int RespuestaId)
        {
            {
                try
                {
                    new Dal.Core.Respuesta().ActulizarPreguntaId(preguntaId, RespuestaId);
                }
                catch (Exception)
                {
                    throw new Exception("Error en Insert rel Pregunta");
                }
            }
        }

        #endregion
    }
}
