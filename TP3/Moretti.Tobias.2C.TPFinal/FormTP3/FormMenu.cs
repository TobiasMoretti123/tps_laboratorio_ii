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

namespace FormIngreso
{
    public partial class FormMenu : Form
    {
        private Partida partida;
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormIngreso frm = new FormIngreso(partida);
            frm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dg = frm.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            partida = new Partida("Dungeons and Dragons");
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            FormVista formVista = new FormVista(this.partida);
            formVista.StartPosition = FormStartPosition.CenterScreen;
            formVista.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

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
