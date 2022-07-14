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
    /// <summary>
    /// Formulario manejador de la informacion de la empresa
    /// </summary>
    public partial class FormInformacion : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de la empresa
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo manejador de eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Establece la empresa, inicializa el manejador de eventos y el hilo donde va a trabajar
        /// </summary>
        /// <param name="empresa"></param>
        public FormInformacion(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.eventos = new Eventos();
            eventos.OnLeer += Mostrar;
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece lo que este dentro del richtextbox
        /// </summary>
        public string Contenido
        {
            set { this.rtxDatosEmpresa.Text = value; }
            get { return this.rtxDatosEmpresa.Text; }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton volver regresa al menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento cargar estable la informacion de la empresa en su respectivo ritchtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInformacion_Load(object sender, EventArgs e)
        {
            rtxInfoEmpresa.Text = "En RotaDyne Contamos con la Calidad y el Servicio que te Mereces.\nNos caracterizamos en la elaboración de productos compuestos de caucho y uretano, hechos a la medida para cada cliente dónde controlamos todos los procesos para la manufactura de rodillos.";
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la empresa en su respectivo ritchtextbox 
        /// </summary>
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
        #endregion
    }
}
