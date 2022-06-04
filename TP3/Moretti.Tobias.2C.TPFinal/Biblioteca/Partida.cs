using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;

namespace Biblioteca
{
    public sealed class Partida
    {
        private string nombrePartida;
        private List<Jugador> jugadores;
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
        public List<Jugador> Jugadores
        {
            get
            {
                return this.jugadores;
            }
        }
        public Partida()
        {
            this.jugadores = new List<Jugador>();
        }
        public Partida(string nombrePartida)
            :this()
        {
            this.NombrePartida = nombrePartida;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(Jugadores is not null)
            {
                foreach (Jugador j in jugadores)
                {
                    sb.AppendLine(j.ToString());
                }
            }
            return sb.ToString();
        }

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
        public static Partida operator - (Partida partida, Jugador jugador)
        {
            if(partida == jugador)
            {
                partida.jugadores.Remove(jugador);
            }
            return partida;
        }
        public static bool operator == (Partida partida, Jugador jugador)
        {
            return partida.Jugadores.Contains(jugador);
        }

        public static bool operator !=(Partida partida, Jugador jugador)
        {
            return !(partida == jugador);
        }
    }
}
