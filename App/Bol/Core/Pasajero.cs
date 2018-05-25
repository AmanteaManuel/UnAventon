using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bol
{
    [Serializable]
    public class Pasajero
    {
        #region " Atributes "

        private int _id;        
        private string _descripcion;
        private int _reputacion;
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
            set { _id = value; }
        }

        /// <summary>
        /// Identificador univoco de la bd
        /// </summary>
        public int UsuarioId
        {
            get
            {
                return _usuarioId;
            }
            set { _usuarioId = value; }
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
        /// propiedad que manejara la reputacion de un Pasajero
        /// </summary>
        public int Reputacion
        {
            get
            {
                return _reputacion;
            }
            set
            {
                _reputacion = value;
            }
        }

        #endregion

        #region " Views "

        /// <summary>
        /// Metodo que aumenta la reputacion 1 punto
        /// </summary>
        /// <param name="chofer"></param>
        public void SubirReputacion()
        {
            this.Reputacion = this.Reputacion ++;
        }

        /// <summary>
        /// Metodo que baja la reputacion 1 punto
        /// </summary>
        /// <param name="chofer"></param>
        public void BajarReputacion()
        {
            this.Reputacion = this.Reputacion --;
        }

        #endregion

        #region " Fill "

        internal static Pasajero FillObject(DataRow dr)
        {
            Pasajero oBol = new Pasajero();

            try
            {
                //ID
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    oBol.Id = Convert.ToInt32(dr["Id"]);

                //UsuarioID
                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);

                //Descripcion
                if (dr.Table.Columns.Contains("Descripcion") && !Convert.IsDBNull(dr["Descripcion"]))
                    oBol.Descripcion = Convert.ToString(dr["Descripcion"]);

                //Reputacion
                if (dr.Table.Columns.Contains("Reputacion") && !Convert.IsDBNull(dr["Reputacion"]))
                    oBol.Reputacion = Convert.ToInt32(dr["Reputacion"]);
            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        #endregion

        #region " CRUD "

        public static int Create(int usuarioId)
        {
            int outId = 0;
            try
            {
                int reputacion = 0;
                return outId = new Dal.Core.Pasajero().Create(usuarioId, reputacion);
            }
            catch (Exception e)
                { throw new Exception("Error en Insert" + e.Message); }
        }

        #endregion
    }
}

