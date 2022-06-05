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
        #region Atributos
        /// <summary>
        /// Atributo privado de la partida
        /// </summary>
        private Partida partida;
        /// <summary>
        /// Atributo privado de el archivo abierto
        /// </summary>
        private OpenFileDialog openFileDialog;
        /// <summary>
        /// Atributo privado de el archivo a guardar
        /// </summary>
        private SaveFileDialog saveFileDialog;
        /// <summary>
        /// Atributo privado de el ultimo archivo
        /// </summary>
        private string ultimoArchivo;
        /// <summary>
        /// Atributo privado que va a manejar los archivos json
        /// </summary>
        private Json<string> json;
        /// <summary>
        /// Atributo privado que va a manejar los archivos xml
        /// </summary>
        private Xml<string> xml;
        /// <summary>
        /// Atributo privado que va a manejar los archivos txt
        /// </summary>
        private Texto texto;
        #endregion

        /// <summary>
        /// Obtiene y sete el ultimo archivo siempre y cuando el value no sea vacio
        /// </summary>
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
        /// <summary>
        /// Establece la partida ingresada
        /// Genera un openFileDialog y le coloca su filtro
        /// Genera un saveFileDialog y le coloca su filtro
        /// </summary>
        /// <param name="partida"></param>
        public FormVista(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";       
        }
        /// <summary>
        /// Al cargar el formulario el richtextbox obtiene la partida cargada
        /// Genera un manejador de json
        /// Genera un manejador de xml
        /// Genera un manejador de txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVista_Load(object sender, EventArgs e)
        {
            rtxInfo.Text = partida.ToString();
            json = new Json<string>();
            xml = new Xml<string>();
            texto = new Texto();
        }
        /// <summary>
        /// Cuando la opcion abrir del menu strip se clickea
        /// Verifico su extencion y abro respectivamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ultimoArchivo = openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(ultimoArchivo))
                    {
                        case ".json":
                            rtxInfo.Text = json.Leer(ultimoArchivo);
                            break;
                        case ".xml":
                            rtxInfo.Text = xml.Leer(ultimoArchivo);
                            break;
                        case ".txt":
                            rtxInfo.Text = texto.Leer(ultimoArchivo);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    VentanaDeError(ex);
                }
            }
        }
        /// <summary>
        /// Cuando la opcion guardar como del menu strip se clickea
        /// Utilizo el metodo GuardarComo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }
        /// <summary>
        /// Cuando la opcion guardar del menu strip se clickea
        /// Utilizo el metodo GuardarComo si el archivo existe
        /// Utilizo el metodo Guardar si no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Abre la ubicacion seleccionada y verifica su extension guardando respectivamente
        /// </summary>
        private void GuardarComo()
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        json.GuardarComo(UltimoArchivo, rtxInfo.Text);
                        break;
                    case ".xml":
                        xml.GuardarComo(UltimoArchivo, rtxInfo.Text);
                        break;
                    case ".txt":
                        texto.GuardarComo(UltimoArchivo, rtxInfo.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }
        /// <summary>
        /// Guarda el ultimo archivo abierto en su respectiva extension
        /// </summary>
        private void Guardar()
        {
            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        json.Guardar(UltimoArchivo, rtxInfo.Text);
                        break;
                    case ".xml":
                        xml.Guardar(UltimoArchivo, rtxInfo.Text);
                        break;
                    case ".txt":
                        texto.Guardar(UltimoArchivo, rtxInfo.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }
        /// <summary>
        /// Permite selecionar la ubicacion del archivo 
        /// </summary>
        /// <returns>El nombre del archivo</returns>
        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }
        /// <summary>
        /// Muestra la excepcion a modo de messabox
        /// </summary>
        /// <param name="ex"></param>
        private void VentanaDeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }  
    }
}
