using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Dal
{
    public class DalBase
    {
        #region Variables, Fields, Enumerations

        // Base provider
        // [NonSerialized()]
        protected static string ConnectionString = "localHost(Servidor)";

        // [NonSerialized()]
        // internal static SqlConnection new SqlConnection(ConnectionString) = new SqlConnection(ConnectionString);
        // [NonSerialized()]
        internal readonly DbProviderFactory BaseFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        //// Connection String
        //public static readonly String ConnectionString = ConfigurationManager.AppSettings["LitioConnectionString"].ToString(); 
        ////Connection 
        //public static readonly SqlConnection new SqlConnection(ConnectionString) = new SqlConnection(ConnectionString);

        // Select Command text
        private string _SelectCommandText;

        //Colección de parámetros para operaciones CRUD
        private SqlCommand _ExecuteParameters = new SqlCommand();

        private string _executeCommandText;

        #endregion

        #region Properties

        /// <summary>
        /// Command Text
        /// </summary>
        protected string SelectCommandText
        {
            get { return _SelectCommandText; }
            set { _SelectCommandText = value; }
        }

        /// <summary>
        /// Command Text para operaciones CRUD
        /// </summary>
        protected string ExecuteCommandText
        {
            get { return _executeCommandText; }
            set { _executeCommandText = value; }
        }

        /// <summary>
        /// Colección de parámetros para operaciones CRUD
        /// </summary>
        protected SqlCommand ExecuteParameters
        {
            get { return _ExecuteParameters; }
            set { _ExecuteParameters = value; }
        }

        #endregion

        public DalBase() { }

        #region Methods
        /// <summary>
        /// Virtual Load method
        /// </summary>
        /// <returns></returns>
        public virtual DataSet Load()
        {
            // Check select command text first 
            if (this.SelectCommandText == "")
                throw new Exception("You must provide SelectCommandText first. Review Framework documentation.");

            // Create Connection
            using (DbConnection con = this.BaseFactory.CreateConnection())
            {

                // assign ConnectionString
                con.ConnectionString = ConnectionString;

                // create Adapter
                DbDataAdapter da = this.BaseFactory.CreateDataAdapter();

                // create Command
                da.SelectCommand = this.BaseFactory.CreateCommand();

                // assign Command Text
                da.SelectCommand.CommandText = this.SelectCommandText;

                // assign connection
                da.SelectCommand.Connection = con;

                // Instance New DataSet
                DataSet ds = new DataSet();
                // open connection and execute command
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    da.Fill(ds);
                }
                finally
                {
                    con.Close();
                }

                // return DataSet
                return ds;
            }
        }

        /// <summary>
        /// Ejecuta una operación de inserción, devuelve el valor del parámetro de retorno, sino hubiera devuelva la cantidad de filas afectadas
        /// </summary>
        /// <returns></returns>
        public virtual int ExecuteNonEscalar()
        {
            //conexión al servidor
            SqlConnection con = new SqlConnection(ConnectionString);

            //comando a ejecutar
            SqlCommand command = new SqlCommand(ExecuteCommandText, con);
            command.CommandType = CommandType.Text;

            command.Parameters.Clear();

            //agrego los parámetros al comando
            foreach (SqlParameter p in ExecuteParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }


            //parámetro de retorno
            SqlParameter sp_return = new SqlParameter();
            sp_return.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(sp_return);

            int outputId = 0;

            try
            {
                //abro la conexión
                if (con.State != ConnectionState.Open)
                    con.Open();

                //retorno el párametro de retorno (es int.tryparse para que no falle si no hay valor de retorno, terminaría devolviendo 0, sirve para los update por ej o delete)
                //int.TryParse(sp_return.Value.ToString(), out outputId);
                outputId = (int)command.ExecuteScalar();
            }
            //error de SQL
            catch (SqlException exc)
            {
                //en caso de error disparo excepción
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //error general
            catch (Exception exc2)
            {
                //en caso de error disparo excepción
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {

                //cierro la conexión
                con.Close();
            }

            return outputId;
        }

        /// <summary>
        /// Ejecuta una operación de actualización, devuelve el valor del parámetro de retorno, sino hubiera devuelva la cantidad de filas afectadas
        /// </summary>
        /// <returns></returns>
        public virtual void ExecuteNonQuery()
        {
            //conexión al servidor
            SqlConnection con = new SqlConnection(ConnectionString);

            //comando a ejecutar
            SqlCommand command = new SqlCommand(ExecuteCommandText, con);
            command.CommandType = CommandType.Text;

            command.Parameters.Clear();

            //agrego los parámetros al comando
            foreach (SqlParameter p in ExecuteParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }


            //parámetro de retorno
            SqlParameter sp_return = new SqlParameter();
            sp_return.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(sp_return);


            try
            {
                //abro la conexión
                if (con.State != ConnectionState.Open)
                    con.Open();
                //ejecuto la sentencia
                command.ExecuteNonQuery();
            }
            //error de SQL
            catch (SqlException exc)
            {
                //en caso de error disparo excepción
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //error general
            catch (Exception exc2)
            {
                //en caso de error disparo excepción
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {
                //cierro la conexión
                con.Close();
            }
        }

        #endregion

    }//EndClass.
}//EndNamespace.