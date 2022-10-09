using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppBTS.Datos
{
    internal class DBHelper
    {
        SqlConnection conexion;
        SqlCommand comando;
        //string cadenaConexion = @"Data Source=Maquis;Initial Catalog=BugTracker;User ID=avisuales1;password=Pav1#2020Maquis";
        string cadenaConexion = @"Data Source=CX-OSCAR\SQLEXPRESS;Initial Catalog=BTS;Integrated Security=True";

        public DataTable consultarDB(string consultaSQL)
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = cadenaConexion; 
            conexion.Open();

            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;  

            DataTable tabla= new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }
    }
}
