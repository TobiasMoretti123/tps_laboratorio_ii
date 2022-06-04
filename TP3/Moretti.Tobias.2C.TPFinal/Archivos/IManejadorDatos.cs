using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IManejadorDatos<T>
        where T : class
    {
        public void Guardar(string nombreArchivo, T contenido);


        public T Leer(string nombreArchivo);
    }
}
