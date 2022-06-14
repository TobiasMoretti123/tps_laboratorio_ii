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
using BaseDeDatos;
using Archivos;
using Biblioteca;

namespace Formularios_TP4
{
    public partial class FrmLista : Form
    {
        private Empresa empresa;
        private delegate void LeerDelegate();
        private ClienteDao clientesDao;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Xml<Empresa> xml;
        private Txt texto;
        private string ultimoArchivo;
        public FrmLista(Empresa empresa)
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo XML|*.xml";
            this.empresa = empresa;
        }

        public string Contenido
        {
            set { this.rtxLista.Text = value; }
            get { return this.rtxLista.Text; }
        }

        private string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(UltimoArchivo))
            {
                GuardarComo();
            }
            else
            {
                Guardar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmCancelar frmCancelar = new FrmCancelar();
            this.Hide();
            frmCancelar.ShowDialog();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            this.Hide();
            frmModificar.ShowDialog();
            this.Close();
        }

        private void FrmLista_Load(object sender, EventArgs e)
        {
            texto = new Txt();
            xml = new Xml<Empresa>();
            clientesDao = new ClienteDao();
            Task t = Task.Run(() => Mostrar());        
        }

        private void GuardarComo()
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".xml":
                        xml.GuardarComo(UltimoArchivo, empresa);
                        break;
                    case ".txt":
                        texto.GuardarComo(UltimoArchivo, rtxLista.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }

        private void Guardar()
        {
            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".xml":
                        xml.Guardar(UltimoArchivo, empresa);
                        break;
                    case ".txt":
                        texto.Guardar(UltimoArchivo, rtxLista.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void Mostrar()
        {
            if (this.InvokeRequired)
            {
                LeerDelegate leer = new LeerDelegate(Mostrar);
                this.rtxLista.Invoke(leer);
            }
            else
            {
                foreach (Cliente c in clientesDao.Leer())
                {
                    rtxLista.Text += "--------------------------------\n";
                    rtxLista.Text += c.ToString();
                    rtxLista.Text += "Cilindro de Goma\n";
                    rtxLista.Text += c.Cilindro.ToString();
                    rtxLista.Text += "--------------------------------\n";
                    empresa += c;
                }
            }      
        }

        private void VentanaDeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
