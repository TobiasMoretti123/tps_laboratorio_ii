using System;
using System.Text;
using Excepciones;

namespace Biblioteca
{
    public enum ETipoArma
    {
        Espada,Arco,Baston
    }
    public abstract class Personaje
    {
        #region Atributos
        private string nombrePersonaje;
        private int vidaPersonaje;
        private int fuerza;
        private int destreza;
        private int constitucion;
        private int inteligencia;
        private int sabiduria;
        private int carisma;
        private int nivel;
        private ETipoArma tipoArma;
        #endregion

        #region Propiedades
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
        #endregion

        #region Constructores
        public Personaje()
        {
            this.nombrePersonaje = string.Empty;
            this.VidaPersonaje = 0;
            this.Fuerza = 0;
            this.Destreza = 0;
            this.Constitucion = 0;
            this.Inteligencia = 0;
            this.Sabiduria = 0;
            this.Carisma = 0;
            this.Nivel = 0;
            this.tipoArma = 0;
        }
        public Personaje(string nombrePersonaje)
            :this()
        {
            this.nombrePersonaje = nombrePersonaje;
        }
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
        /// </summary>
        /// <param name="carateristica">La caracteristica a obtener</param>
        /// <returns>El valor real de la caracteristica</returns>
        private int GetCaracteristicas(int carateristica)
        {   
            int resultado = (carateristica - 10) / 2;  
            return resultado;
        }
        /// <summary>
        /// Obtiene la vida del personaje que es su vida mas el valor real de la constitucion
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
        public static bool operator == (Personaje p1, Personaje p2)
        {
            return p1.nombrePersonaje == p2.nombrePersonaje;
        }
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1==p2);
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Personaje: {NombrePersonaje}");
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
