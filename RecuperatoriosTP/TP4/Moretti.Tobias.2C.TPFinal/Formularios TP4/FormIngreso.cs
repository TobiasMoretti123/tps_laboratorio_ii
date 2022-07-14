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
    /// Formulario manejador del ingresa de nuevos clientes 
    /// </summary>
    public partial class FormIngreso : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del cliente
        /// </summary>
        private Cliente cliente;
        /// <summary>
        /// Atributo privado de la empresa
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo privado de la base de datos de cliente
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado del los eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Estable el cliente y la empresa
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="empresa"></param>
        public FormIngreso(Cliente cliente, Empresa empresa)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.empresa = empresa;
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton agregar inserta los datos ingresados en los textbox en un cliente, siempre y cuando sean validos.
        /// Luego lo guarda en la base de datos y abre el menu principal con dicho cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
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
            cliente = new Cliente(txtNombre.Text, txtDireccion.Text, (Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex,
                txtCuit.Text, txtContacto.Text, txtTelefono.Text, txtMail.Text, txtMailFacturaElectronica.Text);

            if (excepciones.Count == 0)
            {
                empresa += cliente;
                eventos.OnGuardar += Guardar;
                Task hilo = new Task(() => eventos.Guardar(cliente));
                hilo.Start();
                FormMenu formMenu = new FormMenu(cliente, empresa);
                this.Hide();
                formMenu.ShowDialog();
                this.Close();
            }
            else
            {
                VentanaDeErrores(excepciones);
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento load establece el textbox del nombre con el usuario igresado en el formulario de usuario
        /// Inicializa el manejador de la base de datos, el manejador de eventos y establece los datos del combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormIngreso_Load(object sender, EventArgs e)
        {
            txtNombre.Text = cliente.RazonSocial;
            clienteDao = new ClienteDao();
            cmbNacionalidad.DataSource = Enum.GetValues(typeof(Cliente.ENacionalidad));
            eventos = new Eventos();
        }
        #endregion

        #region Metodos
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
        /// <summary>
        /// Evento guardar, guarda el cliente a la base de datos
        /// </summary>
        /// <param name="c"></param>
        private void Guardar(Cliente c)
        {
            try
            {
                clienteDao.GuardarCliente(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
