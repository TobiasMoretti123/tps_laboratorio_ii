using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ContraseniaIncorrectaExeption : Exception
    {
        public ContraseniaIncorrectaExeption(string mensaje)
        : this(mensaje, null)
        {

        }

        public ContraseniaIncorrectaExeption(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
