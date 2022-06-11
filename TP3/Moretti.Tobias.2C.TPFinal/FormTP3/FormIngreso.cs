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
using Excepciones;

namespace FormIngreso
{
    /// <summary>
    /// Clase parcial del formulario de ingreso de datos
    /// </summary>
    public partial class FormIngreso : Form
    {
        /// <summary>
        /// Atributo privado de la partida
        /// </summary>
        private Partida partida;
        /// <summary>
        /// Propiedad que obtiene la partida
        /// </summary>
        protected Partida Partida
        {
            get
            {
                return this.partida;
            }
        }
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        /// <param name="p">La partida a cargar datos</param>
        public FormIngreso(Partida p)
        {
            InitializeComponent();
            this.partida = p;
        }
        /// <summary>
        /// Carga el formulario, establiciendo el combobox con los values requeridos
        /// Y limpia los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormIngreso_Load(object sender, EventArgs e)
        {
            cmbEscuela.DataSource = Enum.GetValues(typeof(Mago.EEscuelaDeMago));
            Limpiar();
        }
        /// <summary>
        /// Hace que todos los textbox y combobox esten vacios
        /// </summary>
        private void Limpiar()
        {
            txtNombreJugador.Text = string.Empty;
            txtNombrePersonaje.Text = string.Empty;
            txtCarisma.Text = string.Empty;
            txtConstitucion.Text = string.Empty;
            txtDestreza.Text = string.Empty;
            txtFuerza.Text = string.Empty;
            txtInteligencia.Text = string.Empty;
            txtSabiduria.Text = string.Empty;
            txtVidaPersonaje.Text = string.Empty;
            txtNivel.Text = string.Empty;
            cmbClase.SelectedItem = null;
            cmbEscuela.SelectedItem = null;
        }
        /// <summary>
        /// Verifica que el combo box index cambie
        /// Si un personaje no es un mago entonces el combo de escuela magia estaria bloqueado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClase.SelectedIndex != 2)
            {
                cmbEscuela.Enabled = false;
            }
            else
            {
                cmbEscuela.Enabled = true;
            }
        }
        /// <summary>
        /// Crea un jugador, verifica si los ingresos del formulario estan vacios
        /// Luego establece dichos datos a los personajes dependiendo de cual halla elegido
        /// Para finalmente agrega el jugador con su personaje a la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador();
            List<Exception> excepciones = new List<Exception>();

            try
            {
                SonParametrosVacios();
            }
            catch (ParametrosVaciosException ex)
            {
                excepciones.Add(ex);
            }

            jugador.NombreJugador = txtNombreJugador.Text;

            switch (cmbClase.SelectedIndex)
            {
                case 0:
                    jugador.Personaje = new Arquero(txtNombrePersonaje.Text);
                    jugador.Personaje.TipoArma = ETipoArma.Arco;
                    jugador.Personaje.Clase = EClase.Arquero;
                    break;
                case 1:
                    jugador.Personaje = new Guerrero(txtNombrePersonaje.Text);
                    jugador.Personaje.TipoArma = ETipoArma.Espada;
                    jugador.Personaje.Clase = EClase.Guerrero;
                    break;
                case 2:
                    if (string.IsNullOrEmpty(cmbEscuela.Text))
                    {
                        excepciones.Add(new ParametrosVaciosException("No se selecciono la escuela de magia"));
                        jugador.Personaje = new Arquero(txtNombrePersonaje.Text);
                    }
                    else
                    {
                        jugador.Personaje = new Mago(txtNombrePersonaje.Text,(Mago.EEscuelaDeMago)cmbEscuela.SelectedItem);
                        jugador.Personaje.TipoArma = ETipoArma.Baston;
                        jugador.Personaje.Clase = EClase.Mago;
                    }
                    break;
                default:
                    break;
            }

            try
            {
                jugador.Personaje.Fuerza = int.Parse(txtFuerza.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica fuerza esta vacia"));
            }

            try
            {
                jugador.Personaje.Destreza = int.Parse(txtDestreza.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica destreza esta vacia"));
            }

            try
            {
                jugador.Personaje.Constitucion = int.Parse(txtConstitucion.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica constitucion esta vacia"));
            }

            try
            {
                jugador.Personaje.Inteligencia = int.Parse(txtInteligencia.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica inteligencia esta vacia"));
            }

            try
            {
                jugador.Personaje.Sabiduria = int.Parse(txtSabiduria.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica sabiduria esta vacia"));
            }

            try
            {
                jugador.Personaje.Carisma = int.Parse(txtCarisma.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica carisma esta vacia"));
            }

            try
            {
                jugador.Personaje.VidaPersonaje = int.Parse(txtVidaPersonaje.Text);
            }
            catch (VidaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica vida esta vacia"));
            }

            try
            {
                jugador.Personaje.Nivel = int.Parse(txtNivel.Text);
            }
            catch (CaracteristicaInvalidaException ex)
            {
                excepciones.Add(ex);
            }
            catch (FormatException)
            {
                excepciones.Add(new FormatException("La caracteristica nivel esta vacia"));
            }

            if (excepciones.Count == 0)
            {
                partida += jugador;
                Limpiar();
            }
            else
            {
                VentanaDeErrores(excepciones);
            }
        }
        /// <summary>
        /// Muestra todas las exepciones a modo de lista como un error
        /// </summary>
        /// <param name="ex"></param>
        private void VentanaDeErrores(List<Exception> ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception e in ex)
            {
                sb.AppendLine($"{e.Message}");
            }
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Pregunta si los ingresos del formulario estan vacios
        /// </summary>
        private void SonParametrosVacios()
        {
            if (string.IsNullOrEmpty(txtNombreJugador.Text) || string.IsNullOrEmpty(txtNombrePersonaje.Text)
                || string.IsNullOrEmpty(txtSabiduria.Text) || string.IsNullOrEmpty(txtConstitucion.Text)
                || string.IsNullOrEmpty(txtDestreza.Text) || string.IsNullOrEmpty(txtFuerza.Text)
                || string.IsNullOrEmpty(txtInteligencia.Text) || string.IsNullOrEmpty(txtSabiduria.Text)
                || string.IsNullOrEmpty(txtVidaPersonaje.Text) || string.IsNullOrEmpty(txtNivel.Text))
            {
                throw new ParametrosVaciosException("Uno o mas parametros estan vacios");
            }
        }
    }
}
