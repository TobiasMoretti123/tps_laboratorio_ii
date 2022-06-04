using System;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Clase arquero que hereda de personaje
    /// </summary>
    public sealed class Arquero : Personaje
    {
        #region Constructores
        /// <summary>
        /// Constructor sin parametros utiliza el constructor de la base sin parametros
        /// </summary>
        public Arquero()
            : base()
        {

        }
        /// <summary>
        /// Constructor que solo toma el nombre del personaje utilizando el constructor de la base que toma el nombre
        /// </summary>
        /// <param name="nombrePersonaje">El nombre del personaje</param>
        public Arquero(string nombrePersonaje)
            :base(nombrePersonaje)
        {

        }
        /// <summary>
        /// Constructor que toma todos los atributos del personaje utilizando el constructor de la base que toma todos los parametros 
        /// Un arquero posee un arco por defecto
        /// </summary>
        /// <param name="nombrePersonaje">El nombre del personaje</param>
        /// <param name="vidaPersonaje">La vida del personaje</param>
        /// <param name="fuerza">La caracteristica fuerza del personaje</param>
        /// <param name="destreza">La caracteristica destreza del personaje</param>
        /// <param name="constitucion">La caracteristica constitucion del personaje</param>
        /// <param name="inteligencia">La caracteristica inteligencia del personaje</param>
        /// <param name="sabiduria">La caracteristica sabiduria del personaje</param>
        /// <param name="carisma">La caracteristica carisma del personaje</param>
        /// <param name="nivel">El nivel del personaje</param>
        public Arquero(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel)
           : base(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma,nivel, ETipoArma.Arco)
        {
            
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo to string de arquero
        /// </summary>
        /// <returns>El nombre de la clase mas el dato del personaje a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase: Arquero");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
        #endregion
    }
}
