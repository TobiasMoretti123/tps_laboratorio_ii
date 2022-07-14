using System;
using System.IO;
using static System.Environment;

namespace Archivos
{
    /// <summary>
    /// Clase encargada de manejar archivos de texto 
    /// hereda de Archivo y utiliza la interfaz IArchivo
    /// </summary>
    public class Txt : IArchivo<string>
    {
        /// <summary>
        /// Guarda a modo txt el string pasado por parametro en la ruta 
        /// </summary>
        /// <param name="ruta">La ruta donde se guarde el archivo</param>
        /// <param name="info">El string a guardar en el archivo txt</param>
        public void Guardar(string ruta, string info)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                sw.WriteLine(info);
            }
        }
        /// <summary>
        /// Lee un archivo txt desde la ruta pasada por parametro
        /// </summary>
        /// <param name="ruta">La ruta a leer el txt</param>
        /// <returns>La lectura del archivo a modo string</returns>
        public string Leer(string ruta)
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
