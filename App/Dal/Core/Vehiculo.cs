using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Core
{
    public class Vehiculo : DalBase
    {
        #region " Query SQL "

        private const string GET_ALL_BY_USUARIO_ID = @"Select * from Vehiculos where UsuarioId = {0} ";

        private const string INSERT_VEHICULO = @"INSERT INTO Vehiculos
                                                               (Marca,
                                                               Modelo,
                                                               Color,
                                                               Patente,
                                                               Asientos,
                                                               UsuarioId)
	                                                        output INSERTED.Id
                                                        VALUES
			                                                   (@parColor,
			                                                   @parMarca,
			                                                   @ParModelo,
			                                                   @ParPatente,
			                                                   @parAsientosDisponibles,
			                                                   @parUsuarioId)";

        private const string UPDATE_VEHICULO = @"UPDATE Vehiculos SET 
                                                            Marca = @parColor,
                                                            Modelo = @parMarca,
                                                            Color = @ParModelo,
                                                            Patente = @ParPatente,
                                                            Asientos = parAsientosDisponibles
                                                        WHERE Id = @parVehiculoId";

        #endregion

        #region " Views "

        public DataSet GetAllByUsuarioId(int id)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_USUARIO_ID, id);
            return this.Load();
        }

        #endregion

        #region " CRUD "
        public int Create(string color,
                          string marca,
                          string modelo,
                          string patente,
                          int asientosDisponibles,
                          int vehiculoId)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_VEHICULO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parColor", color);

            this.ExecuteParameters.Parameters.AddWithValue("@parMarca", marca);

            this.ExecuteParameters.Parameters.AddWithValue("@ParModelo", modelo);

            this.ExecuteParameters.Parameters.AddWithValue("@ParPatente", patente);

            this.ExecuteParameters.Parameters.AddWithValue("@parAsientosDisponibles", asientosDisponibles);

            this.ExecuteParameters.Parameters.AddWithValue("@parVehiculoId", vehiculoId);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        public void Update(string color, string marca, string modelo, string patente, int asientosDisponibles, int usuarioId)
        {
            this.ExecuteCommandText = UPDATE_VEHICULO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros
            //documento
            this.ExecuteParameters.Parameters.AddWithValue("@parColor", color);

            this.ExecuteParameters.Parameters.AddWithValue("@parMarca", marca);

            this.ExecuteParameters.Parameters.AddWithValue("@ParModelo", modelo);

            this.ExecuteParameters.Parameters.AddWithValue("@ParPatente", patente);

            this.ExecuteParameters.Parameters.AddWithValue("@parAsientosDisponibles", asientosDisponibles);

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);

            //ejecución
            this.ExecuteNonQuery();
        }



        #endregion

    }
}
