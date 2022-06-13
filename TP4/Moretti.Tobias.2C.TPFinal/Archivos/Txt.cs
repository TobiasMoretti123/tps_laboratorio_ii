using System;
using System.IO;

namespace Archivos
{
    public class Txt : Archivo,IArchivo<string>
    {
        /// <summary>
        /// Propiedad heredada de archivos obtiene la extension .txt harcodeada
        /// </summary>
        protected override string Extencion
        {
            get
            {
                return ".txt";
            }
        }
        /// <summary>
        /// Guarda un archivo en la ruta si es que estos existen
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        public void Guardar(string ruta, string contenido)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }
        /// <summary>
        /// Guarda un archivo existente con un nuevo contenido si es que la extension es valida
        /// </summary>
        /// <param name="ruta">La ruta del archivo existente</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        public void GuardarComo(string ruta, string contenido)
        {
            if (ValidarExtension(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }
        /// <summary>
        /// Guarda un archivo de texto utilizando un stremwriter
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        private void GuardarArchivo(string ruta, string contenido)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                sw.WriteLine(contenido);
            }
        }
        /// <summary>
        /// Lee el archivo y lo devuelve a modo de string utilizando un streamreader
        /// </summary>
        /// <param name="ruta">La ruta del archivo a leer</param>
        /// <returns>Todo el texto del archivo leido</returns>
        public string Leer(string ruta)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    return sr.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
