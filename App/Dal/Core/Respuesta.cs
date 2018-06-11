using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Core
{
    public class Respuesta : DalBase
    {
        private const string INSERT_RESPUESTA = @"INSERT INTO [dbo].[Respuesta]
                                                                   ([Descripcion]
                                                                   ,[Fecha]
                                                                   ,[PreguntaId]
                                                                   ,[UsuarioId])
                                                              VALUES
                                                                   (@parDescripcion,
		                                                           @parFecha,
		                                                           @parPreguntaId,
		                                                           @parUsuarioId)";


        public int Create(DateTime fecha, string descripcion, int usuarioId, int preguntaId)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_RESPUESTA;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parFecha", fecha);

            this.ExecuteParameters.Parameters.AddWithValue("@parDescripcion", descripcion);

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parPreguntaId", preguntaId);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }
    }
}

