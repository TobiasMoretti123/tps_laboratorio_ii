using System;

namespace Excepciones
{
    public class CaracteristicaInvalidaException : Exception
    {
        public CaracteristicaInvalidaException(string mensaje)
           : this(mensaje, null)
        {

        }
        public CaracteristicaInvalidaException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
