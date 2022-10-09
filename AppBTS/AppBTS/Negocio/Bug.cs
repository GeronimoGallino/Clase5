using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Negocio
{
    class Bug
    {
        private int id_bug;
        private string titulo;
        private string descripcion;
        private DateTime fecha_alta;
        private int id_usuario_responsable;
        private int id_usuario_asignado;
        private int id_producto;
        private int id_prioridad;
        private int id_criticidad;
        private int id_estado;
        private bool borrado;

        public int Id_bug { get => id_bug; set => id_bug = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha_alta { get => fecha_alta; set => fecha_alta = value; }
        public int Id_usuario_responsable { get => id_usuario_responsable; set => id_usuario_responsable = value; }
        public int Id_usuario_asignado { get => id_usuario_asignado; set => id_usuario_asignado = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_prioridad { get => id_prioridad; set => id_prioridad = value; }
        public int Id_criticidad { get => id_criticidad; set => id_criticidad = value; }
        public int Id_estado { get => id_estado; set => id_estado = value; }
        public bool Borrado { get => borrado; set => borrado = value; }

        public DataTable RecuperarTodos()
        {
            string consulta = "SELECT b.id_bug,b.titulo,p.nombre as producto,b.fecha_alta,e.nombre as estado,u.usuario as asignado,c.nombre as criticidad,pr.nombre as prioridad"
                            + " FROM Bugs b, Productos p, Criticidades c, Prioridades pr, Usuarios u, Estados e"
                            + " WHERE b.id_producto=p.id_producto"
                            + " AND b.id_criticidad=c.id_criticidad"
                            + " AND b.id_prioridad=pr.id_prioridad"
                            + " AND b.id_usuario_asignado=u.id_usuario"
                            + " AND b.id_estado=e.id_estado"
                            + " AND b.borrado=0"
                            + " ORDER BY b.fecha_alta DESC";

            DBHelper oDatos = new DBHelper();
            return oDatos.consultarDB(consulta);
        }
        public DataTable RecuperarFiltrados(string desde,string hasta,string estado, string asignado, string prioridad, string criticidad, string producto)
        {
            string consulta = "SELECT b.id_bug,b.titulo,p.nombre as producto,b.fecha_alta,e.nombre as estado,u.usuario as asignado,c.nombre as criticidad,pr.nombre as prioridad"
                            + " FROM Bugs b, Productos p, Criticidades c, Prioridades pr, Usuarios u, Estados e"
                            + " WHERE b.id_producto=p.id_producto"
                            + " AND b.id_criticidad=c.id_criticidad"
                            + " AND b.id_prioridad=pr.id_prioridad"
                            + " AND b.id_usuario_asignado=u.id_usuario"
                            + " AND b.id_estado=e.id_estado"
                            + " AND b.borrado=0";
            consulta += " AND b.fecha_alta BETWEEN '" + desde + "' AND '" + hasta + "'";

            if (!string.IsNullOrEmpty(estado))
                consulta += " AND b.id_estado=" + estado;
            if (asignado != string.Empty)
                consulta += " AND b.id_usuario_asignado=" + asignado;
            if (prioridad != "")
                consulta += " AND b.id_prioridad=" + prioridad;
            if (!string.IsNullOrEmpty(criticidad))
                consulta += " AND b.id_criticidad=" + criticidad;
            if (!string.IsNullOrEmpty(producto))
                consulta += " AND b.id_producto=" + producto;

            consulta += " ORDER BY b.fecha_alta DESC";

            DBHelper oDatos = new DBHelper();
            return oDatos.consultarDB(consulta);
        }
        public DataTable RecuperarPorId(int idBug)
        {
            string consulta = "SELECT b.id_bug,b.titulo,p.nombre as producto,b.fecha_alta,b.descripcion,e.nombre as estado,u.usuario as asignado,c.nombre as criticidad,pr.nombre as prioridad"
                            + " FROM Bugs b, Productos p, Criticidades c, Prioridades pr, Usuarios u, Estados e"
                            + " WHERE b.id_producto=p.id_producto"
                            + " AND b.id_criticidad=c.id_criticidad"
                            + " AND b.id_prioridad=pr.id_prioridad"
                            + " AND b.id_usuario_asignado=u.id_usuario"
                            + " AND b.id_estado=e.id_estado"
                            + " AND b.borrado=0"
                            + " AND b.id_bug=" + idBug;

            DBHelper oDatos = new DBHelper();
            return oDatos.consultarDB(consulta);
        }

    }
}
