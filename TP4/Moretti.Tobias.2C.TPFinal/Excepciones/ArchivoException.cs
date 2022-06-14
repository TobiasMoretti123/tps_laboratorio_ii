using System;

namespace Excepciones
{
    public class ArchivoException : Exception
    {
        public ArchivoException(string mensaje)
         : this(mensaje, null)
        {

        }
        public ArchivoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
