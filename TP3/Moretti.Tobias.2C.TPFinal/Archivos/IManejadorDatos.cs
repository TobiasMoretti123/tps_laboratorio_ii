using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz que deben aplicar todo lo relacionado a archivos
    /// </summary>
    /// <typeparam name="T">Tipo de parametro generico que maneja la interfaz</typeparam>
    public interface IManejadorDatos<T>
        where T : class
    {
        /// <summary>
        /// Guarda el contenido en el archivo
        /// </summary>
        /// <param name="nombreArchivo">El nombre del archivo/ruta donde guardar el contenido</param>
        /// <param name="contenido">El contenido a guardar</param>
        public void Guardar(string nombreArchivo, T contenido);
        /// <summary>
        /// Lee el archivo
        /// </summary>
        /// <param name="nombreArchivo">El nombre del archivo/ruta a leer</param>
        /// <returns>Tipo generico de la lectura del archivo</returns>
        public T Leer(string nombreArchivo);
    }
}
