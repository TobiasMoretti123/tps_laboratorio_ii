using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CuitInvalidoException : Exception
    {
        public CuitInvalidoException(string mensaje)
         : this(mensaje, null)
        {

        }
        public CuitInvalidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
