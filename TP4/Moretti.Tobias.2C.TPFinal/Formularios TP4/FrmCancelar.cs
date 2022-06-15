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
    public partial class FrmCancelar : Form
    {
        private ClienteDao clienteDao;
        private Empresa empresa;
        private Task t;
        private delegate void LeerDelegate();
        public FrmCancelar(Empresa empresa)
        {
            InitializeComponent();
            clienteDao = new ClienteDao();
            this.empresa = empresa;
        }

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
                        clienteDao.Eliminar(clienteSeleccionado.IdCliente);
                        empresa -= clienteSeleccionado;
                        this.ActualizarLstClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        private void FrmCancelar_Load(object sender, EventArgs e)
        {
            try
            {
                t = Task.Run(() => Leer());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        private void ActualizarLstClientes()
        {
            lsbLista.DataSource = null;
            try
            {
                t = Task.Run(() => Leer());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Leer()
        {
            if (this.InvokeRequired)
            {
                LeerDelegate leer = new LeerDelegate(Leer);
                this.lsbLista.Invoke(leer);
            }
            else
            {
                    lsbLista.DataSource = clienteDao.Leer();             
            }
        }
    }
}
