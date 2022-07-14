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
    /// Formulario manejador del menu principal
    /// </summary>
    public partial class FormMenu : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de la empresa
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo privado del cliente
        /// </summary>
        private Cliente cliente;
        #endregion

        #region Constructores
        /// <summary>
        /// Establece el cliente y la empresa
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="empresa"></param>
        public FormMenu(Cliente cliente, Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cliente = cliente;
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton comprar abre formulario manejador de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormComprar frmComprar = new FormComprar(cliente);

            frmComprar.ShowDialog();
        }
        /// <summary>
        /// Boton consultas abre formulario manejador de consultas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultas_Click(object sender, EventArgs e)
        {
            FormConsultas frmConsultas = new FormConsultas(empresa, cliente);

            frmConsultas.ShowDialog();
        }
        /// <summary>
        /// Boton informacion abre formulario manejador de la informacion de la empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInformacion_Click(object sender, EventArgs e)
        {
            FormInformacion frmInformacion = new FormInformacion(empresa);

            frmInformacion.ShowDialog();
        }
        /// <summary>
        /// Boton modificar abre formulario manejador de la modificacion de clientes
        /// Solo disponible si el nombre de usuario es el nombre de la empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormModificar frmModificar = new FormModificar();

            frmModificar.ShowDialog();

        }
        /// <summary>
        /// Boton eliminar abre formulario manejador de la eliminacion de clientes
        /// Solo disponible si el nombre de usuario es el nombre de la empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormEliminar frmCancelar = new FormEliminar(empresa);

            frmCancelar.ShowDialog();

        }
        /// <summary>
        /// Boton salir cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Al cargar el menu, si el usuario no es el nombre de la empresa.
        /// Los botones eliminar y modificar no estaran disponibles.
        /// Si es la empresa estos botones estaran disponibles y el resto no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (cliente.RazonSocial != empresa.NombreEmpresa)
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
        /// <summary>
        /// Evento de cerrar el formulario le pregunta al usuario si esta seguro
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
        #endregion
    }
}
