using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Add(new OpcionCombo(){Valor = 1, Texto = "Activo"});
            cbEstado.Items.Add(new OpcionCombo(){Valor = 0, Texto = "Inactivo"});
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;


            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cbRol.Items.Add(new OpcionCombo() {Valor = item.IdRol, Texto = item.Descripcion});
                
            }
            cbRol.DisplayMember = "Texto";
            cbRol.ValueMember = "Valor";
            cbRol.SelectedIndex = 0;

            foreach (DataGridViewColumn Columna in dgvData.Columns)
            {
                if (Columna.Visible == true && Columna.Name != "btnSeleccionar")
                {
                    cbBusqueda.Items.Add(new OpcionCombo() {Valor = Columna.Name , Texto = Columna.HeaderText});
                }
            }
            cbBusqueda.DisplayMember = "Texto";
            cbBusqueda.ValueMember = "Valor";
            cbBusqueda.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Add(new Object[]
            {
                "", txtId.Text, txtDocumento.Text, txtNombre.Text, txtCorreo.Text, txtClave.Text,
                ((OpcionCombo) cbRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo) cbRol.SelectedItem).Texto.ToString(),
                ((OpcionCombo) cbEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombo) cbEstado.SelectedItem).Texto.ToString()
            });
            
            Limpiar();
        }


        private void Limpiar()
        {

            txtId.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            
        }
        
    }
}
