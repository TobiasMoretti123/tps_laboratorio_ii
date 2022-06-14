using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ClienteRepetidoException : Exception
    {
        public ClienteRepetidoException(string mensaje)
          : this(mensaje, null)
        {

        }
        public ClienteRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
