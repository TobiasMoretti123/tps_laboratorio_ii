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
        /// <summary>
        /// Metodo leer de la interfaz, su funcion debe ser manejada por las que la aplican
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        T Leer(string ruta);
        /// <summary>
        /// Funcion guardar de la interfaz, su funcion debe ser manejada por las que la aplican
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="info"></param>
        void Guardar(string ruta, T info);
    }
}
