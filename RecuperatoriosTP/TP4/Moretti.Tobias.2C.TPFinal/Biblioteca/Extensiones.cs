using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Biblioteca
{
    /// <summary>
    /// Clase Encargada de todos los metodos de extension
    /// </summary>
    public static class Extensiones
    {
        /// <summary>
        /// Metodo de extension de string valida si el cuit es de 11 digitos sin espacios o guiones
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true si tiene 11 digitos false si no</returns>
        public static bool CacularCuit(this string str)
        {
            if (str.Length != 11)
            {
                throw new CuitInvalidoException("Cuit debe ser de 11 digitos sin espacios o guiones");
            }
            return true;
        }
        /// <summary>
        /// Metodo de extension de string valida que el nombre sea valido
        /// </summary>
        /// <param name="str"></param>
        /// <returns>El nombre si es valido o un string vacio si no lo es</returns>
        public static string ValidarNombre(this string str)
        {
            return string.IsNullOrEmpty(str) || str.Any(x => !Regex.IsMatch(str, @"\A[\p{L}\s]+\Z")) ? string.Empty : str;
        }
        /// <summary>
        /// Metodo de extension de int calcula el precio segun el tipo de resistencia de cada cilindro
        /// </summary>
        /// <param name="num"></param>
        /// <param name="tipoResistencia">El tipo de resistencia del cilindro</param>
        /// <returns>El precio segun el tipo de resistencia</returns>
        public static int CacularPrecio(this int num, Cilindro.ETipoResistencia tipoResistencia)
        {
            int retorno = 0;
            switch (tipoResistencia)
            {
                case Cilindro.ETipoResistencia.Fisica:
                    if (num == 100)
                    {
                        retorno = 20000;
                    }
                    else
                    {
                        retorno = 26000;
                    }
                    break;
                case Cilindro.ETipoResistencia.Quimica:
                    if (num == 100)
                    {
                        retorno = 25000;
                    }
                    else
                    {
                        retorno = 32000;
                    }
                    break;
                case Cilindro.ETipoResistencia.Termica:
                    if (num == 100)
                    {
                        retorno = 30000;
                    }
                    else
                    {
                        retorno = 40000;
                    }
                    break;
            }
            return retorno;
        }
    }
}
