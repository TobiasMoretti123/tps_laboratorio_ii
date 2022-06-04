using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Clase jugador
    /// </summary>
    public class Jugador
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del id del jugador
        /// </summary>
        private int idJugador;
        /// <summary>
        /// Atributo privado del nombre del jugador
        /// </summary>
        private string nombreJugador;
        /// <summary>
        /// Atributo privado del personaje del jugador
        /// </summary>
        private Personaje personaje;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y estable el nombre del jugador
        /// </summary>
        public string NombreJugador
        {
            get
            {
                return this.nombreJugador;
            }
            set
            {
                this.nombreJugador = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el personaje del jugador 
        /// </summary>
        public Personaje Personaje
        {
            get
            {
                return this.personaje;
            }
            set
            {
                this.personaje = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros que inicializa todos los atributos del jugador
        /// </summary>
        public Jugador()
        {
            this.idJugador = 0;
            this.nombreJugador = string.Empty;
            this.personaje = null;
        }
        /// <summary>
        /// Constructor parametrizado que solo toma el nombre y el personaje del jugador
        /// </summary>
        /// <param name="nombreJugador">El nombre del jugador</param>
        /// <param name="personaje">El personaje del jugador</param>
        public Jugador(string nombreJugador,Personaje personaje)
            :this()
        {
            this.nombreJugador = nombreJugador;
            this.personaje = personaje;
        }
        /// <summary>
        /// Constructor parametrizado que toma todos los datos del jugador
        /// </summary>
        /// <param name="idJugador">El id del jugador</param>
        /// <param name="nombreJugador">El nombre del jugador</param>
        /// <param name="personaje">El personaje del jugador</param>
        public Jugador(int idJugador,string nombreJugador,Personaje personaje)
            :this(nombreJugador,personaje)
        {
            this.idJugador = idJugador;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga del metodo ToString de jugador
        /// </summary>
        /// <returns>El nombre del jugador y su personaje a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Jugador: {this.NombreJugador}");
            sb.AppendLine($"Personaje: {this.personaje.ToString()}");
            return sb.ToString();
        }
        #endregion
    }
}
