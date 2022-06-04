using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Jugador
    {
        private int idJugador;
        private string nombreJugador;
        private Personaje personaje;

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

        public Jugador()
        {
            this.idJugador = 0;
            this.nombreJugador = string.Empty;
            this.personaje = null;
        }

        public Jugador(string nombreJugador,Personaje personaje)
            :this()
        {
            this.nombreJugador = nombreJugador;
            this.personaje = personaje;
        }

        public Jugador(int idJugador,string nombreJugador,Personaje personaje)
            :this(nombreJugador,personaje)
        {
            this.idJugador = idJugador;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Jugador: {this.NombreJugador}");
            sb.AppendLine($"Personaje: {this.personaje.ToString()}");
            return sb.ToString();
        }
    }
}
