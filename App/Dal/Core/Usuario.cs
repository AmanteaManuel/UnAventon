﻿using System;
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

        private const string GET_PASAJEROS_BY_VIAJE_ID = @"SELECT * FROM Postulantes WHERE viajeId = {0} AND EstadoViajeCodigo = 2";

        private const string GET_POSTULANTES_BY_VIAJE_ID = @"SELECT * FROM Postulantes WHERE viajeId = {0} AND EstadoViajeCodigo != 2";

        private const string CREATE_POSTULACION = @"INSERT INTO Postulantes (UsuarioId, ViajeId, EstadoViaje) 
				                                                     output INSERTED.Id
				                                                     VALUES (@parUsuarioId,@parViajeId, 1)";

        private const string ACEPTAR_POSTULACION = @"UPDATE Postulantes
                                                            SET EstadoViaje = @parEstado
                                                            WHERE UsuarioId = @parUsuarioId AND ViajeId = @parViajeId";

        private const string RECHAZAR_POSTULACION = @"UPDATE Postulantes
                                                            SET EstadoViaje = @parEstado
                                                            WHERE UsuarioId = @parUsuarioId AND ViajeId = @parViajeId";

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

        public DataSet GetPasajerosByViajeId(int id)
        {
            this.SelectCommandText = string.Format(GET_PASAJEROS_BY_VIAJE_ID, id);
            return this.Load();
        }

        public DataSet GetPostulantesByViajeId(int id)
        {
            this.SelectCommandText = string.Format(GET_POSTULANTES_BY_VIAJE_ID, id);
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
        #endregion

        #region " Method "



        #endregion
    }
}
