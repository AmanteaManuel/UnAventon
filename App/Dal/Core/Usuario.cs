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
                                                    NombreUsuario,
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
                                                    @parNombreUsuario,
                                                    @parNombre,
                                                    @parApellido,
                                                    @parDni,
                                                    @parFechaNacimiento,
                                                    @parEmail,
                                                    @parContraseña,
                                                    @parSiActivo,
                                                    0,
                                                    0)";

        private const string UPDATE_USUARIO = @"UPDATE Usuario SET 
				                                        NombreUsuario = @parNombreUsuario,
				                                        Nombre = @parNombre,
				                                        Apellido = @parApellido,
				                                        Dni = @parDni,
				                                        FechaNacimiento = @parFechaNacimiento,
				                                        Email = @parEmail,
				                                        Contraseña = @parContraseña
				                                    WHERE UsuarioId = @parUsuarioId";

        private const string GET_USUARIO_BY_ID = "Select * from Usuario where Id = {0}";

        private const string GET_USUARIO_BY_EMAIL = "Select * from Usuario where Email = {0}";


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

        #endregion

        #region " CRUD "

        public int Create(
            string nombreUsuario,
            string nombre,
            string apellido,
            string dni,
            DateTime fechaNacimiento,
            string email,            
            string contraseña,
            bool siActivo               
            )
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_USUARIO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parNombreUsuario", nombreUsuario);

            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", nombre);

            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", apellido);

            this.ExecuteParameters.Parameters.AddWithValue("@parDni", dni);

            this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", fechaNacimiento);

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", email);

            this.ExecuteParameters.Parameters.AddWithValue("@parContraseña", contraseña);

            this.ExecuteParameters.Parameters.AddWithValue("@parSiActivo", siActivo);            
            
            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        public void Update(
            string nombreUsuario,
            string nombre,
            string apellido,
            string dni,
            DateTime fechaNacimiento,
            string email,
            string contraseña,
            bool siActivo)
        {
            //query a ejecutar
            this.ExecuteCommandText = UPDATE_USUARIO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parNombreUsuario", nombreUsuario);

            this.ExecuteParameters.Parameters.AddWithValue("@parNombre", nombre);

            this.ExecuteParameters.Parameters.AddWithValue("@parApellido", apellido);

            this.ExecuteParameters.Parameters.AddWithValue("@parDni", dni);

            this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", fechaNacimiento);

            this.ExecuteParameters.Parameters.AddWithValue("@parEmail", email);

            this.ExecuteParameters.Parameters.AddWithValue("@parContraseña", contraseña);

            this.ExecuteParameters.Parameters.AddWithValue("@parSiActivo", siActivo);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }



        #endregion
    }
}
