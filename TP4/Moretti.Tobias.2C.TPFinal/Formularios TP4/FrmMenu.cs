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
    public partial class FrmMenu : Form
    {
        private Empresa empresa;
        public FrmMenu()
        {
            InitializeComponent();
            this.empresa = new Empresa("Rotadyne");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmIngreso frmIngreso = new FrmIngreso();

            frmIngreso.ShowDialog();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            FrmLista frmLista = new FrmLista(empresa);

            frmLista.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
