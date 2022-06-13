using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Fisica : Cilindro
    {
        public override double Precio  
        {
            get
            {
                return this.tamanio.CacularPrecio(Cilindro.ETipoResistencia.Fisica);
            }
            set
            {
                this.Precio = value;
            }
        }

        public Fisica()
        {

        }

        public Fisica(int tamanio)
            :base(tamanio)
        {

        }

        public Fisica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
