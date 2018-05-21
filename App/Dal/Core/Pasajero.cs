using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dal.Core.Support;

namespace Dal.Core
{
    public class Pasajero : DalBase
    {
        #region " Query SQL "

        /// <summary>
        /// query que inserta en la base la relacion entre el pasajero y el suuairo
        /// </summary>
        private const string INSERT_PASAJERO = @"INSERT INTO Pasajero (
                                                    UsuarioId,
                                                    Reputacion
                                                    )
                                                output INSERTED.Id
                                                VALUES (@parUsuarioId,
                                                    @parReputacion)";


        #endregion

        #region " Views "
        
        #endregion

        #region " CRUD "

        public int Create(int usuarioId, int reputacion)
        {
            //query a ejecutar
            this.ExecuteCommandText = INSERT_PASAJERO;

            //Limpio los parámetros
            this.ExecuteParameters.Parameters.Clear();

            //parámetros

            this.ExecuteParameters.Parameters.AddWithValue("@parUsuarioId", usuarioId);
            this.ExecuteParameters.Parameters.AddWithValue("@parReputacion", reputacion);

            //ejecución, retorna el valor del parámetro de retorno
            return this.ExecuteNonEscalar();
        }

        #endregion
    }
}
