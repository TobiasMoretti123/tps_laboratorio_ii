using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class ManejadorTexto : IManejadorDatos<string>
    {
        /// <summary>
        /// Guarda el string que recibe como parametro en la ruta especificada
        /// Si el archivo no exite lo crea
        /// Si el archivo existe pisa el contenido
        /// Si el directorio no existe lanza una ArchivoException
        /// </summary>
        /// <param name="path">ruta de directorios</param>
        /// <param name="nombreArchivo">nombre del archivo con sus extension</param>
        /// <param name="contenido"> texto a guardar</param>
        public void Guardar(string nombreArchivo, string contenido)
        {
            try
            {
                //Pat.Combine combina dos string en una ruta
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
        /// Lee el archivo en la ruta especificada
        /// </summary>
        /// <param name="path">ruta de directoros</param>
        /// <param name="nombreArchivo">nombre del archivo y su extension</param>
        /// <returns>contenido del archivo</returns>
        /// <exception cref="ArchivoException">si el directorio o el archivo no existe</exception>
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
