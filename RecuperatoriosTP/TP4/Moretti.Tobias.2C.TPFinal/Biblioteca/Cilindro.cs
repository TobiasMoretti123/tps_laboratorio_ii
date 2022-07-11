using System;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Clase publica cilindro
    /// </summary>
    public class Cilindro
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del tamaño del cilindro
        /// </summary>
        private int tamanio;
        /// <summary>
        /// Atributo privado del precio del cilindro
        /// </summary>
        private int precio;
        /// <summary>
        /// Atributo privado del tipo de resistencia del cilindro
        /// </summary>
        private ETipoResistencia tipoResistencia;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado con los tipos de resistencia de un cilindro
        /// el mismo puede tener resistencia fisica,quimica o termica
        /// </summary>
        public enum ETipoResistencia
        {
            Fisica, Quimica, Termica
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para establecer y obtener el tamaño de un cilindro
        /// </summary>
        public int Tamanio
        {
            get => this.tamanio;
            set => this.tamanio = value;
        }
        /// <summary>
        /// Propiedad virtual para establecer y obtener el precio de las clases que la heredan
        /// </summary>
        public int Precio
        {
            get
            {
                if(this.tipoResistencia is ETipoResistencia.Fisica)
                {
                    return this.tamanio.CacularPrecio(ETipoResistencia.Fisica);
                }
                else if(this.tipoResistencia is ETipoResistencia.Quimica)
                {
                    return this.tamanio.CacularPrecio(ETipoResistencia.Quimica);
                }
                else 
                {
                    return this.tamanio.CacularPrecio(ETipoResistencia.Termica);
                }
            }
            set => this.precio = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el tipo de resistencia de un cilindro
        /// </summary>
        public ETipoResistencia TipoResistencia
        {
            get => tipoResistencia;
            set => tipoResistencia = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor sin parametros de un cilindro
        /// </summary>
        public Cilindro()
        {

        }
        /// <summary>
        /// Contructor parametrizado de cilindro que solo establece el tamaño
        /// </summary>
        /// <param name="tamanio"></param>
        public Cilindro(int tamanio)
        {
            this.Tamanio = tamanio;
        }
        /// <summary>
        /// Constructor parametrizado de cilindro que establece todos los datos del cilindro
        /// </summary>
        /// <param name="tamanio"></param>
        /// <param name="tipoResistencia"></param>
        public Cilindro(int tamanio, ETipoResistencia tipoResistencia)
            : this(tamanio)
        {
            this.tipoResistencia = tipoResistencia;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Metodo sobrecargado del metodo TuString crea un stringbuilder con los datos del cilindro
        /// </summary>
        /// <returns>Los datos del cilindro a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Resistencia: {this.tipoResistencia} ");
            sb.AppendLine($"Tamaño: {this.tamanio}mm ");
            sb.AppendLine($"Precio: ${this.Precio} ");
            return sb.ToString();
        }
        #endregion
    }
}
