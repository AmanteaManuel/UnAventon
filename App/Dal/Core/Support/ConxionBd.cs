using System;
using System.Data.SqlClient;

namespace Dal.Core.Support
{
    public class ConxionBd
    {
        //Cadena de conexion de la base de datos
        string cadena = "Data Source=(localdb)\\Servidor;Initial Catalog=UnAventon; Integrated Security=True";

        public SqlConnection conectarbd = new SqlConnection();

        /// <summary>
        /// constructor
        /// </summary>
        public ConxionBd()
        {
            conectarbd.ConnectionString = cadena;
        }

        /// <summary>
        /// Metodo que abre la conexion a la base de datos.
        /// </summary>
        public void open()
        {
            try
            {
                conectarbd.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al abrir la conexión en la base de datos. "+ ex.Message);
            }
        }

        /// <summary>
        /// Metodo que cierra la conexion a la base de datos.
        /// </summary>
        public void Close()
        {
            try
            {
                conectarbd.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al cerrar la conexión en la base de datos. " + ex.Message);
            }
           
        }

        /// <summary> 
        /// Ejecuta un comando SQL y retorna un parámetro 
        /// </summary> 
        /// <param name="sComandoSql">Comando SQL</param> 
        public string EjecutaSQLScalar(string sComandoSql)
        {
            string regreso = "";
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand sqlCom = new SqlCommand();
            try
            {                
                sqlConn.Open();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandText = sComandoSql;
                regreso = sqlCom.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al ejecutarquery en la base de datos. " + ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return regreso;
        }

        /// <summary> 
        /// Ejecuta un comando SQL 
        /// </summary> 
        /// <param name="sComandoSql">Comando SQL para ejecutar Insert, Delete y Update</param> 
        public void EjecutaSQLComando(string sComandoSql)
        {
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand sqlCom = new SqlCommand();
            try
            {               
                sqlConn.Open();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandText = sComandoSql;
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ejecutar query en la base de datos. " + ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

    }
}
