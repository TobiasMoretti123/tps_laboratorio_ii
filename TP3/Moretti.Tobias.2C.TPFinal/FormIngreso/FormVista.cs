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
using System.Text.Json;
using Archivos;
using Excepciones;
using Biblioteca;

namespace FormIngreso
{
    public partial class FormVista : Form
    {
        private Partida partida;
        private ManejadorTexto texto = new ManejadorTexto();
        private Serializador<Partida> serializador = new Serializador<Partida>();
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
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
        public FormVista(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
        }

        private void FormVista_Load(object sender, EventArgs e)
        {
            rtxInfo.Text += partida.ToString();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(UltimoArchivo))
            {
                UltimoArchivo = SeleccionarUbicacionGuardado();
            }

            GuardarArchivo(UltimoArchivo);
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            GuardarArchivo(UltimoArchivo);
        }

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void GuardarArchivo(string ruta)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ruta))
                {
                    texto.Guardar(ultimoArchivo,rtxInfo.Text);
                }
            }
            catch (Exception ex)
            {
                VentanaDeErrores(ex);
            }
        }

        private void VentanaDeErrores(List<Exception> errores)
        {
            foreach (Exception ex in errores)
            {
                VentanaDeErrores(ex);
            }
        }
        private void VentanaDeErrores(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ultimoArchivo = openFileDialog.FileName;
                    rtxInfo.Text = texto.Leer(ultimoArchivo);
                }
                catch (Exception ex)
                {
                    VentanaDeErrores(ex);
                }
            }
        }
    }
}
