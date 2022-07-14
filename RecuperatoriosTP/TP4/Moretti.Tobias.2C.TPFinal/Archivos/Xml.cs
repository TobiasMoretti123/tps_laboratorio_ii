using System.IO;
using System.Xml.Serialization;


namespace Archivos
{
    /// <summary>
    /// Clase encargada de manejar archivos xml 
    /// hereda de Archivo y utiliza la interfaz IArchivo
    /// </summary>
    public class Xml<T> : IArchivo<T>
        where T : class
    {
        /// <summary>
        /// Serializa a modo xml el objeto pasado por parametro en la ruta 
        /// </summary>
        /// <param name="ruta">La ruta donde se encuentra el archivo xml</param>
        /// <param name="info">El objeto a guardar</param>
        public void Guardar(string ruta,T info)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, info);
            }
        }
        /// <summary>
        /// Deserializa un archivo xml desde la ruta pasada por parametro
        /// </summary>
        /// <param name="ruta">La ruta que contiene el archivo xml a deserializar</param>
        /// <returns>El objeto deserializado</returns>
        public T Leer(string ruta)
        {
            using (StreamReader streamReader = new StreamReader(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.Deserialize(streamReader) as T;
            }
        }
    }
}
