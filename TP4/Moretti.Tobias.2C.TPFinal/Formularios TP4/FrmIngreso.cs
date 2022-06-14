using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using Biblioteca;
using BaseDeDatos;

namespace Formularios_TP4
{
    public partial class FrmIngreso : Form
    {
        private Cliente cliente;
        private ClienteDao clienteDao;
        public FrmIngreso()
        {
            InitializeComponent();
        }
        public string Nombre
        {
            get
            {
                return this.txtNombre.Text;
            }
            set
            {
                this.txtNombre.Text = value;
            }
        }

        public string Cuit
        {
            get
            {
                return this.txtCuit.Text;
            }
            set
            {
                this.txtCuit.Text = value;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Exception> excepciones = new List<Exception>();
            Task t;
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCuit.Text)
                 || string.IsNullOrEmpty(cmbResistencia.Text))
                {
                    throw new ParametrosVaciosException("Uno o mas cuadros de texto estan vacios");
                }
            }
            catch (ParametrosVaciosException ex)
            {
                excepciones.Add(ex);
            }


            try
            {
                if (!txtCuit.Text.CacularCuit())
                    throw new ArgumentException("El cuit es de 11 digitos sin guiones o espacios");
            }
            catch (ArgumentException ex)
            {
                excepciones.Add(ex);
            }

            this.Nombre = txtNombre.Text;
            this.Cuit = txtCuit.Text;

            switch (cmbResistencia.SelectedIndex)
            {
                case 0:
                    cliente = new Cliente(this.Nombre, this.Cuit, new Fisica(100, Cilindro.ETipoResistencia.Fisica));
                    break;
                case 1:
                    cliente = new Cliente(this.Nombre, this.Cuit, new Quimica(100, Cilindro.ETipoResistencia.Quimica));
                    break;
                case 2:
                    cliente = new Cliente(this.Nombre, this.Cuit, new Termica(100, Cilindro.ETipoResistencia.Quimica));
                    break;
            }
            if (excepciones.Count == 0)
            {
                try
                {
                    t = Task.Run(() => clienteDao.Guardar(cliente));
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en el cliente");
                }
            }
            else
            {
                VentanaDeErrores(excepciones);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            clienteDao = new ClienteDao();
            cmbResistencia.DataSource = Enum.GetValues(typeof(Cilindro.ETipoResistencia));
        }

        private void VentanaDeErrores(List<Exception> ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception e in ex)
            {
                sb.AppendLine($"{e.Message}");
            }
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
