using System;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Clase mago que hereda de personaje
    /// </summary>
    public sealed class Mago : Personaje
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de las distintas escuelas de magia
        /// </summary>
        public enum EEscuelaDeMago
        {
            Conjuracion, Ilusion, Nigromancia, Transmutacion
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributo privado de la escuela a la que pertenece el mago
        /// </summary>
        private EEscuelaDeMago escuelaDeMago;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece el atributo escuela de mago
        /// </summary>
        public EEscuelaDeMago EscuelaDeMago
        {
            get
            {
                return this.escuelaDeMago;
            }
            set
            {
                this.escuelaDeMago = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros utiliza el constructor de la base sin parametros
        /// </summary>
        public Mago()
            :base()
        {
            
        }
        /// <summary>
        /// Constructor que solo toma el nombre del personaje utilizando el constructor de la base que toma el nombre y la escuela del mago
        /// </summary>
        /// <param name="nombrePersonaje">El nombre del personaje</param>
        /// <param name="escuelaDeMago">La escuela del mago</param>
        public Mago(string nombrePersonaje, EEscuelaDeMago escuelaDeMago)
            : base(nombrePersonaje)
        {
            this.escuelaDeMago = escuelaDeMago;
        }
        /// <summary>
        /// Constructor que toma todos los atributos del personaje utilizando el constructor de la base que toma todos los parametros 
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
        public Mago(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel, ETipoArma tipoArma)
            : base(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma, nivel, tipoArma)
        {

        }
        /// <summary>
        /// Constructor que toma todos los atributos del personaje y la escuela del mago utilizando el constructor sobrecargado 
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
        public Mago(string nombrePersonaje, int vidaPersonaje,
            int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma, int nivel, ETipoArma tipoArma,EEscuelaDeMago escuelaDeMago)
            : this(nombrePersonaje, vidaPersonaje, fuerza, destreza, constitucion, inteligencia, sabiduria, carisma, nivel, tipoArma)
        {
            this.escuelaDeMago = escuelaDeMago;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo to string de mago
        /// </summary>
        /// <returns>El nombre de la clase mas el dato del personaje a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Escuela: {escuelaDeMago}");
            return sb.ToString();
        }
        #endregion
    }
}
