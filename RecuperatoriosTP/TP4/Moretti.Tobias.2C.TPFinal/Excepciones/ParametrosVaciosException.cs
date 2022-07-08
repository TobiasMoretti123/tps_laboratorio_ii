using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ParametrosVaciosException : Exception
    {
        public ParametrosVaciosException(string mensaje)
         : this(mensaje, null)
        {

        }

        public ParametrosVaciosException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
