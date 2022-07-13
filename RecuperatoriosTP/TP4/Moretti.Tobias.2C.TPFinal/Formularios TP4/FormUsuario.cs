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
    public partial class FormUsuario : Form
    {
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
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            clienteDao = new ClienteDao();
            cliente = new Cliente();
            empresa = new Empresa("Rotadyne", "Av. Rodríguez Peña 3095", "Argentina", "30123456789", "Tobias Moretti",
                "41591556", "rotadyneargentina@gmail.com", "rotadyneconsultas@gmail.com");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text.ValidarNombre()))
                {
                    throw new ParametrosVaciosException("El usuario no puede ser vacio o numeros");
                }
                else
                {
                    CargarCliente();
                }
            }
            catch (ParametrosVaciosException ex)
            {
                VentanaDeError(ex);
            }
        }

        private void CargarCliente()
        {   
            cliente.RazonSocial = txtUsuario.Text;

            foreach (Cliente c in clienteDao.LeerCliente())
            {
                if (c == cliente)
                {
                    cliente = c;
                    MessageBox.Show($"Cliente ya ingresado, se abrira menu principal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMenu formMenu = new FormMenu(cliente, empresa);
                    this.Hide();
                    formMenu.ShowDialog();
                    this.Close();
                }

                if(cliente.RazonSocial == empresa.NombreEmpresa)
                {
                    MessageBox.Show($"Ingreso como empresa, se abrira menu principal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMenu formMenu = new FormMenu(cliente, empresa);
                    this.Hide();
                    formMenu.ShowDialog();
                    this.Close();
                }
            }
            MessageBox.Show($"Nuevo Cliente, se abrira ingreso para completar los datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormIngreso formIngreso = new FormIngreso(cliente, empresa);
            this.Hide();
            formIngreso.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Metodo encargado de mostrar cualquier excepcion como un error
        /// </summary>
        /// <param name="ex"></param>
        private void VentanaDeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }  
}
