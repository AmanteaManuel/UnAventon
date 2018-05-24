using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Core
{
    [Serializable]
    public class Provincia
    {

        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private Respuesta _respuesta;

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

        #endregion

        #region " Views "

        public static List<Provincia> GetAll()
        {
            try
            {
                Dal.Core.Provincia dal = new Dal.Core.Provincia();
                DataSet ds = dal.GetAll();
                return FillList(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar una la lista. " + ex.Message);
            }
        }

    

        #endregion

        #region " Fill "

        private static Provincia FillObject(DataRow dr)
        {
            Provincia oBol = new Provincia();

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

            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        /// <summary>
        /// Recupera una lista con todas los Usuario
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<Provincia> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
                        
        }

        #endregion
    }
}

