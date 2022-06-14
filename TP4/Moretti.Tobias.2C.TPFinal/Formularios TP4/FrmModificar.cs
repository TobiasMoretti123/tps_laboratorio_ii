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
    public partial class FrmModificar : Form
    {
        ClienteDao clienteDao;
        public FrmModificar()
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            lsbClientes.DataSource = clienteDao.Leer();
        }

        private void lsbClientes_DoubleClick(object sender, EventArgs e)
        {
            Cliente? cliente = lsbClientes.SelectedItem as Cliente;
            if (cliente is not null)
            {
                txtNombre.Text = cliente.Nombre;
                txtCuit.Text = cliente.Cuit;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCuit.Text) && !string.IsNullOrEmpty(txtNombre.Text)
                && txtCuit.Text.CacularCuit())
            {
                Cliente nuevoCliente = new Cliente(txtNombre.Text, txtCuit.Text);

                Cliente clienteSeleccionado = lsbClientes.SelectedItem as Cliente;
                DialogResult dialogResult = MessageBox.Show($"¿Seguro desea modificar a {clienteSeleccionado.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (clienteSeleccionado is not null)
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        clienteDao.Modificar(clienteSeleccionado.IdCliente, nuevoCliente);
                        this.ActualizarLstClientes();
                    }
                }
            }
        }

        private void ActualizarLstClientes()
        {
            lsbClientes.DataSource = null;
            lsbClientes.DataSource = clienteDao.Leer();
        }
    }
}
