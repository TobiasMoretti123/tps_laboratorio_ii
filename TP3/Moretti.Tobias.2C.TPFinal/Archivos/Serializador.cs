using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase que serializa archivos de tipo json y xml utilizando la interfaz de manejo de datos
    /// </summary>
    /// <typeparam name="T">dato a serializar</typeparam>
    public class Serializador<T> : IManejadorDatos<T>
        where T : class, new()
    {
        /// <summary>
        /// Atributo estatico manejador de archivos del serializador
        /// </summary>
        static ManejadorTexto manejadorArchivos;

        /// <summary>
        /// Constructor estatico de serializador que inicializa el atributo manejador de archivos
        /// </summary>
        static Serializador()
        {
            manejadorArchivos = new ManejadorTexto();
        }

        /// <summary>
        /// Guarda el archivo json o xml a modo de texto
        /// verifica si la extencion es json para guardarlo como tal si no lo guarda como xml
        /// </summary>
        /// <param name="nombreArchivo">El nombre/ruta del archivo a guardar</param>
        /// <param name="contenido">El contenido a guarda</param>
        public void Guardar(string nombreArchivo, T contenido)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".json")
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.WriteIndented = true;
                    string json = JsonSerializer.Serialize(contenido, options);
                    manejadorArchivos.Guardar(nombreArchivo, json);

                }
                else if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    string rutaCompleta = Path.Combine(nombreArchivo);
                    using (StreamWriter streamWriter = new StreamWriter(rutaCompleta))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
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
        /// <summary>
        /// Lee el archivo json o xml, verificando si es json lee json si no lee xml
        /// </summary>
        /// <param name="nombreArchivo">El archivo a leer</param>
        /// <returns>La deserializacion de xml o json del objeto</returns>
        public T Leer(string nombreArchivo)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".json")
                {
                    string json = manejadorArchivos.Leer(nombreArchivo);

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
