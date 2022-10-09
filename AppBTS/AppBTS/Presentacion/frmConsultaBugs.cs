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
    public partial class frmConsultaBugs : Form
    {
        Bug oBug;
        Estado oEstado;
        Criticidad oCriticidad;
        Prioridad oPrioridad;
        Producto oProducto;
        Usuario oUsuario;
        
        public frmConsultaBugs()
        {
            InitializeComponent();
            oUsuario = new Usuario();
            oEstado= new Estado();
            oCriticidad= new Criticidad();
            oPrioridad= new Prioridad();
            oProducto= new Producto();
            oBug= new Bug();
        }

        private void frmConsultaBugs_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            
            this.CargarCombo(cboEstado, oEstado.RecuperarTodos()); ;
            this.CargarCombo(cboCriticidad, oCriticidad.RecuperarTodos()); ;
            this.CargarCombo(cboPrioridad, oPrioridad.RecuperarTodos()); ;
            this.CargarCombo(cboProducto, oProducto.RecuperarTodos()); ;
            this.CargarCombo(cboAsignadoA, oUsuario.RecuperarTodos(),"id_usuario","usuario");
            
            //this.dgvBugs.DataSource = oBug.RecuperarTodos();
            this.CargarGrilla(dgvBugs, oBug.RecuperarTodos());

            this.btnNuevo.Enabled = true;
            this.btnConsultar.Enabled = true;
            this.btnSalir.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnDetalle.Enabled = false;
            this.btnAsignar.Enabled = false;
        }

        private void Limpiar()
        {
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-7);
            this.dtpFechaHasta.Value = DateTime.Today;
            this.cboAsignadoA.SelectedIndex = -1;
            this.cboCriticidad.SelectedIndex = -1;
            this.cboEstado.SelectedIndex = -1;
            this.cboPrioridad.SelectedIndex = -1;
            this.cboProducto.SelectedIndex = -1;
            //this.dgvBugs????
            this.dtpFechaDesde.Focus();
        }

        private void CargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_bug"],
                                tabla.Rows[i]["titulo"],
                                tabla.Rows[i]["producto"],
                                tabla.Rows[i]["fecha_alta"],
                                tabla.Rows[i]["estado"],
                                tabla.Rows[i]["asignado"],
                                tabla.Rows[i]["criticidad"],
                                tabla.Rows[i]["prioridad"]);
            }
        }

        private void CargarCombo(ComboBox combo, DataTable Tabla)
        {
            combo.DataSource = Tabla;
            combo.ValueMember = Tabla.Columns[0].ColumnName;
            combo.DisplayMember = Tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1; //vacio
        }
        //sobrecarga del metodo con otros parámetros...
        private void CargarCombo(ComboBox combo, DataTable Tabla,string campoValor,string campoMostrar)
        {
            combo.DataSource = Tabla;
            combo.ValueMember = campoValor;//"id_usuario"
            combo.DisplayMember = campoMostrar;//"usuario"
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1; //vacio
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string estado, prioridad, producto, criticidad, asignado;
            estado = prioridad = producto = criticidad = asignado = string.Empty;

            if (dtpFechaDesde.Value>dtpFechaHasta.Value)
            {
                MessageBox.Show("Fechas incorrectas!!!");
                dtpFechaDesde.Focus();
                return;
            }
            if(cboEstado.SelectedIndex!=-1)
                estado = cboEstado.SelectedValue.ToString();
            if(cboPrioridad.SelectedIndex!=-1)
                prioridad=cboPrioridad.SelectedValue.ToString();
            if (cboProducto.SelectedIndex != -1)
                producto = Convert.ToString(cboProducto.SelectedValue);
            if (cboCriticidad.SelectedIndex != -1)
                criticidad = cboCriticidad.SelectedValue.ToString();
            if (cboAsignadoA.SelectedIndex != -1)
                asignado = cboAsignadoA.SelectedValue.ToString();

            this.CargarGrilla(dgvBugs, oBug.RecuperarFiltrados(
                                       dtpFechaDesde.Value.ToString("yyyy/MM/dd"),//ToShortDateString(),
                                       dtpFechaHasta.Value.ToString("yyyy/MM/dd"),//ToShortDateString(),
                                       estado,
                                       asignado,
                                       prioridad,
                                       criticidad,
                                       producto));
            this.Limpiar();
        }

      
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleBug fdb=new frmDetalleBug((int)dgvBugs.CurrentRow.Cells[0].Value);
            //fdb.IdBug = 7;
            fdb.ShowDialog();
        }

        private void dgvBugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDetalle.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnAsignar.Enabled = true;
        }
    }
}
