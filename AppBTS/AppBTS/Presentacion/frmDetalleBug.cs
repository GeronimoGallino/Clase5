using AppBTS.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AppBTS.Presentacion
{
    public partial class frmDetalleBug : Form
    {
        private int idBug;

        //public int IdBug
        //{
        //    get { return idBug; }
        //    set { idBug = value; }
        //}

        public frmDetalleBug(int idBug)
        {
            InitializeComponent();
            this.idBug = idBug;
        }
        public frmDetalleBug()
        {
            InitializeComponent();
        }

        private void frmDetalleBug_Load(object sender, EventArgs e)
        {
            this.CargarCampos(idBug);
        }

        private void CargarCampos(int idBug)
        {
            Bug oBugSeleccionado=new Bug();
            DataTable dtBug = (oBugSeleccionado.RecuperarPorId(idBug));

            txt_nro_bug.Text = dtBug.Rows[0]["id_bug"].ToString();
            txt_titulo.Text = dtBug.Rows[0]["titulo"].ToString();
            txt_producto.Text = dtBug.Rows[0]["producto"].ToString();
            txt_fec_alta.Text = dtBug.Rows[0]["fecha_alta"].ToString();
            txt_descri.Text=dtBug.Rows[0]["descripcion"].ToString();
            txt_estado.Text = dtBug.Rows[0]["estado"].ToString();
            txt_prioridad.Text = dtBug.Rows[0]["prioridad"].ToString();
            txt_criticidad.Text = dtBug.Rows[0]["criticidad"].ToString();

            HistorialBug oHistorialBug= new HistorialBug();
            DataTable dtHistoBug=oHistorialBug.RecuperarHistorialPorId(idBug);
            if(dtHistoBug.Rows.Count > 0)
            {
                for (int i = 0; i < dtHistoBug.Rows.Count; i++)
                {
                    dgv_historiales.Rows.Add(dtHistoBug.Rows[i]["fecha_historico"],
                                             dtHistoBug.Rows[i]["responsable"],
                                             dtHistoBug.Rows[i]["estado"],
                                             dtHistoBug.Rows[i]["asignadoA"]);
                }
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
