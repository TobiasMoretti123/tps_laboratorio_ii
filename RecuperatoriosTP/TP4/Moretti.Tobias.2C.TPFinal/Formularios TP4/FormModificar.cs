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
using BaseDeDatos;
using Excepciones;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario manejador de la modificacion de clientes
    /// </summary>
    public partial class FormModificar : Form
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
        /// inicializa el manejador de la base de datos y establece el boton modificar como invalido
        /// </summary>
        public FormModificar()
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
        /// Pregunta si esta seguro de la modificacion antes de hacerla.
        /// Este estara habilitado solo si se selecciona algun cliente de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<Exception> excepciones = new List<Exception>();
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text.ValidarNombre()) || string.IsNullOrEmpty(txtDireccion.Text)
                 || string.IsNullOrEmpty(cmbNacionalidad.Text) || string.IsNullOrEmpty(txtCuit.Text)
                 || string.IsNullOrEmpty(txtContacto.Text.ValidarNombre()) || string.IsNullOrEmpty(txtTelefono.Text)
                 || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtMailFacturaElectronica.Text))
                {
                    throw new ParametrosVaciosException("Algun cuadro de texto esta vacio o cuadro contacto y/o nombre contiene numeros");
                }
            }
            catch (ParametrosVaciosException ex)
            {
                excepciones.Add(ex);
            }

            try
            {
                txtCuit.Text.CacularCuit();
            }
            catch (CuitInvalidoException ex)
            {
                excepciones.Add(ex);
            }

            Cliente nuevoCliente = new Cliente(txtNombre.Text, txtDireccion.Text, (Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex,
                txtCuit.Text, txtContacto.Text, txtTelefono.Text, txtMail.Text, txtMailFacturaElectronica.Text);
            Cliente? clienteSeleccionado = lbstClientes.SelectedItem as Cliente;

            if (excepciones.Count == 0)
            {
                if (clienteSeleccionado is not null)
                {
                    DialogResult dialogResult = MessageBox.Show($"¿Seguro desea modificar a {clienteSeleccionado.RazonSocial}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            clienteDao.ModificarCliente(clienteSeleccionado.IdCliente, nuevoCliente);
                            this.ActualizarLstClientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
            {
                VentanaDeErrores(excepciones);
            }
        }
        /// <summary>
        /// Boton volver retorna al menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Al cargar el formulario este lee la base de datos y la muestra en la listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModificar_Load(object sender, EventArgs e)
        {
            eventos = new Eventos();
            eventos.OnLeer += Leer;
            cmbNacionalidad.DataSource = Enum.GetValues(typeof(Cliente.ENacionalidad));
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
        }
        /// <summary>
        /// Al hacer doble click sobre un cliente en la lista, todos sus datos apareceran en sus respectivos textbox.
        /// Una vez modificado el dato que desee puede clickear el boton modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbstClientes_DoubleClick(object sender, EventArgs e)
        {
            Cliente? cliente = lbstClientes.SelectedItem as Cliente;
            btnModificar.Enabled = true;
            if (cliente is not null)
            {
                txtNombre.Text = cliente.RazonSocial;
                txtDireccion.Text = cliente.Direccion;
                cmbNacionalidad.SelectedItem = (Cliente.ENacionalidad)cliente.Nacionalidad;
                txtCuit.Text = cliente.Cuit;
                txtContacto.Text = cliente.Contacto;
                txtTelefono.Text = cliente.Telefono;
                txtMail.Text = cliente.Mail;
                txtMailFacturaElectronica.Text = cliente.MailFacturaElectronico;
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
                this.lbstClientes.Invoke(leer);
            }
            else
            {
                try
                {
                    lbstClientes.DataSource = clienteDao.LeerCliente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Metodo que muestra las ecepciones creadas a modo de lista de errores
        /// </summary>
        /// <param name="ex"></param>
        private void VentanaDeErrores(List<Exception> ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception e in ex)
            {
                sb.AppendLine($"{e.Message}");
            }
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
