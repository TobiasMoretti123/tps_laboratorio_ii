using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;
using Biblioteca;
using Archivos;

namespace Formularios_TP4
{
    public partial class FormConsultas : Form
    {
        private Empresa empresa;
        private Cliente cliente;
        private Txt txt;
        public FormConsultas(Empresa empresa, Cliente cliente)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cliente = cliente;
            txt = new Txt();
        }
        /// <summary>
        /// Propiedad que obtiene y establece lo que este dentro del richtextbox
        /// </summary>
        public string Contenido
        {
            set { this.rtxConsultas.Text = value; }
            get { return this.rtxConsultas.Text; }
        }

        private void FormConsultas_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (rtxConsultas.Text.Length < 200 && rtxConsultas.Text.Length > 50)
            {      
                try
                {
                    ConstruirConsulta();
                    txt.Guardar(GetFolderPath(SpecialFolder.Desktop) + "\\Consultas.txt", Contenido);
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConstruirConsulta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Recibio una consulta de {cliente.RazonSocial}");
            sb.AppendLine($"Mail {cliente.Mail}");
            sb.AppendLine(rtxConsultas.Text);
            Contenido = sb.ToString();
        }
    }
}
