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

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario manejador de la eliminacion de un cliente
    /// </summary>
    public partial class FormEliminar : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del cliente en la base de datos
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado de la empresa 
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo privado de los eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor parametrizado del formulario cancelar
        /// Establece la empresa, inicializa sus componentes, inicializa el cliente de la base de datos
        /// e inicializa el evento de leer
        /// </summary>
        /// <param name="empresa"></param>
        public FormEliminar(Empresa empresa)
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
            this.empresa = empresa;

        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton eliminar elimina el cliente seleccionado en el listbox del formulario
        /// Pregunta si esta seguro antes de ser eliminado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = lsbLista.SelectedItem as Cliente;
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea eliminar a {clienteSeleccionado.RazonSocial}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (clienteSeleccionado is not null)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Eliminar(clienteSeleccionado.IdCliente);
                        empresa -= clienteSeleccionado;
                        this.ActualizarLstClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        /// <summary>
        /// Boton volver regresa al menu principal
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
        /// Al cargar el formulario carga la listbox con los datos leidos desde la base de datos
        /// esto se hace a traves de un hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCancelar_Load(object sender, EventArgs e)
        {
            eventos = new Eventos();
            eventos.OnLeer += Leer;
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
        }
        /// <summary>
        /// Evento que se encarga de eliminar el cliente de la base de datos
        /// </summary>
        /// <param name="id"></param>
        private void Eliminar(int id)
        {
            clienteDao.EliminarCliente(id);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Actualiza la listbox con los nuevos elementos de la base de datos
        /// </summary>
        private void ActualizarLstClientes()
        {
            Task.Run(() => Leer());
        }
        /// <summary>
        /// Lee la base de datos a traves del evento de leer
        /// </summary>
        public void Leer()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(Leer);
                this.lsbLista.Invoke(leer);
            }
            else
            {
                try
                {
                    lsbLista.DataSource = clienteDao.LeerCliente();
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
