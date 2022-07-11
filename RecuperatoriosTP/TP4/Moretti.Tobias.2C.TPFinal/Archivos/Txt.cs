using System;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Clase encargada de manejar archivos de texto 
    /// hereda de Archivo y utiliza la interfaz IArchivo
    /// </summary>
    public class Txt : IArchivo<string>
    {
        public void Guardar(string ruta, string info)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                sw.WriteLine(info);
            }
        }

        public string Leer(string ruta)
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
