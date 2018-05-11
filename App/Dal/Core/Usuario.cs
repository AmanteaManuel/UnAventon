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
        private const string INSERT_PERSONA = @"INSERT INTO Persona (NumeroDocumento,
                                                    Sexo,
                                                    TipoDocumentoId,
                                                    Apellido,
                                                    Nombre,
                                                    DomicilioRealId,
                                                    FechaNacimiento,
                                                    Mail,
                                                    GUID)
                                                output INSERTED.PersonaId
                                                VALUES (@parDocumento,
                                                    @parSexo,
                                                    @parTipoDocumentoId,
                                                    @parApellido,
                                                    @parNombre,
                                                    @parDomicilioRealId,
                                                    @parFechaNacimiento,
                                                    @parMail,
                                                    @parGUID)";

        private const string GET_USUARIO_BY_ID = "Select * from Usuario where Id = {0}";

        #endregion

        #region " Views "

        /// <summary>
        /// metodo que recupera de la base una persona segun su id
        /// </summary>
        /// <param name="numeroDocumento">numero de documento de una persona</param>
        /// <returns>dataset con los datos de la persona</returns>
        public DataSet GetInstance(int id)
        {
            this.SelectCommandText = string.Format(GET_USUARIO_BY_ID, id);
            return this.Load();
        }

        #endregion

        #region " CRUD "

        public int Create(string nombre,
            string mail,
            string apellido,
            int? domicilioRealId,
            DateTime? fechaNacimiento,
            string numeroDocumento,
            int tipoDocumentoId,
            int sexo,
            string guid)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_PERSONA;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parDocumento", numeroDocumento);            
 

            //fechaNaciemiento
            if (fechaNacimiento != null && fechaNacimiento != DateTime.MinValue)
                this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", fechaNacimiento);
            else
                this.ExecuteParameters.Parameters.AddWithValue("@parFechaNacimiento", DBNull.Value);

            //mail
            if (mail != null)
                ExecuteParameters.Parameters.AddWithValue("@parMail", mail);
            else
                ExecuteParameters.Parameters.AddWithValue("@parMail", DBNull.Value);

            //domicilioRealId
            if (domicilioRealId != null)
                this.ExecuteParameters.Parameters.AddWithValue("@parDomicilioRealId", domicilioRealId);
            else
                this.ExecuteParameters.Parameters.AddWithValue("@parDomicilioRealId", DBNull.Value);           

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        #endregion
    }
}
