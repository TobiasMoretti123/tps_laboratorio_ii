using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static bool ValidarOperador(char operador)
        {
            bool validar = false;
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                validar = true;
            }
            return validar;
        }

        public double Operar(Operando num1,Operando num2,char operador)
        {
            double operacion = 0;
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
