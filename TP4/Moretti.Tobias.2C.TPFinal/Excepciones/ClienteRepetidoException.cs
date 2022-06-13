using System;

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
