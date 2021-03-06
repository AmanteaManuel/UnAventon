﻿using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Core
{
    public class Pregunta : DalBase
    {
        private const string INSERT_PREGUNTA = @" Insert into Pregunta 
                                                    (Descripcion,Fecha,ViajeId,UsuarioId) 
                                                    output INSERTED.Id
                                                    values
                                                    (@parDescripcion,
                                                    @parFecha,
                                                    @parViajeId,
                                                    @parUsuarioId)";

        private const string GET_ALL_BY_VIAJE_ID = @"select * from Pregunta where ViajeId = {0}";

        private const string LOAD = @"select * from Pregunta where Id = {0}";

        public int Create(DateTime fecha, string descripcion, int usuarioId, int viajeId)
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

        public DataSet GetAllByViajeId(int id)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_VIAJE_ID, id);
            return this.Load();
        }

        public DataSet GetInstanceById(int id)
        {
            this.SelectCommandText = string.Format(LOAD, id);
            return this.Load();
        }
    }
}
