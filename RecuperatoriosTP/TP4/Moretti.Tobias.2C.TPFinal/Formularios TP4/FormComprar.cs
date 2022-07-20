using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Biblioteca;
using Archivos;
using static System.Environment;
using BaseDeDatos;
using Excepciones;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario manejador de las compras del usuario
    /// </summary>
    public partial class FormComprar : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado con el cliente
        /// </summary>
        private Cliente cliente;
        /// <summary>
        /// Atributo privado con un cliente auxiliar
        /// </summary>
        private Cliente clienteAux;
        /// <summary>
        /// Atributo privado manejador de la base de datos
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado manejador de eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Establece el cliente ingresado por parametro, inicializa el manejador de la base de datos
        /// inicializa el manejador de evento, inicializa el manejador de archivos xml y establece la relacion
        /// entre el evento OnLeer de su manejador al metodo correspondiente
        /// </summary>
        /// <param name="cliente"></param>
        public FormComprar(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            clienteAux = cliente;
            this.clienteDao = new ClienteDao();
            this.eventos = new Eventos();
            txtCantidadCilindros.Text = string.Empty;
            eventos.OnLeer += MostrarCilindros;
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton comprar agrega el producto seleccionado a un carrito de compra temporal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            Cilindro cilindro = lstbProductos.SelectedItem as Cilindro;
            try
            {
                if (string.IsNullOrEmpty(txtCantidadCilindros.Text))
                {
                    throw new ParametrosVaciosException("La cantidad no puede estar vacia");
                }
                if(int.Parse(txtCantidadCilindros.Text) <= 0)
                {
                    throw new ParametrosVaciosException("La cantidad no puede ser 0 o negativo");
                }
                int cantidadCilindros = int.Parse(txtCantidadCilindros.Text);
                btnVerCompra.Enabled = true;
                if (cilindro is not null)
                {
                    for (int i = 0; i < cantidadCilindros; i++)
                    {
                        clienteAux += cilindro;
                    }
                    MessageBox.Show($"Usted acaba de comprar {cantidadCilindros} cilindros de goma con resistencia {cilindro.TipoResistencia} tiene {cliente.Cilindros.Count} en el carrito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtCantidadCilindros.Text = string.Empty;
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnVerCompra_Click(object sender, EventArgs e)
        {
            FormListaProductos frmListaProductos = new FormListaProductos(clienteAux);
            this.Hide();
            frmListaProductos.ShowDialog();
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Inicializa el hilo con el manejador del evento.
        /// El boton confirmar no estara disponible hasta que se alla comprado temporalmente
        /// Almenos 1 producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormComprar_Load(object sender, EventArgs e)
        {
            Task hilo = new Task(() =>
            {
                eventos.LeerCilindro();
            });
            hilo.Start();
            if (cliente.Cilindros.Count == 0)
            {
                btnVerCompra.Enabled = false;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los cilindros en el listbox
        /// </summary>
        private void MostrarCilindros()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(MostrarCilindros);
                this.lstbProductos.Invoke(leer);
            }
            else
            {
                try
                {
                    lstbProductos.DataSource = clienteDao.LeerCilindro();
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
