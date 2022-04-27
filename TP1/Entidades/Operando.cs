using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero):this()
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Convierte El numero binario ingresado por el usuario a decimal
        /// </summary>
        /// <param name="binario">El numero binario ingresado</param>
        /// <returns>Si es un numero valido retornara el numero decimal , si no "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int cantidadCaracteres;

            if (EsBinario(binario))
            {
                cantidadCaracteres = binario.Length;
                foreach (char d in binario)
                {
                    cantidadCaracteres--;
                    if (d == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }

                return resultado.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }
        /// <summary>
        /// Convierte un numero decimal ingresado por el usuario a binario
        /// </summary>
        /// <param name="numero">numero decimal</param>
        /// <returns>Si es un numero valido retornara el numero binario , si no "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = "";
            int division = (int)numero;
            int modulo;

            if (division > 0)
            {
                do
                {
                    modulo = division % 2;
                    division /= 2;
                    valorBinario = modulo.ToString() + valorBinario;
                } while (division > 0);
            }
            else
            {
                valorBinario = "Valor inválido";
            }

            return valorBinario;
        }
        /// <summary>
        /// Convierte un numero decimal ingresado por el usuario a binario
        /// </summary>
        /// <param name="numero">numero decimal</param>
        /// <returns>Si es un numero valido retornara el numero binario , si no "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(ValidarOperando(numero));
        }
        /// <summary>
        /// Verifica que el numero ingresado sea binario
        /// </summary>
        /// <param name="binario">El numero binario a verificar</param>
        /// <returns>True en caso de ser correcto, false en caso incorrecto</returns>
        private static bool EsBinario(string binario)
        {
            foreach (char d in binario)
            {
                if (d != '0' && d != '1')
                {
                    return false;
                }
            }

            return true;
        }

        private double ValidarOperando(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            return 0;
        }
        /// <summary>
        /// Resta dos objetos de tipo operando
        /// </summary>
        /// <param name="n1">El objeto con el primer valor</param>
        /// <param name="n2">El objeto con el segundo valor</param>
        /// <returns>El resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Suma dos objetos de tipo operando
        /// </summary>
        /// <param name="n1">El objeto con el primer valor</param>
        /// <param name="n2">El objeto con el segundo valor</param>
        /// <returns>El resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Divide dos objetos de tipo operando corroborando que el segundo objeto no sea 0
        /// </summary>
        /// <param name="n1">El objeto con el primer valor</param>
        /// <param name="n2">El objeto con el segundo valor</param>
        /// <returns>El resultado de la division en caso de ser valido si no, double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }
        /// <summary>
        /// Multiplica dos objetos de tipo operando
        /// </summary>
        /// <param name="n1">El objeto con el primer valor</param>
        /// <param name="n2">El objeto con el segundo valor</param>
        /// <returns>El resultado de la multiplicacion</returns>
        public static double operator * (Operando n1, Operando n2)
        {   
            return n1.numero * n2.numero;
        }
    }
}
