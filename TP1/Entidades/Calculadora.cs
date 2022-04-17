using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el caracter operador sea valido
        /// </summary>
        /// <param name="operador"> caracter a validar </param>
        /// <returns>De ser correcto devuleve true de ser incorrecto false</returns>
        private static bool ValidarOperador(char operador)
        {
            bool validar = false;
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                validar = true;
            }
            return validar;
        }
        /// <summary>
        /// Realiza una operacion matematica utilizando el operador ingresado
        /// </summary>
        /// <param name="num1">El primer numero a realizar la operacion</param>
        /// <param name="num2">El segundo numero a realizar la operacion</param>
        /// <param name="operador">El caracter matematico para la operacion</param>
        /// <returns>El resultado de la operacion o 0 en caso de caracter invalido</returns>
        public static double Operar(Operando num1,Operando num2,char operador)
        {
            double operacion = num1 + num2;
            if (ValidarOperador((char)operador))
            {
                switch (operador)
                {
                    case '+':
                        operacion = num1 + num2;
                        break;
                    case '-':
                        operacion = num1 - num2;
                        break;
                    case '/':
                        operacion = num1 / num2;
                        break;
                    case '*':
                        operacion = num1 * num2;
                        break;

                }
            }
            return operacion;
        }
    }
}
