using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Negocio
{
    class Criticidad
    {
        public int IdCriticidad { get; set; }
        public string Nombre { get; set; }
        public bool Borrado { get; set; }

        public DataTable RecuperarTodos()
        {
            string consulta = "SELECT * FROM Criticidades WHERE borrado = 0 order by 2";

            DBHelper oDatos = new DBHelper();
            return oDatos.consultarDB(consulta);
        }
    }
}
