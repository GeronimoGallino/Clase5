using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Negocio
{
    internal class Usuario
    {
        private string nombre;
        private string password;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public bool Borrado { get; set; }
        
        private int idPerfil    ;

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public Usuario()
        {
            nombre = password = string.Empty;
        }
        public Usuario(string nombre, string password)
        {
            this.nombre = nombre;
            this.password = password;
        }
        public int validar()
        {
            string consultaSQL = "SELECT * FROM Usuarios WHERE usuario='"
                                 + this.Nombre + "' AND password='"
                                 + this.Password + "'";
            DBHelper oDB = new DBHelper();
            DataTable tabla = new DataTable();
            tabla = oDB.consultarDB(consultaSQL);
            if (tabla.Rows.Count == 0)
                return 0;
            else
                return (int)tabla.Rows[0][0];
        }
        public DataTable RecuperarTodos()
        {
            DataTable tabla = new DataTable();

            string consultaSQL = "SELECT * FROM Usuarios WHERE borrado=0";
            DBHelper oDB = new DBHelper();
            tabla = oDB.consultarDB(consultaSQL);

            return tabla;
        }
    }
}
