using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Formularios_TP4
{
    public partial class FormMenu : Form
    {
        Empresa empresa;
        Cliente cliente;
        public FormMenu(Cliente cliente,Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cliente = cliente;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if(cliente.RazonSocial != empresa.NombreEmpresa)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnComprar.Enabled = false;
                btnConsultas.Enabled = false;
                btnInformacion.Enabled = false;
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormComprar frmComprar = new FormComprar(cliente);

            frmComprar.ShowDialog();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            FormConsultas frmConsultas = new FormConsultas(empresa);

            frmConsultas.ShowDialog();
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            FormInformacion frmInformacion = new FormInformacion(empresa);

            frmInformacion.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormModificar frmModificar = new FormModificar();

            frmModificar.ShowDialog();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormEliminar frmCancelar = new FormEliminar(empresa);

            frmCancelar.ShowDialog();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Antes de cerrar el formulario le pregunta al usuario si esta seguro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
