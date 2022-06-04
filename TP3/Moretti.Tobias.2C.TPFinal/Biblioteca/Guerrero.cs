using System;
using System.Text;

namespace Biblioteca
{
    public sealed class Guerrero : Personaje
    {
        public Guerrero()
            : base()
        {

        }
        public Guerrero(string nombrePersonaje)
            : base(nombrePersonaje)
        {

        }
        public Guerrero(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel)
            : base(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma,nivel, ETipoArma.Espada)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: GUERRERO");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
