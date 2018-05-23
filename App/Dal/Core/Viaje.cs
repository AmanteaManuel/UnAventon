using Dal.Core.Support;
using System;
using System.Collections.Generic;
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
    }
}

