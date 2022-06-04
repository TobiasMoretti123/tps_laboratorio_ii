using System;


namespace Excepciones
{
    public class VidaInvalidaException : Exception
    {
        public VidaInvalidaException(string mensaje)
           : this(mensaje, null)
        {

        }
        public VidaInvalidaException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
