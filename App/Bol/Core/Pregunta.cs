﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Bol
{
    [Serializable]
    public class Pregunta
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;       
        private int _viajeId;
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

        public int Fecha
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



        #endregion

        #region " Views "
        #endregion

        #region " Fill "

        private static Pregunta FillObject(DataRow dr)
        {
            Pregunta oBol = new Pregunta();

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

                if (dr.Table.Columns.Contains("ViajeId") && !Convert.IsDBNull(dr["ViajeId"]))
                    oBol._viajeId = Convert.ToInt32(dr["ViajeId"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol._usuarioId = Convert.ToInt32(dr["UsuarioId"]);

                if (dr.Table.Columns.Contains("Fecha") && !Convert.IsDBNull(dr["Fecha"]))
                    oBol.Fecha = Convert.ToInt32(dr["Fecha"]);

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        /// <summary>
        /// Recupera una lista con todas los Usuario
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<Pregunta> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;

        }

        #endregion

        #region " CRUD "

        public static int Create(Pregunta respuesta)
        {
            int outId = 0;
            try
            {

                outId = new Dal.Core.Pregunta().Create(
                respuesta.Fecha,
                respuesta.Descripcion,
                respuesta._usuarioId,
                respuesta._viajeId
                );

                respuesta.Id = outId;
                return respuesta.Id;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        #endregion

    }
}
