using System.IO;
using System.Text.Json;

namespace Archivos
{
    public class Json<T> : Archivo,IArchivo<T>
        where T : class, new()
    {
        protected override string Extencion
        {
            get
            {
                return ".json";
            }
        }

        public void Guardar(string ruta, T contenido)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        private void Serializar(string ruta, T contenido)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                JsonSerializerOptions option = new JsonSerializerOptions();
                option.WriteIndented = true;

                string json = JsonSerializer.Serialize(contenido,contenido.GetType(),option);
                sw.Write(json);
            }
        }

        public T Leer(string ruta)
        {
            if (ValidarSiExisteArchivo(ruta) && ValidarExtension(ruta))
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
