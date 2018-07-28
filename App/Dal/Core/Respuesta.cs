using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Core
{
    public class Respuesta : DalBase
    {
        private const string INSERT_RESPUESTA = @" insert into Respuesta
                                                     (Descripcion,Fecha,PreguntaId,UsuarioId)
                                                     output INSERTED.Id
                                                     values
                                                     (@parDescripcion,@parFecha,@parPreguntaId,@parUsuarioId)";

        private const string GET_ALL_BY_VIAJE_ID = @"select * from Respuesta where ViajeId = {0}";

        private const string LOAD = @"select * from Respuesta where Id = {0}";

        private const string Update_Pregunta = @"update pregunta set RespuestaId = @parRespuestaId where Id = @parPreguntaId;";


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

        public DataSet GetAllByViajeId(int id)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_VIAJE_ID, id);
            return this.Load();
        }

        public DataSet GetInstanceById(int? id)
        {
            this.SelectCommandText = string.Format(LOAD, id);
            return this.Load();
        }

        public void ActulizarPreguntaId(int preguntaId, int parRespuestaId)
        {
            //query a ejecutar
            this.ExecuteCommandText = Update_Pregunta;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            this.ExecuteParameters.Parameters.AddWithValue("@parRespuestaId", preguntaId);
            this.ExecuteParameters.Parameters.AddWithValue("@parPreguntaId", preguntaId);

            //ejecución, retorna el valor del parámetro de retorno
            this.ExecuteNonQuery();
        }
    }
}

