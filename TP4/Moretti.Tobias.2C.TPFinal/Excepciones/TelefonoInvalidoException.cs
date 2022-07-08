using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TelefonoInvalidoException : Exception
    {
        public TelefonoInvalidoException(string mensaje)
         : this(mensaje, null)
        {

        }
        public TelefonoInvalidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
