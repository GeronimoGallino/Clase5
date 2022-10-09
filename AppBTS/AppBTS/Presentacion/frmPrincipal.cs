using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBTS.Presentacion;

namespace AppBTS
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            frmLogin oFL = new frmLogin();
            oFL.ShowDialog();
            
            this.Text += " - Usuario: " + oFL.OUsuario.Nombre;

            oFL.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de abandonar la aplicación..."
                                , "SALIENDO"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaBugs oFCB=new frmConsultaBugs();
            oFCB.ShowDialog();
            oFCB.Dispose();
        }
    }
}
