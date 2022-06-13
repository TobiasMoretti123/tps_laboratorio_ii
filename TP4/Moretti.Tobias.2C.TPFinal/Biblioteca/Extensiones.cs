using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Extensiones
    {
        public static bool CacularCuit(this string str)
        {
            if (str.Length == 11)
            {
                return true;
            }
            return false;
        }

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
