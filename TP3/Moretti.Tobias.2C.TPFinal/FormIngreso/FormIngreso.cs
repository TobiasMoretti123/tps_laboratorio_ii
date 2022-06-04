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
    public partial class FormIngreso : Form
    {
        private Partida partida;

        public Partida Partida
        {
            get
            {
                return this.partida;
            }
        }
        public FormIngreso(Partida p)
        {
            InitializeComponent();
            this.partida = p;
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            cmbEscuela.DataSource = Enum.GetValues(typeof(Mago.EEscuelaDeMago));
            Limpiar();
        }

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
            cmbClase.SelectedItem = null;
            cmbEscuela.SelectedItem = null;
        }
        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if(cmbClase.SelectedIndex != 2)
            {
               cmbEscuela.Enabled = false;
            }
            else
            {
                cmbEscuela.Enabled = true;
            }
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador();
            List<Exception> excepciones = new List<Exception>();
            try
            {
                if (SonParametrosVacios())
                {
                    throw new ParametrosVaciosException("Uno o mas cuadros de texto estan vacios");
                }
                jugador.NombreJugador = txtNombreJugador.Text;
                switch (cmbClase.SelectedIndex)
                {
                    case 0:
                        jugador.Personaje = new Arquero(txtNombrePersonaje.Text);
                        break;
                    case 1:
                        jugador.Personaje = new Guerrero(txtNombrePersonaje.Text);
                        break;
                    case 2:
                        if (string.IsNullOrEmpty(cmbEscuela.Text))
                        {
                            throw new ParametrosVaciosException("Uno o mas cuadros de texto estan vacios");
                        }
                        jugador.Personaje = new Mago(txtNombrePersonaje.Text);
                        break;
                    default:
                        break;
                }
                try
                {
                    CaracteristicasPersonaje(jugador);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
            }
            catch (Exception ex)
            {
                excepciones.Add(ex);
                VentanaDeErrores(excepciones);
            }
            if(excepciones.Count == 0)
            {
                partida += jugador;
                Limpiar();
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
        private bool SonParametrosVacios()
        {
            if (string.IsNullOrEmpty(txtNombreJugador.Text) || string.IsNullOrEmpty(txtNombrePersonaje.Text)
                || string.IsNullOrEmpty(txtSabiduria.Text) || string.IsNullOrEmpty(txtConstitucion.Text)
                || string.IsNullOrEmpty(txtDestreza.Text) || string.IsNullOrEmpty(txtFuerza.Text)
                || string.IsNullOrEmpty(txtInteligencia.Text) || string.IsNullOrEmpty(txtSabiduria.Text)
                || string.IsNullOrEmpty(txtVidaPersonaje.Text) || string.IsNullOrEmpty(txtNivel.Text))
            {
                return true;
            }
            return false;
        }
        private void CaracteristicasPersonaje(Jugador jugador)
        {
            List<Exception> excepciones = new List<Exception>();
            if (!SonParametrosVacios())
            {
                try
                {
                    jugador.Personaje.Fuerza = int.Parse(txtFuerza.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Destreza = int.Parse(txtDestreza.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Constitucion = int.Parse(txtConstitucion.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Inteligencia = int.Parse(txtInteligencia.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Sabiduria = int.Parse(txtSabiduria.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Carisma = int.Parse(txtCarisma.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.VidaPersonaje = int.Parse(txtVidaPersonaje.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                try
                {
                    jugador.Personaje.Nivel = int.Parse(txtNivel.Text);
                }
                catch (Exception ex)
                {
                    excepciones.Add(ex);
                }
                VentanaDeErrores(excepciones);
            }
        }     
    }
}
