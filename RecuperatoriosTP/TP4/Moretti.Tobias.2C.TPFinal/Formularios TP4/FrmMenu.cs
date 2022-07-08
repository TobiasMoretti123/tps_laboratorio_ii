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
    /// <summary>
    /// Formulario encargado de mostrar el menu pricipal
    /// </summary>
    public partial class FrmMenu : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de la empresa
        /// </summary>
        private Empresa empresa;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de formulario, iniciliza sus componentes e inicializa la empresa con su nombre
        /// </summary>
        public FrmMenu()
        {
            InitializeComponent();
            this.empresa = new Empresa("Rotadyne");
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton agregar abre el formulario de ingreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmIngreso frmIngreso = new FrmIngreso();

            frmIngreso.ShowDialog();
        }
        /// <summary>
        /// Boton opciones abre el formulario de la lista de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            FrmLista frmLista = new FrmLista(empresa);

            frmLista.ShowDialog();
        }
        /// <summary>
        /// Boton salir cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Antes de cerrar el formulario le pregunta al usuario si esta seguro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
