using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Termica : Cilindro
    {
        public override double Precio
        {
            get
            {
                return this.tamanio.CacularPrecio(Cilindro.ETipoResistencia.Termica);
            }
            set
            {
                this.Precio = value;
            }
        }

        public Termica()
        {

        }

        public Termica(int tamanio)
            : base(tamanio)
        {

        }

        public Termica(int tamanio, Cilindro.ETipoResistencia tipoResistencia)
            : base(tamanio, tipoResistencia)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
