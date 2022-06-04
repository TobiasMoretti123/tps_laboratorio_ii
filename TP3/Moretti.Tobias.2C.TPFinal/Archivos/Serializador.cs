using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Serializador<T> : IManejadorDatos<T>
        where T : class, new()
    {
        static ManejadorTexto manejadorArchivos;

        static Serializador()
        {
            manejadorArchivos = new ManejadorTexto();
        }

        public void Guardar(string nombreArchivo, T contenido)
        {
            try
            {
                //verifica si la extension es json y serializa en json sino xml
                if (Path.GetExtension(nombreArchivo) == ".json")
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    string json = JsonSerializer.Serialize(contenido, options);

                    //Guardo el objeto en formato JSON en un archivo de texto
                    manejadorArchivos.Guardar(nombreArchivo, json);

                }
                else if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    //Pat.Combine combina dos string en una ruta
                    string rutaCompleta = Path.Combine(nombreArchivo);

                    using (StreamWriter streamWriter = new StreamWriter(rutaCompleta))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));

                        //serializa el objeto y lo guarda en el archivo que recibe en el stream
                        serializer.Serialize(streamWriter, contenido);
                    }
                }
                else
                {
                    throw new ArchivoException("extension invalida");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public T Leer(string nombreArchivo)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".json")
                {
                    //leo el archivo de texto con el objeto serializado en json
                    string json = manejadorArchivos.Leer(nombreArchivo);

                    //recibe el string y lo convierte en objeto
                    return JsonSerializer.Deserialize<T>(json);
                }
                if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    string rutaCompleta = Path.Combine(nombreArchivo);
                    using (XmlTextReader xmlTextReader = new XmlTextReader(rutaCompleta))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(xmlTextReader) as T;
                    }
                }
                else
                {
                    throw new ArchivoException("Extension invalida");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
