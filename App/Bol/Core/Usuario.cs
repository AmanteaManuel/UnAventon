using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dal.Core;
using System.Linq;

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
        private int _reputacionChofer;
        private int _reputacioPasajero;
        int _estadoViaje;
        private string _estadoViajeDescripcion;
        private string _fotoPerfil;


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

        public string EstadoViajeDescripcion
        {
            get
            {
                return _estadoViajeDescripcion;
            }
            set
            {
                _estadoViajeDescripcion = value;
            }
        }

        //public Chofer Chofer
        //{
        //    get
        //    {
        //        return _chofer;
        //    }
        //    set
        //    {
        //        _chofer = value;
        //    }
        //}

        //public Pasajero Pasajero
        //{
        //    get
        //    {
        //        return _pasajero;
        //    }
        //    set
        //    {
        //        _pasajero = value;
        //    }
        //}

        public int ReputacionChofer
        {
            get
            {
                return _reputacionChofer;
            }
            set
            {
                _reputacionChofer = value;
            }
        }

        public int ReputacioPasajero
        {
            get
            {
                return _reputacioPasajero;
            }
            set
            {
                _reputacioPasajero = value;
            }
        }

        public int EstadoViaje
        {
            get
            {
                return _estadoViaje;
            }
            set
            {
                _estadoViaje = value;
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

        public string FotoPerfil
        {
            get
            {
                return _fotoPerfil;
            }
            set
            {
                _fotoPerfil = value;
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
                if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                    oBol.Id = Convert.ToInt32(dr["Id"]);

                if (dr.Table.Columns.Contains("UsuarioId") && !Convert.IsDBNull(dr["UsuarioId"]))
                    oBol.Id = Convert.ToInt32(dr["UsuarioId"]);

                //Apellido
                if (dr.Table.Columns.Contains("Apellido") && !Convert.IsDBNull(dr["Apellido"]))
                    oBol.Apellido = Convert.ToString(dr["Apellido"]);

                //Nombre
                if (dr.Table.Columns.Contains("Nombre") && !Convert.IsDBNull(dr["Nombre"]))
                    oBol.Nombre = Convert.ToString(dr["Nombre"]);

                if (dr.Table.Columns.Contains("Dni") && !Convert.IsDBNull(dr["Dni"]))
                    oBol.Dni = Convert.ToString(dr["Dni"]);

                if (dr.Table.Columns.Contains("FechaNacimiento") && !Convert.IsDBNull(dr["FechaNacimiento"]))
                    oBol.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    oBol.Email = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Contraseña") && !Convert.IsDBNull(dr["Contraseña"]))
                    oBol.Contraseña = Convert.ToString(dr["Contraseña"]);

                if (dr.Table.Columns.Contains("SiActivo") && !Convert.IsDBNull(dr["SiActivo"]))
                    oBol.SiActivo = Convert.ToBoolean(dr["SiActivo"]);

                if (dr.Table.Columns.Contains("ReputacionChofer") && !Convert.IsDBNull(dr["ReputacionChofer"]))
                    oBol.ReputacionChofer = Convert.ToInt32(dr["ReputacionChofer"]);

                if (dr.Table.Columns.Contains("EstadoViaje") && !Convert.IsDBNull(dr["EstadoViaje"]))
                    oBol.EstadoViaje = Convert.ToInt32(dr["EstadoViaje"]);

                if (dr.Table.Columns.Contains("ReputacionPasajero") && !Convert.IsDBNull(dr["ReputacionPasajero"]))
                    oBol.ReputacioPasajero = Convert.ToInt32(dr["ReputacionPasajero"]);

                if (dr.Table.Columns.Contains("FotoPerfil") && !Convert.IsDBNull(dr["FotoPerfil"]))
                    oBol.FotoPerfil = Convert.ToString(dr["FotoPerfil"]);


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
                return (from DataRow dr in ds.Tables[0].Rows select FillObject(dr)).ToList();
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
        public Usuario GetInstanceById(int usuarioId)
        {
            return FillObject(
                (new Dal.Core.Usuario().GetInstanceById(usuarioId)).Tables[0].Rows[0]);
        }

        public static Usuario GetUsuarioByEmail(string email)
        {
            DataSet userdr;
            userdr = new Dal.Core.Usuario().GetUsuarioByEmail(email);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillObject(userdr.Tables[0].Rows[0]);
            else
                return null;            
        }

        public static List<Usuario> GetPostulantesByViajeId(int id)
        {
            DataSet userdr;
            userdr = new Dal.Core.Usuario().GetPostulantesByViajeId(id);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillList(userdr);
            else
                return null; ;
        }

        public static Usuario GetPostulanteByViajeId(int Userid, int viajeId)
        {
            DataSet userdr;
            userdr = new Dal.Core.Usuario().GetUsuarioByViajeId(Userid, viajeId);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillObject(userdr.Tables[0].Rows[0]);
            else
                return null;
        }       

        /// <summary>
        /// Metodo que obtiene todos los postulantes de un viaje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Usuario> GetPasajerosByViajeId(int id)
        {
            DataSet userdr;
            userdr = new Dal.Core.Usuario().GetPostulacionesByUsuarioId(id);
            if (userdr.Tables[0].Rows.Count > 0)
                return FillList(userdr);
            else
                return null;
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
            //Bol.Usuario u = new Bol.Usuario().GetUsuarioByEmail(usuario.Email);

                outId = new Dal.Core.Usuario().Create(               
                usuario.Nombre,
                usuario.Apellido,
                usuario.Dni,
                usuario.FechaNacimiento,
                usuario.Email,
                usuario.Contraseña,
                usuario.SiActivo,
                0,
                0
                );

                usuario.Id = outId;

                //Bol.Pasajero.Create(usuario.Id);
                //Bol.Chofer.Create(usuario.Id);
                return usuario.Id;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        /// <summary>
        /// este metodo actualiza un Usuario en la base
        /// </summary>
        /// <param name="Usuario">Usuario que se quiere actualizar</param>
        public static void Update(Usuario usuario)
        {
            try
            {
                //Objetos
                new Dal.Core.Usuario().Update(
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Dni,
                    usuario.FechaNacimiento,
                    usuario.Email,
                    usuario.Contraseña,
                    usuario.Id);
            }
            catch (Exception e) { throw new Exception("Error en Update" + e.Message); }
        }

        /// <summary>
        /// metodo que crea un postulacion cuando el
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="viajeId"></param>
        /// <returns></returns>
        public static int CreatePostulacion(int usuarioId, int viajeId)
        {
            int outId = 0;
            try
            {
                outId = new Dal.Core.Usuario().CreatePostulacion(usuarioId, viajeId);                
                return outId;
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        /// <summary>
        /// Metodo que acepta un postulante al viaje
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="viajeId"></param>
        public static void AceptarPostulacion(int usuarioId, int viajeId)
        {            
            try
            {
                Usuario u = GetPostulanteByViajeId(usuarioId, viajeId);
                if (u != null)
                    new Dal.Core.Usuario().AceptarPostulacion(usuarioId, viajeId);
                else
                    throw new Exception("El usuario ya fue aceptado. ");
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        /// <summary>
        /// Metodo que rechaza un postulante al viaje
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="viajeId"></param>
        public static void RechazarPostulacion(int usuarioId, int viajeId)
        {            
            try
            {
               new Dal.Core.Usuario().RechazarPostulacion(usuarioId, viajeId);               
            }
            catch (Exception e) { throw new Exception("Error en Insert" + e.Message); }
        }

        public static void EliminarPostulacion(int usuarioId, int viajeId)
        {
            try
            {
                new Dal.Core.Usuario().EliminarPostulacion(usuarioId, viajeId);
            }
            catch (Exception e) { throw new Exception("Error en Eliminarion" + e.Message); }
        }

        public static void SumarReputacionChofer()
        {

        }

        public static void RestarReputacionChofer(int usuarioId)
        {
            try
            {
                new Dal.Core.Usuario().RestarReputacionChofer(usuarioId);
            }
            catch (Exception e) { throw new Exception("Error en Eliminarion" + e.Message); }
        }

        public static void ObtenerReputacionChofer(int usuarioId)
        {

        }

        public static void SumarReputacionPasajero(int usuarioId)
        {

        }

        public static void RestarReputacionPasajero(int usuarioId)
        {

        }

        public static void ObtenerReputacionPasajero(int usuarioId)
        {

        }

        public static void CambiarFotoPerfil(string path, int usuarioId)
        {
            try
            {
                new Dal.Core.Usuario().CambiarFotoPerfil(path, usuarioId);
            }
            catch (Exception e) { throw new Exception("Error al cambiar la foto de perfil"); }
        }

        #endregion

        #region " Method "

        //Meotod que autetica el usuario
        public Usuario IsAuthenticateUser(string username, string password)
        {
            try
            {
                Usuario user = Bol.Usuario.GetUsuarioByEmail(username);
                if (user != null)
                {
                    if (user.Contraseña == password && user.Email == username)
                        return user;
                    else
                        throw new Exception("Contraseña o email incorrectos");
                }
                else
                    throw new Exception("El usuario no existe");
            }
            catch (Exception ex)
            {
                throw new Exception("El usuario no existe");
            }
        }

        #endregion
    }
}
