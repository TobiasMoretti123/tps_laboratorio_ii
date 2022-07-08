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
using Excepciones;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario encargado de modificar al cliente
    /// </summary>
    public partial class FrmModificar : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado con la base de datos
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado con los eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del formulario, Inicializa sus componentes, inicializa la base de datos
        /// e inicializa el evento de leer
        /// </summary>
        public FrmModificar()
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
            btnModificar.Enabled = false;
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
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text.ValidarNombre()) || string.IsNullOrEmpty(txtCuit.Text)
                 || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtTelefono.Text)
                 || string.IsNullOrEmpty(cmbNacionalidad.Text))
                {
                    throw new ParametrosVaciosException("Algun cuadro de texto esta vacio o el nombre contiene numeros");
                }
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                txtCuit.Text.CacularCuit();
            }
            catch (CuitInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                txtTelefono.Text.ValidarTelefono();
            }
            catch (TelefonoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cliente nuevoCliente = new Cliente(txtNombre.Text, txtCuit.Text,txtDireccion.Text,(Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex,txtTelefono.Text);
            Cliente clienteSeleccionado = lsbClientes.SelectedItem as Cliente;
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea modificar a {clienteSeleccionado.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (clienteSeleccionado is not null)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        clienteDao.Modificar(clienteSeleccionado.IdCliente, nuevoCliente);
                        this.ActualizarLstClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            eventos = new Eventos();
            eventos.OnLeer += Leer;
            cmbNacionalidad.DataSource = Enum.GetValues(typeof(Cliente.ENacionalidad));
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
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
            btnModificar.Enabled = true;
            if (cliente is not null)
            {
                txtNombre.Text = cliente.Nombre;
                txtCuit.Text = cliente.Cuit;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                cmbNacionalidad.SelectedItem = (Cliente.ENacionalidad)cliente.Nacionalidad;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Actualiza la listbox con los nuevos datos del cliente modificado
        /// </summary>
        private void ActualizarLstClientes()
        {
            Task.Run(() => Leer());
        }
        /// <summary>
        /// Metodo encargado de leer la base de datos utilizando el evento de leer
        /// </summary>
        public void Leer()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(Leer);
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
