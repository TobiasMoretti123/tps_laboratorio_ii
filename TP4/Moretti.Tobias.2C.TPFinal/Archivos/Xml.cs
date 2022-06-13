using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : Archivo,IArchivo<T>
        where T : class
    {
        /// <summary>
        /// Propiedad heredada de archivos obtiene la extension .xml harcodeada
        /// </summary>
        protected override string Extencion
        {
            get
            {
                return ".xml";
            }
        }
        /// <summary>
        /// Guarda un archivo en la ruta si es que estos existen
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar</param>
        /// <param name="contenido">El contenido a guardar en el archivo</param>
        public void Guardar(string ruta, T contenido)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
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
        /// Serializa el contenido T utilizando XmlSerializer y lo guarda como texto
        /// </summary>
        /// <param name="ruta">La ruta del archivo a guardar el contenido serializado</param>
        /// <param name="contenido">El contenido/objeto a serializar</param>
        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, contenido);
            }
        }
        /// <summary>
        /// Lee el archivo y lo devuelve a modo de el tipo generico utilizando
        /// XmlSerializer.Deserialize
        /// </summary>
        /// <param name="ruta">La ruta del archivo a leer</param>
        /// <returns>El contenido como objeto de tipo T deserializado</returns>
        public T Leer(string ruta)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return xmlSerializer.Deserialize(streamReader) as T;
                }
            }
            return null;
        }
    }
}
