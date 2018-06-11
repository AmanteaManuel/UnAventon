using System;
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

        #endregion

        #region " Views "

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
                    oBol._preguntaId = Convert.ToInt32(dr["PreguntaId"]);

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
                respuesta._usuarioId,
                respuesta._preguntaId 
                );

                respuesta.Id = outId;
                return respuesta.Id;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        #endregion
    }
}
