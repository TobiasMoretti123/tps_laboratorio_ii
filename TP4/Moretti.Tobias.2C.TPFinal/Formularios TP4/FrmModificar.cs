using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using BaseDeDatos;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario encargado de modificar al cliente
    /// </summary>
    public partial class FrmModificar : Form
    {
        #region Delegados
        /// <summary>
        /// Delegado privado encargado de leer
        /// </summary>
        private delegate void LeerDelegate();
        #endregion

        #region Atributos
        /// <summary>
        /// Atributo privado con la base de datos
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado con las task
        /// </summary>
        private Task t;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del formulario, Inicializa sus componentes e inicializa la base de datos
        /// </summary>
        public FrmModificar()
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton modificar, luego de seleccionar un cliente de la lista e ingresar sus nuevos datos
        /// Este es modificado utilizando la base de datos, siempre y cuando los cuadros no esten vacios
        /// Pregunta si esta seguro de la modificacion antes de hacerla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCuit.Text) && !string.IsNullOrEmpty(txtNombre.Text.ValidarNombre())
                && txtCuit.Text.CacularCuit())
            {
                Cliente nuevoCliente = new Cliente(txtNombre.Text, txtCuit.Text);
                Cliente clienteSeleccionado = lsbClientes.SelectedItem as Cliente;
                DialogResult dialogResult = MessageBox.Show($"¿Seguro desea modificar a {clienteSeleccionado.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (clienteSeleccionado is not null)
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        clienteDao.Modificar(clienteSeleccionado.IdCliente, nuevoCliente);
                        this.ActualizarLstClientes();
                    }
                }
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Al cargar el formulario este lee la base de datos y la muestra en la listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmModificar_Load(object sender, EventArgs e)
        {
            t = Task.Run(() => Leer());
        }
        /// <summary>
        /// Al hacerle doble click a un cliente de la lista su nombre y su cuit apareceran
        /// en los cuadros de texto pudiendo modificarlos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbClientes_DoubleClick(object sender, EventArgs e)
        {
            Cliente? cliente = lsbClientes.SelectedItem as Cliente;
            if (cliente is not null)
            {
                txtNombre.Text = cliente.Nombre;
                txtCuit.Text = cliente.Cuit;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Actualiza la listbox con los nuevos datos del cliente modificado
        /// </summary>
        private void ActualizarLstClientes()
        {
            lsbClientes.DataSource = null;
            t = Task.Run(() => Leer());
        }
        /// <summary>
        /// Metodo encargado de leer la base de datos utilizando el delegado 
        /// </summary>
        public void Leer()
        {
            if (this.InvokeRequired)
            {
                LeerDelegate leer = new LeerDelegate(Leer);
                this.lsbClientes.Invoke(leer);
            }
            else
            {
                try
                {
                    lsbClientes.DataSource = clienteDao.Leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}
