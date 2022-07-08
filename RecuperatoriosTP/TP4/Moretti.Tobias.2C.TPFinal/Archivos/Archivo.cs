using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase abtracta de manejo de archivos
    /// </summary>
    public abstract class Archivo
    {
        /// <summary>
        /// Propiedad que obtiene la extencion del archivo
        /// </summary>
        protected abstract string Extencion
        {
            get;
        }
        /// <summary>
        /// Valida la ruta ingresada y compara si su extension es la misma
        /// que la de la propiedad
        /// </summary>
        /// <param name="ruta">La ruta a ingresar</param>
        /// <returns>true en caso de que la extencion sea correcta</returns>
        /// <exception cref="ArchivoException">Esta excepcion se lanza cuando la ruta no es valida</exception>
        public bool ValidarExtension(string ruta)
        {
            if ((Path.GetExtension(ruta) != this.Extencion))
            {
                throw new ArchivoException($"La ruta no es valida");
            }
            return true;
        }
        /// <summary>
        /// Valida si existe el archivo en dicha ruta
        /// </summary>
        /// <param name="ruta">La ruta donde estaria el archivo</param>
        /// <returns>true si el archivo existe</returns>
        /// <exception cref="ArchivoException">Esta excepcion es lanzada si el archivo no existe</exception>
        public bool ValidarSiExisteArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new ArchivoException($"El archivo no se encontro");
            }
            return true;
        }
    }
}
