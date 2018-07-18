using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Dal.Core
{
    public class Usuario : DalBase
    {

        #region " Query SQL "

        /// <summary>
        /// query que inserta en la base una persona
        /// </summary>
        private const string INSERT_USUARIO = @"INSERT INTO Usuario (                                                    
                                                    Nombre,
                                                    Apellido,
                                                    Dni,
                                                    FechaNacimiento,
                                                    Email,
                                                    Contraseña,
                                                    SiActivo,
                                                    ReputacionChofer,
                                                    ReputacionPasajero
                                                    )
                                                output INSERTED.Id
                                                VALUES (                                                   
                                                    @parNombre,
                                                    @parApellido,
                                                    @parDni,
                                                    @parFechaNacimiento,
                                                    @parEmail,
                                                    @parContraseña,
                                                    @parSiActivo,
                                                    @parReputacionChofer,
                                                    @parReputacionPasajero
                                                    )";

        private const string UPDATE_USUARIO = @"UPDATE Usuario SET 
				                                        Nombre = @parNombre,
				                                        Apellido = @parApellido,
				                                        Dni = @parDni,
				                                        FechaNacimiento = @parFechaNacimiento,
				                                        Email = @parEmail,
				                                        Contraseña = @parContraseña
				                                    WHERE Id = @parUsuarioId";

        private const string GET_USUARIO_BY_ID = @"Select * from Usuario where Id = {0}";

        private const string GET_USUARIO_BY_EMAIL = @"Select * from Usuario where Email = '{0}'";

        private const string GET_PASAJEROS_BY_VIAJE_ID = @"SELECT * FROM Postulantes WHERE viajeId = {0} AND EstadoViaje = 2";

        private const string GET_POSTULANTES_BY_VIAJE_ID = @"SELECT * FROM Postulantes WHERE viajeId = {0}";

        private const string CREATE_POSTULACION = @"INSERT INTO Postulantes (UsuarioId, ViajeId, EstadoViaje, SiCalificado) 
				                                                     output INSERTED.UsuarioId
				                                                     VALUES (@parUsuarioId,@parViajeId, 1, 0)";

        private const string ACEPTAR_POSTULACION = @"UPDATE Postulantes
                                                            SET EstadoViaje = @parEstado
                                                            WHERE UsuarioId = @parUsuarioId AND ViajeId = @parViajeId";

        private const string RECHAZAR_POSTULACION = @"UPDATE Postulantes
                                                            SET EstadoViaje = @parEstado
                                                            WHERE UsuarioId = @parUsuarioId AND ViajeId = @parViajeId";

        private const string GET_POSTULANTE_BY_VIAJE_ID = @"SELECT * FROM Postulantes 
                                              Where UsuarioId = {0} AND ViajeId = {1}";

        private const string DELETE_POSTULACION = @"DELETE FROM postulantes where UsuarioId = @parUsuarioId AND ViajeId = @parViajeId";

        private const string RESTAR_REPUTACION_CHOFER = @"UPDATE Usuario
                                                            SET ReputacionChofer = ReputacionChofer-1
                                                            WHERE Id = @parUsuarioId";

        private const string GET_PASAJEROS_BY_USUARIO_ID = @"select * from Viajes v 
                                                                INNER JOIN Postulantes p on p.ViajeId = v.Id
                                                                where p.UsuarioId = {0}";

        private const string CAMBIAR_FOTO_PERFIL = @"UPDATE Usuario
                                                        SET FotoPerfil = @parPath
                                                        WHERE Id = @parUsuarioId;";

        private const string SUMAR_REPUTACION_CHOFER = @"UPDATE Usuario
                                                            SET ReputacionChofer = ReputacionChofer + 1
                                                            WHERE Id = @parUsuarioId";

        private const string SUMAR_REPUTACION_PASAJERO = @"UPDATE Usuario
	                                                        SET ReputacionPasajero = ReputacionPasajero + 1
	                                                        WHERE Id = @parUsuarioId";

        private const string RESTAR_REPUTACION_PASAJERO = @"UPDATE Usuario
	                                                            SET ReputacionPasajero = ReputacionPasajero - 1
	                                                            WHERE Id = @parUsuarioId";

        private const string ELIMINAR_USUARIO = @"UPDATE Usuario SET SiActivo = 0, Email = null
	                                                WHERE Id = {0}";

        private const string INSERT_CALIFICACION = @"INSERT INTO Calificaciones (Comentario,puntaje,UsuarioId)
                                                        VALUES (@parUsuarioId,@parcomentario,@parsiCalificacionBueno)";


        #endregion

        #region " Views "

        /// <summary>
        /// metodo que recupera de la base una persona segun su id
        /// </summary>
        /// <param name="numeroDocumento">numero de documento de una persona</param>
        /// <returns>dataset con los datos de la persona</returns>
        public DataSet GetInstanceById(int id)
        {
            this.SelectCommandText = string.Format(GET_USUARIO_BY_ID, id);
            return this.Load();
        }

        public DataSet GetUsuarioByEmail(string email)
        {            
            this.SelectCommandText = string.Format(GET_USUARIO_BY_EMAIL, email);
            return this.Load();     
        }

        public DataSet GetAll()
        {
            throw new NotImplementedException();
        }

        public DataSet GetPostulacionesByUsuarioId(int id)
        {
            this.SelectCommandText = string.Format(GET_PASAJEROS_BY_USUARIO_ID, id);
            return this.Load();
        }

        public DataSet GetPostulantesByViajeId(int id)
        {
            this.SelectCommandText = string.Format(GET_POSTULANTES_BY_VIAJE_ID, id);
            return this.Load();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="viajeId"></param>
        /// <returns></returns>
        public DataSet GetUsuarioByViajeId(int userid, int viajeId)
        {
            this.SelectCommandText = string.Format(GET_POSTULANTE_BY_VIAJE_ID, userid, viajeId);
            return this.Load();
        }

        #endregion

        #region " CRUD "

        public int Create(            
            string nombre,
            string apellido,
            string dni,
            DateTime fechaNacimiento,
            string email,            
            string contraseña,
            bool siActivo ,
            int ReputacionChofer,
            int ReputacionPasajero
            )
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_USUARIO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", nombre);

            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", apellido);

            this.ExecuteParameters.Parameters.AddWithValue("@parDni", dni);

            this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", fechaNacimiento);

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", email);

            this.ExecuteParameters.Parameters.AddWithValue("@parContraseña", contraseña);

            this.ExecuteParameters.Parameters.AddWithValue("@parSiActivo", siActivo);

            this.ExecuteParameters.Parameters.AddWithValue("@parReputacionChofer", ReputacionChofer);

            this.ExecuteParameters.Parameters.AddWithValue("@parReputacionPasajero", ReputacionPasajero);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        public void Update(            
            string nombre,
            string apellido,
            string dni,
            DateTime fechaNacimiento,
            string email,
            string contraseña,
            int usuarioId)
        {
            //query a ejecutar
            this.ExecuteCommandText = UPDATE_USUARIO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", nombre);

            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", apellido);

            this.ExecuteParameters.Parameters.AddWithValue("@parDni", dni);

            this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", fechaNacimiento);

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", email);

            this.ExecuteParameters.Parameters.AddWithValue("@parContraseña", contraseña);

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);


            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        /// <summary>
        /// Metodo que crea una postulacion  y retorna el id del usuario postulado
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="viajeId"></param>
        /// <returns></returns>
        public int CreatePostulacion(int usuarioId, int viajeId)
        {
            //query a ejecutar
            this.ExecuteCommandText = CREATE_POSTULACION;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();
           
            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parViajeId", viajeId);


            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        public void AceptarPostulacion(int usuarioId, int viajeId)
        {
            //query a ejecutar
            this.ExecuteCommandText = ACEPTAR_POSTULACION;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parViajeId", viajeId);

            this.ExecuteParameters.Parameters.AddWithValue("@parEstado", 2);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void RechazarPostulacion(int usuarioId, int viajeId)
        {
            //query a ejecutar
            this.ExecuteCommandText = RECHAZAR_POSTULACION;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parViajeId", viajeId);

            this.ExecuteParameters.Parameters.AddWithValue("@parEstado", 3);


            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void EliminarPostulacion(int usuarioId, int viajeId)
        {
            this.ExecuteCommandText = DELETE_POSTULACION;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parViajeId", viajeId);            

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void RestarReputacionChofer(int usuarioId)
        {
            this.ExecuteCommandText = RESTAR_REPUTACION_CHOFER;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);            

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void CambiarFotoPerfil(string path, int usuarioId)
        {
            this.ExecuteCommandText = CAMBIAR_FOTO_PERFIL;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parPath", path);
            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }



        public void SumarReputacionChofer(int usuarioId)
        {
            this.ExecuteCommandText = SUMAR_REPUTACION_CHOFER;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void EliminarUsuario(int id)
        {
            this.ExecuteCommandText = ELIMINAR_USUARIO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", id);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void SumarReputacionPasajero(int usuarioId)
        {
            this.ExecuteCommandText = SUMAR_REPUTACION_PASAJERO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void RestarReputacionPasajero(int usuarioId)
        {
            this.ExecuteCommandText = RESTAR_REPUTACION_PASAJERO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        public void InsertCalificacion(int usuarioId, string comentario, bool siCalificacionBueno)
        {
            this.ExecuteCommandText = INSERT_CALIFICACION;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);
            this.ExecuteParameters.Parameters.AddWithValue("@parcomentario", comentario);
            this.ExecuteParameters.Parameters.AddWithValue("@parsiCalificacionBueno", siCalificacionBueno);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }

        #endregion

        #region " Method "



        #endregion
    }
}
