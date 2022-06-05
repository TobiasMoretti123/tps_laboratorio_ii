using System;
using System.IO;
using System.Text.Json;

namespace Archivos
{
    /// <summary>
    /// Clase generica json, maneja archivos tipo json 
    /// Hereda de archivos y utiliza la interfaz de archivos
    /// </summary>
    /// <typeparam name="T">Tipo generico con el que trabaja la clase, debe ser de clase</typeparam>
    public class Json<T> : Archivo, IArchivo<T>
        where T : class
    {
        /// <summary>
        /// Propiedad heredada de archivos obtiene la extension .json harcodeada
        /// </summary>
        protected override string Extencion
        {
            get
            {
                return ".json";
            }
        }
        /// <summary>
        /// Guarda un archivo en la ruta si es que estos existen
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        public void Guardar(string ruta, T contenido)
        {
            if(ValidarExtension(ruta) && ValidarSiExisteArchivo(ruta))
            {
                Serializar(ruta, contenido);
            }
        }
        /// <summary>
        /// Guarda un archivo existente con un nuevo contenido si es que la extension es valida
        /// </summary>
        /// <param name="ruta">La ruta del archivo existente</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }
        /// <summary>
        /// Serializa el contenido T utilizando JsonSerializer y lo guarda como texto
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar el contenido serializado</param>
        /// <param name="contenido">El contenido/objeto a serializar</param>
        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                sw.Write(json);
            }
        }
        /// <summary>
        /// Lee el archivo y lo devuelve a modo de el tipo generico utilizando
        /// JsonSerializer.Deserialize
        /// </summary>
        /// <param name="ruta">La ruta del archivo a leer</param>
        /// <returns>El contenido como objeto de tipo T deserializado</returns>
        public T Leer(string ruta)
        {
            if(ValidarExtension(ruta) && ValidarSiExisteArchivo(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string json = sr.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            return null;
        }
    }
}
