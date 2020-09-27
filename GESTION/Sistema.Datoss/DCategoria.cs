using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;
using System.Data;

using System.Data.SqlClient;

namespace Sistema.Datoss
{
   public class DCategoria
    {

        //Funciones para poder manipular los datos referentes a la tabla categoria

        public DataTable Listar()
        { //funciona para devilver un datatable
            SqlDataReader Resultado; //Forma de leer una secuencia de filas de una BD en sql server
            DataTable tabla = new DataTable(); //El objeto datatable es una tabla en memoria
            SqlConnection SqlCon = new SqlConnection(); //instancia para la conexion
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();//para crear la instancia 
                SqlCommand comando = new SqlCommand("categoria_listar", SqlCon);//la clase sqlcomand representa un instruccion transac sql o a un procedimiento
                comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = comando.ExecuteReader();
                tabla.Load(Resultado);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                {

                }
            }
        }
        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado; //Forma de leer una secuencia de filas de una BD en sql server
            DataTable tabla = new DataTable(); //El objeto datatable es una tabla en memoria
            SqlConnection SqlCon = new SqlConnection(); //instancia para la conexion
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();//para crear la instancia 
                SqlCommand comando = new SqlCommand("categoria_buscar", SqlCon);//la clase sqlcomand representa un instruccion transac sql o a un procedimiento
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlCon.Open();
                Resultado = comando.ExecuteReader();
                tabla.Load(Resultado);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                {

                }
            }
        }
        public string Insertar(Categoria obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();
                SqlCommand comando = new SqlCommand("categoria_insertar", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro"; //para ejecura el comando
            }
            catch (Exception ex)
            {

                Rpta = ex.Message; ;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Actualizar(Categoria obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();
                SqlCommand comando = new SqlCommand("categoria_actualizar", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = obj.IdCategoria;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro"; //para ejecura el comando
            }
            catch (Exception ex)
            {

                Rpta = ex.Message; ;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();
                SqlCommand comando = new SqlCommand("categoria_eliminar", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;


                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro"; //para ejecura el comando
            }
            catch (Exception ex)
            {

                Rpta = ex.Message; ;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Activar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();
                SqlCommand comando = new SqlCommand("categoria_activar", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;


                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro"; //para ejecura el comando
            }
            catch (Exception ex)
            {

                Rpta = ex.Message; ;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.gestInstancia().CrarConexion();
                SqlCommand comando = new SqlCommand("categoria_desactivar", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;


                SqlCon.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar registro"; //para ejecura el comando
            }
            catch (Exception ex)
            {

                Rpta = ex.Message; ;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
