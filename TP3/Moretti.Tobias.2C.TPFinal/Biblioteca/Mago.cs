using System;
using System.Text;


namespace Biblioteca
{
    public sealed class Mago : Personaje
    {
        public enum EEscuelaDeMago
        {
            Conjuracion,Ilusion,Nigromancia,Transmutacion
        }
        private EEscuelaDeMago escuelaDeMago;
        public EEscuelaDeMago EscuelaDeMago
        {
            get
            {
                return this.escuelaDeMago;
            }
            set
            {
                this.escuelaDeMago = value;
            }
        }
        public Mago()
            :base()
        {

        }
        public Mago(string nombrePersonaje)
            : base(nombrePersonaje)
        {

        }
        public Mago(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel)
            :base(nombrePersonaje,vidaPersonaje,fuerza,destreza,constitucion,inteligencia,sabiduria,carisma,nivel,ETipoArma.Baston)
        {

        }

        public Mago(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel, EEscuelaDeMago escuelaDeMago)
            :this(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma,nivel)
        {
            this.escuelaDeMago = escuelaDeMago;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: MAGO");
            sb.AppendLine($"Escuela: {escuelaDeMago}");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
