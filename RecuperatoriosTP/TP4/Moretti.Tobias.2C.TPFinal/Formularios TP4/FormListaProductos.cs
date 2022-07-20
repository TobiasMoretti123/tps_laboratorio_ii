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
    public partial class FormListaProductos : Form
    {
        /// <summary>
        /// Atributo privado con el cliente
        /// </summary>
        private Cliente cliente;
        /// <summary>
        /// Atributo privado manejador del archivo xml
        /// </summary>
        private Xml<Cliente> xml;
        /// <summary>
        /// Atributo privado manejador de la base de datos
        /// </summary>
        private ClienteDao clienteDao;
        /// <summary>
        /// Atributo privado manejador de eventos
        /// </summary>
        private Eventos eventos;
        public FormListaProductos(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.eventos = new Eventos();
            this.clienteDao = new ClienteDao();
            this.xml = new Xml<Cliente>();
            eventos.OnLeer += MostrarCarrito;
        }

        private void FormListaProductos_Load(object sender, EventArgs e)
        {
            lblCliente.Text = "Cliente: " + cliente.RazonSocial;
            Task hilo = new Task(() =>
            {
                eventos.LeerCilindro();
            });
            hilo.Start();
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea confirmar su compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
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

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"¿Seguro desea cancelar su compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cliente.Cilindros.Clear();
            }
            this.Close();
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            FormComprar formComprar = new FormComprar(cliente);
            this.Hide();
            formComprar.ShowDialog();
            this.Close();
        }

        private void btnEliminarProductos_Click(object sender, EventArgs e)
        {
            Cilindro cilindro = lstCarrito.SelectedItem as Cilindro;
            if (cilindro is not null)
            {
                DialogResult dialogResult = MessageBox.Show($"¿Seguro desea eliminar su cilindro? \n{cilindro.ToString()}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    cliente.Cilindros.Remove(cilindro);
                }   
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarCarrito()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(MostrarCarrito);
                this.lstCarrito.Invoke(leer);
            }
            else
            {
                try
                {
                    lstCarrito.DataSource = cliente.Cilindros;
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
    }
}
