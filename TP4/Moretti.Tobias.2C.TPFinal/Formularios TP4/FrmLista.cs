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
    /// <summary>
    /// Formulario encargadado de listar los clientes
    /// </summary>
    public partial class FrmLista : Form
    {

        #region Atributos
        /// <summary>
        /// Atributo privado de la empresa 
        /// </summary>
        private Empresa empresa;
        /// <summary>
        /// Atributo privado de la base de datos de cliente
        /// </summary>
        private ClienteDao clientesDao;
        /// <summary>
        /// Atributo privado de la apertura de un archivo
        /// </summary>
        private OpenFileDialog openFileDialog;
        /// <summary>
        /// Atributo privado del guardado de un archivo
        /// </summary>
        private SaveFileDialog saveFileDialog;
        /// <summary>
        /// Atributo privado encargado del xml
        /// </summary>
        private Xml<Empresa> xml;
        /// <summary>
        /// Atributo privado encargado del txt
        /// </summary>
        private Txt texto;
        /// <summary>
        /// Atributo privado de la ruta del ultimo archivo
        /// </summary>
        private string ultimoArchivo;
        /// <summary>
        /// Atributo encargado de manejar eventos
        /// </summary>
        private Eventos eventos;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del formulario de la lista, recibe una empresa
        /// Inicializa sus componentes, Inicializa la apertura de archivos
        /// Inicializa el guardado de archivos, Aplica filtros a ambos, inicializa la empresa
        /// e inicializa el eveto de leer
        /// </summary>
        /// <param name="empresa"></param>
        public FrmLista(Empresa empresa)
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo XML|*.xml";
            this.empresa = empresa;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece lo que este dentro del richtextbox
        /// </summary>
        public string Contenido
        {
            set { this.rtxLista.Text = value; }
            get { return this.rtxLista.Text; }
        }
        /// <summary>
        /// Propiedad que obtiene y establece la ruta del ultimo archivo
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
        #endregion

        #region Botones
        /// <summary>
        /// Boton guardar archivo permite el guardado del mismo, en uno existente o en uno nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton salir cierra el formulario de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Boton eliminar abre el formulario encargado de eliminar clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmCancelar frmCancelar = new FrmCancelar(empresa);
            this.Hide();
            frmCancelar.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Boton modificar abre el formulario encargado de modificar clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            this.Hide();
            frmModificar.ShowDialog();
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Al cargar el formulario el mismo inicializa el txt, xml y la base de datos
        /// Tambien muestra la lista de clientes en la base de datos a ttraves de un hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLista_Load(object sender, EventArgs e)
        {
            texto = new Txt();
            xml = new Xml<Empresa>();
            clientesDao = new ClienteDao();
            eventos = new Eventos();
            eventos.OnLeer += Mostrar;
            Task hilo = new Task(() => eventos.Leer());
            hilo.Start();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que guarda el archivo en una ubicacion seleccionada
        /// </summary>
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
                        texto.GuardarComo(UltimoArchivo, Contenido);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }
        /// <summary>
        /// Metodo que guarda el ultimo archivo 
        /// </summary>
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
                        texto.Guardar(UltimoArchivo, Contenido);
                        break;
                }
            }
            catch (Exception ex)
            {
                VentanaDeError(ex);
            }
        }
        /// <summary>
        /// Metodo que permite seleccionar la ubicacion para guardar el archivo
        /// </summary>
        /// <returns>La ruta donde se guardo el archivo</returns>
        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }
        /// <summary>
        /// Metodo que muestra la lista de clientes de la base de datos
        /// A traves del delegado de leer
        /// </summary>
        private void Mostrar()
        {
            if (this.InvokeRequired)
            {
                Action leer = new Action(Mostrar);
                this.rtxLista.Invoke(leer);
            }
            else
            {
                foreach (Cliente c in clientesDao.Leer())
                {
                    Contenido += "--------------------------------\n";
                    Contenido += c.ToString();
                    Contenido += "Cilindro de Goma\n";
                    Contenido += c.Cilindro.ToString();
                    Contenido += "--------------------------------\n";
                    empresa += c;
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
