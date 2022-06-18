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
    /// Formulario que se encarga de eliminar un cliente
    /// </summary>
    public partial class FrmCancelar : Form
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
        private CancellationTokenSource cancellationTokenSource;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor parametrizado del formulario cancelar
        /// Establece la empresa, inicializa sus componentes, inicializa el cliente de la base de datos
        /// e inicializa el evento de leer
        /// </summary>
        /// <param name="empresa"></param>
        public FrmCancelar(Empresa empresa)
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
            cancellationTokenSource = new CancellationTokenSource();
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = lsbLista.SelectedItem as Cliente;
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea eliminar a {clienteSeleccionado.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (clienteSeleccionado is not null)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Eliminar(clienteSeleccionado.IdCliente);
                        this.ActualizarLstClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
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
            Task hilo = new Task(() => eventos.Leer(), cancellationTokenSource.Token);
            hilo.Start();
        }

        private void Eliminar(int id)
        {
            clienteDao.Eliminar(id);
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
        /// Lee la base de datos a traves del delagado de leer
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
                    lsbLista.DataSource = clienteDao.Leer();
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
