using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Excepciones;


namespace Biblioteca
{
    /// <summary>
    /// Clase partida
    /// </summary>
    [XmlInclude(typeof(Arquero))]
    [XmlInclude(typeof(Mago))]
    [XmlInclude(typeof(Guerrero))]
    public class Partida
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del nombre de la partida
        /// </summary>
        private string nombrePartida;
        /// <summary>
        /// Atributo de la lista privada de jugadores de la partida
        /// </summary>
        private List<Jugador> jugadores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece el nombre de la partida
        /// </summary>
        public string NombrePartida
        {
            get
            {
                return this.nombrePartida;
            }
            set
            {
                this.nombrePartida = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece la lista de jugadores de la partida
        /// </summary>
        public List<Jugador> Jugadores
        {
            get
            {
                return this.jugadores;
            }
            set
            {
                this.jugadores = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros que inicializa la lista de jugadores
        /// </summary>
        public Partida()
        {
            this.jugadores = new List<Jugador>();
        }
        /// <summary>
        /// Constructor parametrizado que solo toma el nombre de la partida
        /// </summary>
        /// <param name="nombrePartida">El nombre de la partida</param>
        public Partida(string nombrePartida)
            :this()
        {
            this.NombrePartida = nombrePartida;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>Retorna la lista de jugadores a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();   
            if(Jugadores is not null)
            {
                sb.AppendLine(this.nombrePartida.ToUpper());
                foreach (Jugador j in jugadores)
                {
                    sb.AppendLine(j.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador + de la clase partida compara que el jugador no se encuentra en la partida y lo agrega a la lista
        /// </summary>
        /// <param name="partida">La partida a agregar el jugador</param>
        /// <param name="jugador">El jugador a agregar</param>
        /// <returns>La partida</returns>
        /// <exception cref="JugadorRepetidoException">Esta excepcion es lanzada cuando el jugador es repetido</exception>
        public static Partida operator + (Partida partida, Jugador jugador)
        {
            if(partida == jugador)
            {
                partida -= jugador;
                throw new JugadorRepetidoException("El jugador ya se encuentra en la lista");
            }
            partida.jugadores.Add(jugador);
            return partida;
        }
        /// <summary>
        /// Operador - de la clase partida remueve al jugador de la lista si ya esta contenido en la lista
        /// </summary>
        /// <param name="partida">La partida a remover</param>
        /// <param name="jugador">El jugador a comparar</param>
        /// <returns>La partida</returns>
        public static Partida operator - (Partida partida, Jugador jugador)
        {
            if(partida == jugador)
            {
                partida.jugadores.Remove(jugador);
            }
            return partida;
        }
        /// <summary>
        /// Una partida y un jugador son iguales cuando la lista de jugadores de la partida
        /// posee al jugador 
        /// </summary>
        /// <param name="partida">La partida con la lista</param>
        /// <param name="jugador">El jugador a corroborar si esta en la lista</param>
        /// <returns>true si el jugador esta en la lista false si no lo esta</returns>
        public static bool operator == (Partida partida, Jugador jugador)
        {
            return partida.Jugadores.Contains(jugador);
        }
        /// <summary>
        /// Una partida y un jugador son distintos cuando la lista de jugadores de la partida
        /// no posee al jugador 
        /// </summary>
        /// <param name="partida">La partida con la lista</param>
        /// <param name="jugador">El jugador a corroborar si esta en la lista</param>
        /// <returns>false si el jugador esta en la lista true si no lo esta</returns>
        public static bool operator !=(Partida partida, Jugador jugador)
        {
            return !(partida == jugador);
        }
        #endregion
    }
}
