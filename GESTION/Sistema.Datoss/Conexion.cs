using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Sistema.Datoss
{
   public  class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion con = null;

        private Conexion()
        {
            this.Base = "lasuertedominicana01";
            this.Servidor = "LENOVO-PC";
            this.Usuario = "sa";
            this.Clave = "adrianespinal8297204399";
            this.Seguridad = true;

        }
        public SqlConnection CrarConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +"; Database =" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {// para indicar que se va a usar la autenticacion de windows 
                    Cadena.ConnectionString = Cadena.ConnectionString + "User id =" + this.Usuario + "Password=" + this.Clave;
                }
            }
            catch (Exception ex)
            {

                Cadena = null;
                throw ex;


            }
            return Cadena;

        } // metodo para verificar si ya hay una instancia de esta clase y si no se crear una instancia nueva
        public static Conexion gestInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }

    }
}
