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
        /// Atributo privado manejador del archivo xml
        /// </summary>
        private Xml<Cliente> xml;
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
            this.xml = new Xml<Cliente>();
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
            btnConfirmar.Enabled = true;
            if (cilindro is not null)
            {
                clienteAux += cilindro;              
                MessageBox.Show($"Usted acaba de comprar un cilindro de goma tiene {cliente.Cilindros.Count} en el carrito\nPrecione el boton confirmar para finalizar su compra", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// <summary>
        /// Boton confirmar confirma la compra agregando los productos al cliente actual.
        /// Una vez finalizado imprime una factura y se guarda en un xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea confirmar su compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    cliente = clienteAux;
                    foreach (Cliente c in clienteDao.LeerCliente())
                    {
                        if (c == cliente)
                        {
                            cliente.IdCliente = c.IdCliente;
                        }
                    }
                    foreach (Cliente c in clienteDao.LeerCliente())
                    {
                        if (cliente.IdCliente == c.IdCliente)
                        {
                            MessageBox.Show($"Su factura a sido enviada a {cliente.MailFacturaElectronico}\nDetalles de compra:\n{cliente.MostrarCliente()}", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    xml.Guardar(CrearCarpeta() + "\\Compras.xml", cliente);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                btnConfirmar.Enabled = false;
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
        /// <summary>
        /// Crea una carpeta en el escritorio donde se guarda el archivo xml
        /// </summary>
        /// <returns>El path donde se encuentra la carpeta</returns>
        public string CrearCarpeta()
        {
            string folderPath = GetFolderPath(SpecialFolder.Desktop) + "\\Carpeta Archivos Tobias MorettiTP4";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
        #endregion
    }
}
