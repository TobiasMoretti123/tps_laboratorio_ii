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
using Archivos;
using static System.Environment;
using BaseDeDatos;

namespace Formularios_TP4
{
    public partial class FormComprar : Form
    {
        private Cliente cliente;
        private ClienteDao clienteDao;
        private Xml<Cliente> xml;
        private Eventos eventos;
        public FormComprar(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.clienteDao = new ClienteDao();
            this.eventos = new Eventos();
            this.xml = new Xml<Cliente>();
            eventos.OnLeer += MostrarCilindros;
        }

        private void FormComprar_Load(object sender, EventArgs e)
        {
            Task hilo = new Task(() =>
            {
                eventos.LeerCilindro();
            });
            hilo.Start();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Cilindro cilindro = lstbProductos.SelectedItem as Cilindro;
            if (cilindro is not null)
            {
                cliente += cilindro;
                try
                {
                    foreach(Cliente c in clienteDao.LeerCliente())
                    {
                        if(c == cliente)
                        {
                            cliente.IdCliente = c.IdCliente;
                        }
                    }
                    xml.Guardar(GetFolderPath(SpecialFolder.Desktop) + "\\Cliente.xml", cliente);
                    MessageBox.Show($"Usted acaba de comprar un cilindro de goma la factura a sido enviada a {cliente.MailFacturaElectronico}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
    }
}
