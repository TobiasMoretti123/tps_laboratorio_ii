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
    public partial class FormIngreso : Form
    {
        private Cliente cliente;
        private Empresa empresa;
        /// <summary>
        /// Atributo privado de la base de datos de cliente
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado del los eventos
        /// </summary>
        private Eventos eventos;
        public FormIngreso(Cliente cliente, Empresa empresa)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.empresa = empresa;
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            txtNombre.Text = cliente.RazonSocial;
            clienteDao = new ClienteDao();
            cmbNacionalidad.DataSource = Enum.GetValues(typeof(Cliente.ENacionalidad));
            eventos = new Eventos();
        }

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
            cliente = new Cliente(txtNombre.Text,txtDireccion.Text,(Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex,
                txtCuit.Text,txtContacto.Text,txtTelefono.Text,txtMail.Text,txtMailFacturaElectronica.Text);

            if (excepciones.Count == 0)
            {
                empresa += cliente;
                eventos.OnGuardar += Guardar;
                Task hilo = new Task(() => eventos.Guardar(cliente));
                hilo.Start();
                FormMenu formMenu = new FormMenu(cliente,empresa);
                this.Hide();
                formMenu.ShowDialog();
                this.Close();
            }
            else
            {
                VentanaDeErrores(excepciones);
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
    }
}
