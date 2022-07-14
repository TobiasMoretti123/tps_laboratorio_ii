using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Clase publica de la resistencia fisica del cilindro hereda de cilindro
    /// </summary>
    public class Fisica : Cilindro
    {
        #region Propiedades
        /// <summary>
        /// Propiedad heredada de cilindro obtiene y estable el precio segun la resistencia del cilindro
        /// </summary>
        public override int Precio
        {
            get
            {
                return this.Tamanio.CacularPrecio(Cilindro.ETipoResistencia.Fisica);
            }
            set
            {
                this.Precio = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor sin parametros de cilindro con resistencia fisica
        /// </summary>
        public Fisica()
        {

        }
        /// <summary>
        /// Contructor que solo establece el tamaño del cilindro con resistencia fisica
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        public Fisica(int tamanio)
            : base(tamanio)
        {

        }
        /// <summary>
        /// Contructor que establece todos los parametros del cilindro con resistencia fisica
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        /// <param name="tipoResistencia"></param>
        public Fisica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de fisica
        /// </summary>
        /// <returns>Retorna la sobrecarga del metodo TuString de la base</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
