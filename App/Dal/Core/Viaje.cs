﻿using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Core
{
    public class Viaje : DalBase
    {
        private const string INSERT_VIAJE = @"INSERT INTO Viajes
			                                        (CiudadOrigenId,
			                                        CiudadDestinoId,
			                                        Duracion,
			                                        VehiculoId,
			                                        Precio,
			                                        FechaSalida,
                                                    HoraSalida,
			                                        LugaresDisponibles,
			                                        Descripcion)
                                                output INSERTED.Id
                                                VALUES
			                                        (@parOrigenId,
			                                        @parDestinoId,
			                                        @parDuracion,
			                                        @parVehiculoId,
			                                        @parPrecio,			
			                                        @parFechaSalida,
                                                    @parHoraSalida,
			                                        @parLugaresDisponibles,           
			                                        @parDescripcion)";

        private const string GET_INSTANCE_BY_ID = @"SELECT * FROM Viajes
	                                                WHERE Id = {0}";

        private const string GET_ALL = @"SELECT * FROM Viajes";

        private const string GET_ALL_BY_VEHICULO_ID = @"select * from Viajes where VehiculoId = {0}";

        private const string GET_ALL_FROM_NOW_TO_ONE_MONTH = @"SELECT * FROM Viajes
		                                                                WHERE FechaSalida BETWEEN '{0}' AND '{1}'
							                                            ORDER BY FechaSalida";

        public int Create(int origenId, int destinoId, string duracion, int lugaresDisponibles, int vehiculoId, DateTime fechaSalida, string horaSalida, double precio, string descripcion)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_VIAJE;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parOrigenId", origenId);

            this.ExecuteParameters.Parameters.AddWithValue("@parDestinoId", destinoId);

            this.ExecuteParameters.Parameters.AddWithValue("@parDuracion", duracion);

            this.ExecuteParameters.Parameters.AddWithValue("@parLugaresDisponibles", lugaresDisponibles);

            this.ExecuteParameters.Parameters.AddWithValue("@parVehiculoId", vehiculoId);

            this.ExecuteParameters.Parameters.AddWithValue("@parFechaSalida", fechaSalida);

            this.ExecuteParameters.Parameters.AddWithValue("@parHoraSalida", horaSalida);

            this.ExecuteParameters.Parameters.AddWithValue("@parPrecio", precio);

            this.ExecuteParameters.Parameters.AddWithValue("@parDescripcion", descripcion);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        public DataSet GetInstanceById(int id)
        {
            this.SelectCommandText = string.Format(GET_INSTANCE_BY_ID, id);
            return this.Load();
        }

        //TODO ESTA COMO EL OJETE
        public DataSet GetAllFromNowToOneMonth(DateTime fechaActual, DateTime fechaUnMes)
        {
            this.SelectCommandText = string.Format(GET_ALL_FROM_NOW_TO_ONE_MONTH, fechaActual.ToString("yyyy-MM-dd"), fechaUnMes.ToString("yyyy-MM-dd"));
            return this.Load();
        }

        public DataSet GetAll()
        {
            this.SelectCommandText = string.Format(GET_ALL);
            return this.Load();
        }

        public DataSet GetAllViajesByVehiculoId(int id)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_VEHICULO_ID, id);
            return this.Load();
        }
    }
}

