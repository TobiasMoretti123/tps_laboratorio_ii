﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using Biblioteca;
using BaseDeDatos;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario encagardo del ingreso de un cliente
    /// </summary>
    public partial class FrmIngreso : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del cliente
        /// </summary>
        private Cliente cliente;
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
        /// Contructor del formulario de ingreso 
        /// este inicializa los componentes
        /// </summary>
        public FrmIngreso()
        {
            InitializeComponent();

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece el nombre del cliente
        /// que fue ingresado en el textbox
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.txtNombre.Text;
            }
            set
            {
                this.txtNombre.Text = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el cuit del cliente
        /// que fue ingresado en el textbox
        /// </summary>
        public string Cuit
        {
            get
            {
                return this.txtCuit.Text;
            }
            set
            {
                this.txtCuit.Text = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece la direccion del cliente
        /// que fue ingresado en el textbox
        /// </summary>
        public string Direccion
        {
            get
            {
                return this.txtDireccion.Text;
            }
            set
            {
                this.txtDireccion.Text = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el cuit del cliente
        /// que fue ingresado en el textbox
        /// </summary>
        public string Telefono
        {
            get
            {
                return this.txtTelefono.Text;
            }
            set
            {
                this.txtTelefono.Text = value;
            }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton agregar, agrega un cliente a la lista de la base de datos
        /// Siempre y cuando los textbox no esten vacios y sean validos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Exception> excepciones = new List<Exception>();
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text.ValidarNombre()) || string.IsNullOrEmpty(txtCuit.Text)
                 || string.IsNullOrEmpty(cmbResistencia.Text) || string.IsNullOrEmpty(cmbTamanioCilindro.Text)
                 || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtTelefono.Text)
                 || string.IsNullOrEmpty(cmbNacionalidad.Text))
                {
                    throw new ParametrosVaciosException("Algun cuadro de texto esta vacio o el nombre contiene numeros");
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

            try
            {
                txtTelefono.Text.ValidarTelefono();
            }
            catch(TelefonoInvalidoException ex)
            {
                excepciones.Add(ex);
            }

            this.Nombre = txtNombre.Text;
            this.Cuit = txtCuit.Text;
            this.Direccion = txtDireccion.Text;
            this.Telefono = txtTelefono.Text;

            switch (cmbResistencia.SelectedIndex)
            {
                case 0:
                    cliente = new Cliente(this.Nombre, this.Cuit,this.Direccion,(Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex,this.Telefono, new Fisica(int.Parse(cmbTamanioCilindro.Text), Cilindro.ETipoResistencia.Fisica));
                    break;
                case 1:
                    cliente = new Cliente(this.Nombre, this.Cuit, this.Direccion, (Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex, this.Telefono, new Quimica(int.Parse(cmbTamanioCilindro.Text), Cilindro.ETipoResistencia.Quimica));
                    break;
                case 2:
                    cliente = new Cliente(this.Nombre, this.Cuit, this.Direccion, (Cliente.ENacionalidad)cmbNacionalidad.SelectedIndex, this.Telefono, new Termica(int.Parse(cmbTamanioCilindro.Text), Cilindro.ETipoResistencia.Termica));
                    break;
            }

            if (excepciones.Count == 0)
            {
                eventos.OnGuardar += Guardar;
                Task hilo = new Task(() => eventos.Guardar(cliente));
                hilo.Start();
                this.Close();
            }
            else
            {
                VentanaDeErrores(excepciones);
            }
        }
        /// <summary>
        /// Boton salir cierra el formulario de ingreso
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
        /// Al cargar el formulario el mismo inicializa la base de datos y
        /// establece los valores del combobox con las resistencias de los cilindros
        /// e inicializa el evento de guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            clienteDao = new ClienteDao();
            cmbResistencia.DataSource = Enum.GetValues(typeof(Cilindro.ETipoResistencia));
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
                clienteDao.Guardar(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
