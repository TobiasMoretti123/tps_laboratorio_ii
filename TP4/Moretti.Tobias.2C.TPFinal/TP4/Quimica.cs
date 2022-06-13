using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Quimica : Cilindro
    {
        public override double Precio
        {
            get
            {
                return this.tamanio.CacularPrecio(Cilindro.ETipoResistencia.Quimica);
            }
            set
            {              
                this.Precio = value;
            }
        }

        public Quimica()
        {

        }

        public Quimica(int tamanio)
            : base(tamanio)
        {

        }

        public Quimica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
