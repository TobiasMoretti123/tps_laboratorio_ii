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
using static System.Environment;
using Biblioteca;
using Archivos;

namespace Formularios_TP4
{
    /// <summary>
    /// Formulario manejador de las consultas a la empresa del usuario
    /// </summary>
    public partial class FormConsultas : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de la empresa
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo privado del cliente
        /// </summary>
        private Cliente cliente;
        /// <summary>
        /// Atributo privado manejador de txt
        /// </summary>
        private Txt txt;
        #endregion

        #region Constructores
        /// <summary>
        /// Establece el cliente y la empresa e inicializa el manejador de txt
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="cliente"></param>
        public FormConsultas(Empresa empresa, Cliente cliente)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cliente = cliente;
            txt = new Txt();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece lo que este dentro del richtextbox
        /// </summary>
        public string Contenido
        {
            set { this.rtxConsultas.Text = value; }
            get { return this.rtxConsultas.Text; }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton enviar permite enviar lo escrito en el ritch text box.
        /// Siempre y cuando este entre 50 y 200 caracteres, luego es guardada en un archivo txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (rtxConsultas.Text.Length < 200 && rtxConsultas.Text.Length > 50)
            {      
                try
                {
                    ConstruirConsulta();
                    CrearCarpeta();
                    txt.Guardar(CrearCarpeta() + "\\Consultas.txt", Contenido);
                    Contenido = string.Empty;
                    MessageBox.Show($"Su consulata a sido enviada a {empresa.MailConsultaEmpresa}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("La consulta debe ser entre 50 y 200 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

        #region Metodos
        /// <summary>
        /// Arma la consulta con alguno de los datos del cliente que la manda para el archivo de texto
        /// </summary>
        private void ConstruirConsulta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Recibio una consulta de {cliente.RazonSocial}");
            sb.AppendLine($"Mail {cliente.Mail}");
            sb.AppendLine(rtxConsultas.Text);
            Contenido = sb.ToString();
        }
        /// <summary>
        /// Crea una carpeta en el escritorio donde se guarda el archivo de texto
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
        #endregion

    }
}
