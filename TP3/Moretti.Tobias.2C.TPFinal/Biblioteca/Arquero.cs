using System;
using System.Text;

namespace Biblioteca
{
    public sealed class Arquero : Personaje
    {
        public Arquero()
            : base()
        {

        }
        public Arquero(string nombrePersonaje)
            :base(nombrePersonaje)
        {

        }
        public Arquero(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel)
           : base(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma,nivel, ETipoArma.Arco)
        {
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: Arquero");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
