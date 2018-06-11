using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Core
{
    class Pregunta : DalBase
    {
        private const string INSERT_PREGUNTA = @"INSERT INTO [dbo].[Respuesta]
                                                                   ([Descripcion]
                                                                   ,[Fecha]
                                                                   ,[PreguntaId]
                                                                   ,[UsuarioId])
                                                              VALUES
                                                                   (@parDescripcion,
		                                                           @parFecha,
		                                                           @parPreguntaId,
		                                                           @parUsuarioId)";

        public int Create(int fecha, string descripcion, int usuarioId, int viajeId)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_PREGUNTA;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parFecha", fecha);

            this.ExecuteParameters.Parameters.AddWithValue("@parDescripcion", descripcion);

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            this.ExecuteParameters.Parameters.AddWithValue("@parViajeId", viajeId);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }
    }
}
