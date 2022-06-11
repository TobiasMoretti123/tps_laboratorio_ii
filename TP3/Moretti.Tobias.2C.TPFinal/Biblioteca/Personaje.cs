using System;
using System.Text;
using Excepciones;

namespace Biblioteca
{
    #region Enumerados
    /// <summary>
    /// Enumerado publico con los distintos tipos de arma
    /// </summary>
    public enum ETipoArma
    {
        Espada,Arco,Baston
    }

    public enum EClase
    {
        Arquero,Guerrero,Mago
    }
    #endregion

    /// <summary>
    /// Clase personaje
    /// </summary>
    public class Personaje
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del nombre del personaje
        /// </summary>
        private string nombrePersonaje;
        /// <summary>
        /// Atributo privado de la vida del personaje
        /// </summary>
        private int vidaPersonaje;
        /// <summary>
        /// Atributo privado de la caracteristica fuerza del personaje
        /// </summary>
        private int fuerza;
        /// <summary>
        /// Atributo privado de la caracteristica destreza del personaje
        /// </summary>
        private int destreza;
        /// <summary>
        /// Atributo privado de la caracteristica constitucion del personaje
        /// </summary>
        private int constitucion;
        /// <summary>
        /// Atributo privado de la caracteristica inteligencia del personaje
        /// </summary>
        private int inteligencia;
        /// <summary>
        /// Atributo privado de la caracteristica sabiduria del personaje
        /// </summary>
        private int sabiduria;
        /// <summary>
        /// Atributo privado de la caracteristica carisma del personaje
        /// </summary>
        private int carisma;
        /// <summary>
        /// Atributo privado del nivel del personaje
        /// </summary>
        private int nivel;
        /// <summary>
        /// Atributo privado del tipo de arma del personaje
        /// </summary>
        private ETipoArma tipoArma;
        /// <summary>
        /// Atributo privado de la clase del personaje
        /// </summary>
        private EClase clase;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece el atributo nombre del personaje
        /// </summary>
        public string NombrePersonaje
        {
            get
            {
                return this.nombrePersonaje;
            }
            set
            {
                this.nombrePersonaje = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo vida del personaje
        /// </summary>
        public int VidaPersonaje
        {
            get
            {
                return this.vidaPersonaje;
            }
            set
            {
                if (value < 0)
                {
                    throw new VidaInvalidaException("La vida del personaje no puede ser negativa");
                }   
                this.vidaPersonaje = value;               
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo fuerza del personaje
        /// </summary>
        public int Fuerza
        {
            get
            {
                return this.fuerza;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica fuerza fuera de rango (3-20)");
                }
                this.fuerza = value;                
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo destreza del personaje
        /// </summary>
        public int Destreza
        {
            get
            {
                return this.destreza;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica destreza fuera de rango (3-20)");
                }
                this.destreza = value;               
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo constitucion del personaje
        /// </summary>
        public int Constitucion
        {
            get
            {
                return this.constitucion;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica constitucion fuera de rango (3-20)");
                }               
                this.constitucion = value; 
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo inteligencia del personaje
        /// </summary>
        public int Inteligencia
        {
            get
            {
                return this.inteligencia;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica inteligencia fuera de rango (3-20)");
                }

                this.inteligencia = value;  
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo sabiduria del personaje
        /// </summary>
        public int Sabiduria
        {
            get
            {
                return this.sabiduria;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica sabiduria fuera de rango (3-20)");
                }
                this.sabiduria = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo carisma del personaje
        /// </summary>
        public int Carisma
        {
            get
            {
                return this.carisma;
            }
            set
            {
                if (value < 3 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("Caracteristica carisma fuera de rango (3-20)");
                }
                this.carisma = value; 
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo nivel del personaje
        /// </summary>
        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            set
            {
                if(value < 0 || value > 20)
                {
                    throw new CaracteristicaInvalidaException("El nivel no puede ser negativo y el nivel maximo es 20");
                }  
                this.nivel = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo tipo de arma del personaje
        /// </summary>
        public ETipoArma TipoArma
        {
            get
            {
                return this.tipoArma;
            }
            set
            {
                this.tipoArma = value;
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el atributo clase del personaje
        /// </summary>
        public EClase Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros inicializa todos los atributos del personaje
        /// </summary>
        public Personaje()
        {
            this.NombrePersonaje = string.Empty;
            this.VidaPersonaje = 0;
            this.Fuerza = 3;
            this.Destreza = 3;
            this.Constitucion = 3;
            this.Inteligencia = 3;
            this.Sabiduria = 3;
            this.Carisma = 3;
            this.Nivel = 3;
        }
        /// <summary>
        /// Constructor que solo toma el nombre del personaje 
        /// </summary>
        /// <param name="nombrePersonaje">El nombre del personaje</param>
        public Personaje(string nombrePersonaje)
            :this()
        {
            this.nombrePersonaje = nombrePersonaje;
        }
        /// <summary>
        /// Constructor que toma todos los atributos del personaje utilizando el constructor de la base que toma todos los parametros 
        /// Un mago posee un baston por defecto
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
        /// <param name="tipoArma">El tipo de arma del personaje</param>
        public Personaje(string nombrePersonaje,int vidaPersonaje,
            int fuerza,int destreza,int constitucion,int inteligencia,int sabiduria,int carisma,int nivel,ETipoArma tipoArma)
            :this(nombrePersonaje)
        {
            this.VidaPersonaje = vidaPersonaje;
            this.Fuerza = fuerza;
            this.Destreza = destreza;
            this.Constitucion = constitucion;
            this.Inteligencia = inteligencia;
            this.Sabiduria = sabiduria;
            this.Carisma = carisma;
            this.Nivel = nivel;
            this.tipoArma = tipoArma;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene el valor de las caracteristicas del personaje utilizando la logica del sistema de dungeons and dragons
        /// La caracteristica -10 y al total se le divide 2 redondeando hacia arriba
        /// </summary>
        /// <param name="carateristica">La caracteristica a obtener</param>
        /// <returns>El valor real de la caracteristica</returns>
        private int GetCaracteristicas(int carateristica)
        {   
            int resultado = (carateristica - 10) / 2;  
            return resultado;
        }
        /// <summary>
        /// Obtiene la vida total del personaje que es su vida mas el valor real de la constitucion
        /// </summary>
        /// <param name="vida">La vida del personaje</param>
        /// <param name="constitucion">La constitucion del personaje</param>
        /// <returns>La vida del personaje total</returns>
        private int GetVida(int vida, int constitucion)
        {
            if(vida < 0)
            {
                throw new VidaInvalidaException("La vida no puede ser negativa");
            }
            this.vidaPersonaje = vida + GetCaracteristicas(constitucion);
            return this.vidaPersonaje;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos personajes son iguales cuando sus nombres son iguales
        /// </summary>
        /// <param name="p1">primer personaje</param>
        /// <param name="p2">segundo personaje</param>
        /// <returns>true si los personajes son iguales false si no</returns>
        public static bool operator == (Personaje p1, Personaje p2)
        {
            return p1.nombrePersonaje == p2.nombrePersonaje;
        }
        /// <summary>
        /// Dos personajes son distintos si sus nombres son distintos
        /// </summary>
        /// <param name="p1">primer personaje</param>
        /// <param name="p2">segundo personaje</param>
        /// <returns>true si los personajes son distintos false si no</returns>
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1==p2);
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo to string de personaje
        /// </summary>
        /// <returns>Todos los datos del personaje con su vida y caracteristicas reales a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Personaje: {NombrePersonaje}");
            sb.AppendLine($"Clase: {Clase}");
            sb.AppendLine($"Vida del personaje: {GetVida(this.VidaPersonaje, this.Constitucion)}");
            sb.AppendLine($"FUE: {GetCaracteristicas(this.Fuerza)}");
            sb.AppendLine($"DES: {GetCaracteristicas(this.Destreza)}");
            sb.AppendLine($"CONS: {GetCaracteristicas(this.Constitucion)}");
            sb.AppendLine($"INT: {GetCaracteristicas(this.Inteligencia)}");
            sb.AppendLine($"SAB: {GetCaracteristicas(this.Sabiduria)}");
            sb.AppendLine($"CAR: {GetCaracteristicas(this.Carisma)}");
            sb.AppendLine($"Tipo de arma: {this.tipoArma}");
            return sb.ToString();
        }
        #endregion
    }
}
