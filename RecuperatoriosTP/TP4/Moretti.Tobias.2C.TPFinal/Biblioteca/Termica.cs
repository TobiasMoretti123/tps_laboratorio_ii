using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Clase publica de la resistencia termica del cilindro hereda de cilindro
    /// </summary>
    public class Termica : Cilindro
    {
        #region Propiedades
        /// <summary>
        /// Propiedad heredada de cilindro obtiene y estable el precio segun la resistencia del cilindro
        /// </summary>
        public override int Precio
        {
            get
            {
                return this.Tamanio.CacularPrecio(Cilindro.ETipoResistencia.Termica);
            }
            set
            {
                this.Precio = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor sin parametros de cilindro con resistencia termica
        /// </summary>
        public Termica()
        {

        }
        /// <summary>
        /// Contructor que solo establece el tamaño del cilindro con resistencia termica
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        public Termica(int tamanio)
            : base(tamanio)
        {

        }
        /// <summary>
        /// Contructor que establece todos los parametros del cilindro con resistencia termica menos id
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        /// <param name="tipoResistencia"></param>
        public Termica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }
        /// <summary>
        /// Constructor parametrizado de cilindro que establece todos los datos del cilindro con resistencia Termica
        /// </summary>
        /// <param name="idCilindro"></param>
        /// <param name="tamanio"></param>
        /// <param name="tipoResistencia"></param>
        public Termica(int idCilindro, int tamanio, ETipoResistencia tipoResistencia)
            : base(idCilindro, tamanio, tipoResistencia)
        {

        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de termica
        /// </summary>
        /// <returns>Retorna la sobrecarga del metodo TuString de la base</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
