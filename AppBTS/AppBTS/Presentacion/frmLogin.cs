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

namespace AppBTS
{
    public partial class frmLogin : Form
    {
        //private string usuario="admin";
        //private string clave="1234";
        
        private Usuario oUsuario = new Usuario();
        internal Usuario OUsuario { get { return oUsuario; } set { oUsuario = value; } }
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                MessageBox.Show("Debe ingresar usuario...");
                txtUsuario.Focus();
                return;
            }
            if (txtClave.Text==String.Empty)
            {
                MessageBox.Show("Debe ingresar contraseña...");
                txtClave.Focus();
                return;
            }

            OUsuario.Nombre = txtUsuario.Text;
            OUsuario.Password = txtClave.Text;

            //if (this.validar(txtUsuario.Text,txtClave.Text))
            OUsuario.IdUsuario = OUsuario.validar();
            if (OUsuario.IdUsuario!=0)
            {
                MessageBox.Show("Login ok",
                                "Ingreso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos",
                                "Validación de datos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.OUsuario.Nombre = "";
                this.OUsuario.Password = "";
                this.txtUsuario.Text = "";
                this.txtClave.Text = string.Empty;
                this.txtUsuario.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private bool validar(string u,string c)
        //{
        //    //if (txtUsuario.Text == this.usuario && txtClave.Text == this.clave)
        //    if (u == this.usuario && c == this.clave)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
