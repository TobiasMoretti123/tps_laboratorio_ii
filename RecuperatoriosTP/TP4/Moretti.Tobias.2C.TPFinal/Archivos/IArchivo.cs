using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz que deben aplicar todos los archivos
    /// </summary>
    /// <typeparam name="T">Tipo generico que representa el contenido a guardar</typeparam>
    internal interface IArchivo<T>
    {
        T Leer(string ruta);

        void Guardar(string ruta, T info);
    }
}
