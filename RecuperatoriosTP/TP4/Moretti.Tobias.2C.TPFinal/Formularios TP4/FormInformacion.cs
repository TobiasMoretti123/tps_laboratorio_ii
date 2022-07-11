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

namespace Formularios_TP4
{
    public partial class FormInformacion : Form
    {
        private Empresa empresa;
        private Eventos eventos;
        public FormInformacion(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.eventos = new Eventos();
            eventos.OnLeer += Mostrar;
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
        }

        /// <summary>
        /// Propiedad que obtiene y establece lo que este dentro del richtextbox
        /// </summary>
        public string Contenido
        {
            set { this.rtxDatosEmpresa.Text = value; }
            get { return this.rtxDatosEmpresa.Text; }
        }

        private void FormInformacion_Load(object sender, EventArgs e)
        {
            rtxInfoEmpresa.Text = "En RotaDyne Contamos con la Calidad y el Servicio que te Mereces.\nNos caracterizamos en la elaboración de productos compuestos de caucho y uretano, hechos a la medida para cada cliente dónde controlamos todos los procesos para la manufactura de rodillos.";
        }

        private void Mostrar()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(Mostrar);
                this.rtxDatosEmpresa.Invoke(leer);
            }
            else
            {
                try
                {
                    Contenido = empresa.ToString();
                }
                catch (Exception ex)
                {
                    VentanaDeError(ex);
                }

            }
        }

        /// <summary>
        /// Metodo encargado de mostrar cualquier excepcion como un error
        /// </summary>
        /// <param name="ex"></param>
        private void VentanaDeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
