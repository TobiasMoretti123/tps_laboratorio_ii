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
        #region Constructores
        /// <summary>
        /// Contructor sin parametros de cilindro con resistencia quimica
        /// </summary>
        public Termica()
        {

        }
        /// <summary>
        /// Contructor que solo establece el tamaño del cilindro con resistencia quimica
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        public Termica(int tamanio)
            : base(tamanio)
        {

        }
        /// <summary>
        /// Contructor que establece todos los parametros del cilindro con resistencia quimica
        /// utilizando el constructor de la base
        /// </summary>
        /// <param name="tamanio"></param>
        /// <param name="tipoResistencia"></param>
        public Termica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de quimica
        /// </summary>
        /// <returns>Retorna la sobrecarga del metodo TuString de la base</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
