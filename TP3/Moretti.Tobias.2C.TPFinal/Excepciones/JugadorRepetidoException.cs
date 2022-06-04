using System;

namespace Excepciones
{
    public class JugadorRepetidoException : Exception
    {
        public JugadorRepetidoException(string mensaje)
          : this(mensaje, null)
        {

        }
        public JugadorRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
