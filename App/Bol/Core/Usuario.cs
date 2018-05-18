using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dal.Core;

namespace Bol
{
    [Serializable]
    public class Usuario
    {
        #region " atributes "

        private int _id;
        private int _codigo;
        private string _descripcion;
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private string _email;
        private string _nombreUsuario;
        private string _contraseña;
        private Chofer _chofer;
        private Pasajero _pasajero;
        private string _dni;
        private bool _siActivo;

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

        public string Dni
        {
            get
            {
                return _dni;
            }
            set
            {
                _dni = value;
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
        /// Nombre de la persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        /// <summary>
        /// Apellido de la persona
        /// </summary>
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
        /// Fecha de nacimiento de la persona
        /// </summary>
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        /// <summary>
        /// email de la Usuario
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        #endregion

        #region " Constructor "

        public Usuario() { }
        
        public  Usuario (string nombre, string apellido, string email, DateTime fechaNacimiento, string nombreUsuario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
            this.NombreUsuario = nombreUsuario;
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
        /// Recupera una lista con todas los Usuario
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
        /// Obtengo el Usuario del Id.
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
        /// Este metodo crea un usuario en la base
        /// </summary>
        /// <param name="Usuario">persona que se quiere crear</param>
        /// <returns>retorna el id de la persona en caso de exito -1 en caso que no se haya agregado</returns>
        public static int Create(Usuario usuario)
        {
            int outId = 0;
            try
            {
                //Objetos
                int? ChoferId = null;
                if (usuario.Chofer != null)
                    ChoferId = usuario.Chofer.Id;

                outId = new Dal.Core.Usuario().Create(
                    usuario.NombreUsuario,
                    usuario.Nombre,
                    usuario.Apellido,                   
                    usuario.Dni,
                    usuario.FechaNacimiento,
                    usuario.Email,                    
                    usuario.Contraseña,
                    usuario.SiActivo                    
                    );            
                                   
                usuario.Id = outId;
                return outId;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        /// <summary>
        /// este metodo actualiza un Usuario en la base
        /// </summary>
        /// <param name="Usuario">Usuario que se quiere actualizar</param>
        internal static void Update(Usuario usuario)
        {
            try
            {
                ////Objetos
                //int? ObjetoId = null;
                //if (usuario.Chofer != null)
                //    ObjetoId = usuario.Chofer.Id;

                //new Dal.Core.Usuario().Create(usuario.Nombre,
                //    usuario.Nombre,
                //    usuario.Apellido,
                //    ObjetoId,
                //    usuario.FechaNacimiento,
                //    usuario.Contraseña);
            }
            catch (Exception e) { throw new Exception("Error en Update" + e.Message); }
        }

        #endregion
    }
}
