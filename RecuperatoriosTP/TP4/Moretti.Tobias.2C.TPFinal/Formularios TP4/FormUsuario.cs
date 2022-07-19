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
    /// Formulario manejador del usuario, este es el primero en abrirse
    /// </summary>
    public partial class FormUsuario : Form
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
        /// Atributo privado para la contraseña de todos los usuarios
        /// </summary>
        private string contrasenia;
        /// <summary>
        /// Atributo privado para la contraseña de la empresa
        /// </summary>
        private string contraseniaEmpresa;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa el formulario y establece la contraseña
        /// </summary>
        public FormUsuario()
        {
            InitializeComponent();
            contrasenia = "19789";
            contraseniaEmpresa = "98791";
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton ingresar llama al metodo de cargar cliente si su nombre es valido 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text.ValidarNombre()))
                {
                    throw new ParametrosVaciosException("El usuario no puede ser numeros o vacio");
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
            catch (ContraseniaIncorrectaExeption ex)
            {
                VentanaDeError(ex);
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }

        }
        #endregion

        #region Eventos
        /// <summary>
        /// Al cargar el formulario inicializa el cliente, la base de datos y la empresa con sus datos predefinidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            clienteDao = new ClienteDao();
            cliente = new Cliente();
            empresa = new Empresa("Rotadyne", "Av. Rodríguez Peña 3095", "Argentina", "30123456789", "Tobias Moretti",
                "41591556", "rotadyneargentina@gmail.com", "rotadyneconsultas@gmail.com");
        }
        #endregion

        #region Metodos 
        /// <summary>
        /// Establece lo ingresado en el textbox como razon social del cliente.
        /// Si este cliente ya esta en la base de datos se abrira el formulario manejador del menu normal.
        /// Si este cliente es nuevo, se abrira el formulario manejador del ingreso.
        /// </summary>
        private void CargarCliente()
        {
            cliente.RazonSocial = txtUsuario.Text;

            if(txtContrasenia.Text != contrasenia && txtContrasenia.Text != contraseniaEmpresa)
            {
                throw new ContraseniaIncorrectaExeption("Contraseña invalida intentelo nuevamente");
            }
            foreach (Cliente c in clienteDao.LeerCliente())
            {
                empresa += c;
                
                if (c == cliente)
                {
                    cliente = c;
                    MessageBox.Show($"Cliente ya ingresado, se abrira menu principal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AbrirMenu();
                }
            }
            if (cliente.RazonSocial == empresa.NombreEmpresa && txtContrasenia.Text == contraseniaEmpresa)
            {
                MessageBox.Show($"Ingreso como empresa, se abrira menu principal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AbrirMenu();
            }
            else if(cliente.RazonSocial != empresa.NombreEmpresa && txtContrasenia.Text != contraseniaEmpresa)
            {
                MessageBox.Show($"Nuevo Cliente, se abrira ingreso para completar los datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormIngreso formIngreso = new FormIngreso(cliente, empresa);
                this.Hide();
                formIngreso.ShowDialog();
                this.Close();
            }
            else
            {
                throw new ContraseniaIncorrectaExeption("Contraseña invalida intentelo nuevamente");
            }
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
        /// <summary>
        /// Abre el menu principal
        /// </summary>
        private void AbrirMenu()
        {
            FormMenu formMenu = new FormMenu(cliente, empresa);
            this.Hide();
            formMenu.ShowDialog();
            this.Close();
        }
        #endregion
    }
}
