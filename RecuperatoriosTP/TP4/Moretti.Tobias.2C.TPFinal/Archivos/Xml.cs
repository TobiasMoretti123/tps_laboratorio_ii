using System.IO;
using System.Xml.Serialization;
using static System.Environment;


namespace Archivos
{
    /// <summary>
    /// Clase encargada de manejar archivos xml 
    /// hereda de Archivo y utiliza la interfaz IArchivo
    /// </summary>
    public class Xml<T> : IArchivo<T>
        where T : class
    {
        public void Guardar(string ruta,T info)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, info);
            }
        }

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
