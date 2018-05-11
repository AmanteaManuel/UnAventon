using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dal.Core;

namespace Bol
{
    [Serializable]
    public class Usuario : Persona
    {
        #region " atributes "

        private string _nombreUsuario;
        private string _contraseña;
        private Chofer _chofer;
        private Pasajero _pasajero;

        #endregion

        #region " Properties "

        /// <summary>
        /// nombre de usuario en el sistema
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }


        public Chofer Chofer
        {
            get
            {
                return _chofer;
            }
            set
            {
                _chofer = value;
            }
        }

        public Pasajero Pasajero
        {
            get
            {
                return _pasajero;
            }
            set
            {
                _pasajero = value;
            }
        }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Contraseña
        {
            get
            {
                return _contraseña;
            }
            set
            {
                _contraseña = value;
            }
        }

        #endregion

        #region " Constructor "

        public Usuario() { }
        
        public  Usuario (string nombre, string apellido, string mail)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = mail;
            //todos los campos;
        }
        #endregion

        #region " Fill "

        internal static Usuario FillObject(DataRow dr)
        {
            Usuario oBol = new Usuario();

            try
            {
                //ID
                if (dr.Table.Columns.Contains("PersonaId") && !Convert.IsDBNull(dr["PersonaId"]))
                    oBol.Id = Convert.ToInt32(dr["PersonaId"]);

                //Apellido
                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    oBol.Apellido = Convert.ToString(dr["Apellido"]);

                //Nombre
                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    oBol.Nombre = Convert.ToString(dr["Nombre"]);




            }
            catch (Exception ex) { throw new Exception("Error en el metodo Fill" + ex.Message); }

            return oBol;
        }

        /// <summary>
        /// Recupera una lista con todas las personas
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<Usuario> FillList(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return null;
               // return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
            return null;
        }

        #endregion

        #region " View "

        public static List<Usuario> GetAll()
        {
            try
            {
                Dal.Core.Usuario dal = new Dal.Core.Usuario();
                DataSet ds = dal.GetAll();
                return FillList(ds);
            }
            catch (Exception ex) { throw new Exception("Error al generar una la lista. " + ex.Message); }
        }

        /// <summary>
        /// Obtengo la persona del Id.
        /// </summary>
        /// <param name="personaId"></param>
        /// <returns></returns>
        internal Usuario GetInstanceById(int usuarioId)
        {
            return FillObject(
                (new Dal.Core.Usuario().GetInstanceById(usuarioId)).Tables[0].Rows[0]);
        }

        #endregion

        #region " CRUD "

        /// <summary>
        /// Este metodo crea una persona en la base
        /// </summary>
        /// <param name="persona">persona que se quiere crear</param>
        /// <returns>retorna el id de la persona en caso de exito -1 en caso que no se haya agregado</returns>
        internal static int Create(Usuario usuario)
        {
            int outId = 0;
            try
            {
                //Objetos
                int? ChoferId = null;
                if (usuario.Chofer != null)
                    ChoferId = usuario.Chofer.Id;

                outId = new Dal.Core.Usuario().Create(usuario.Nombre,
                    usuario.Nombre,
                    usuario.Apellido,
                    ChoferId,
                    usuario.FechaNacimiento,
                    usuario.Contraseña);            
                                   
                usuario.Id = outId;
                return outId;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        /// <summary>
        /// este metodo actualiza una persona en la base
        /// </summary>
        /// <param name="persona">persona que se quiere actualizar</param>
        internal static void Update(Usuario usuario)
        {
            try
            {
                //Objetos
                int? ObjetoId = null;
                if (usuario.Chofer != null)
                    ObjetoId = usuario.Chofer.Id;

                new Dal.Core.Usuario().Create(usuario.Nombre,
                    usuario.Nombre,
                    usuario.Apellido,
                    ObjetoId,
                    usuario.FechaNacimiento,
                    usuario.Contraseña);
            }
            catch (Exception e) { throw new Exception("Error en Update" + e.Message); }
        }

        #endregion
    }
}
