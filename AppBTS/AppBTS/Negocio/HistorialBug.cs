using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Negocio
{
    class HistorialBug
    {
        public int IdBug { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Responsable { get; set; }
        public int Estado { get; set; }
        public int AsignadoA { get; set; }
        public int Prioridad { get; set; }
        public int Criticidad { get; set; }
        public int Producto { get; set; }

        public DataTable RecuperarHistorialPorId(int idBug)
        {
            string consulta = "SELECT h.fecha_historico,u.usuario as responsable,e.nombre as estado,us.usuario as asignadoA"
                            + " FROM (((BugsHistorico h"
                            + " LEFT JOIN Usuarios u ON h.id_usuario_responsable=u.id_usuario)"
                            + " JOIN Estados e ON h.id_estado=e.id_estado)"
                            + " LEFT JOIN Usuarios us ON h.id_usuario_asignado=us.id_usuario)"
                            + " WHERE h.id_bug=" + idBug;

            DBHelper oDatos = new DBHelper();
            return oDatos.consultarDB(consulta);
        }
    }
}
