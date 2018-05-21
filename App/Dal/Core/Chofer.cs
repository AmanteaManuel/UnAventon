using Dal.Core.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Core
{
    public class Chofer : DalBase
    {

        #region " Query SQL "

        /// <summary>
        /// query que inserta en la base la relacion entre el pasajero y el suuairo
        /// </summary>
        private const string INSERT_USUARIO = @"INSERT INTO Chofer (
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
            this.ExecuteCommandText = INSERT_USUARIO;

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
