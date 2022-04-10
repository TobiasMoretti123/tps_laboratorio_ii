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
                numero = ValidarOperando(value);
            }
        }

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public static string DecimalABinario(double numero)
        {
            string binarioInvertido = " ";
            string binario = " ";
            string retorno = " ";
            int resto = (int)MathF.Abs((float)numero);

            if (resto >= 0)
            {
                if (resto == 0)
                {
                    binario = "0";
                }
                while (resto > 0)
                {
                    binarioInvertido += (resto % 2).ToString();
                    resto = resto / 2;
                }
                for (int i = binarioInvertido.Length - 1; i >= 0; i--)
                {
                    binario += binarioInvertido[i];
                }
                retorno = binario;
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        public static string BinarioADecimal(double numero)
        {
            string binario = " ";
            string binariInvertido = " ";
            string retorno = " ";
            int enteroObtenido = 0;
            int enteroAux = (int)MathF.Floor(MathF.Abs((float)numero));
            binario = enteroAux.ToString();
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    binariInvertido += binario[i];
                }
                for (int i = 0; i < binariInvertido.Length; i++)
                {
                    if (binariInvertido[i] == '1')
                    {
                        enteroObtenido += (int)MathF.Pow(2, i);
                    }
                }
                retorno = enteroObtenido.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }

        private static bool EsBinario(string binario)
        {
            bool esBinario = false;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1' || binario[i] == '0')
                {
                    esBinario = true;
                }
            }
            return esBinario;
        }

        private double ValidarOperando(string strNumero)
        {
            double numero = 0;
            if (double.TryParse(strNumero, out numero))
            {
                numero = Int32.Parse(strNumero);
            }
            return numero;
        }

        public static double operator - (Operando n1, Operando n2)
        {
            double resultado;
            resultado = n1.numero - n2.numero;
            return resultado;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            double resultado;
            resultado = n1.numero + n2.numero;
            return resultado;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
        public static double operator * (Operando n1, Operando n2)
        {
            double resultado;
            
            resultado = n1.numero * n2.numero;
            
            return resultado;

        }


    }
}
