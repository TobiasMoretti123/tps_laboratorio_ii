using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase que maneja los archivos de texto utilizando la interfaz de manejo de datos
    /// </summary>
    public class ManejadorTexto : IManejadorDatos<string>
    {
        /// <summary>
        /// Guarda el archivo a modo de texto, si no existe lo crea
        /// </summary>
        /// <param name="nombreArchivo">El nombre/ruta del archivo donde guardar</param>
        /// <param name="contenido">El contenido a guardar</param>
        /// <exception cref="ArchivoException">Esta excepcion es lanzada cuando no encuentra su directorio</exception>
        public void Guardar(string nombreArchivo, string contenido)
        {
            try
            {
                string rutaCompleta = Path.Combine(nombreArchivo);

                using (StreamWriter streamWriter = new StreamWriter(rutaCompleta))
                {
                    streamWriter.WriteLine(contenido);
                }
            }
            catch (DirectoryNotFoundException ex)
            {

                throw new ArchivoException("El directorio no existe", ex);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Lee el archivo
        /// </summary>
        /// <param name="nombreArchivo">El archivo a leer</param>
        /// <returns></returns>
        /// <exception cref="ArchivoException">Esta excepcion es lanzada cuando no encuentra el archivo o su directorio</exception>
        public string Leer(string nombreArchivo)
        {
            try
            {
                //Pat.Combine combina dos string en una ruta
                string rutaCompleta = Path.Combine(nombreArchivo);
                using (StreamReader streamReader = new StreamReader(rutaCompleta))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new ArchivoException("El directorio no existe", ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new ArchivoException("El archivo no existe", ex);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
