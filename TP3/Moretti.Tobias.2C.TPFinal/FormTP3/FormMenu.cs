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
    /// <summary>
    /// Clase parcial del formulario con el menu
    /// </summary>
    public partial class FormMenu : Form
    {
        /// <summary>
        /// Atributo privado de la partida
        /// </summary>
        private Partida partida;
        /// <summary>
        /// Constructor que inicializa los componentes del formulario
        /// </summary>
        public FormMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Abre el formulario de ingreso pasandole la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormIngreso frm = new FormIngreso(partida);
            frm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dg = frm.ShowDialog();
        }
        /// <summary>
        /// Al cargar el formulario la partida es construida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenu_Load(object sender, EventArgs e)
        {
            partida = new Partida("Dungeons and Dragons");
        }
        /// <summary>
        /// Abre el formulario de vista pasandole la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVer_Click(object sender, EventArgs e)
        {
            FormVista formVista = new FormVista(this.partida);
            formVista.StartPosition = FormStartPosition.CenterScreen;
            formVista.ShowDialog();
        }
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Antes de cerrar el formulario pregunta si esta seguro
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
