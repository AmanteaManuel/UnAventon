using System;
using System.Collections.Generic;
using System.Text;


namespace Bol
{
    public class Chofer
    {
        #region " Atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private int _reputacion;

        
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

        /// <summary>
        /// propiedad que manejara la reputacion de un chofer
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
    }
}
