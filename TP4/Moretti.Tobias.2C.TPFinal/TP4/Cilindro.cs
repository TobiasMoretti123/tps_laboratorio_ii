using System;
using System.Text;

namespace Biblioteca
{
    public abstract class Cilindro
    {
        protected int tamanio;
        protected ETipoResistencia tipoResistencia;

        public enum ETipoResistencia 
        {
            Fisica,Quimica,Termica
        }
        public int Tamanio
        {
            get => this.tamanio;
            set => this.tamanio = value;
        }

        public abstract double Precio
        {
            get;
            set;
        }

        public ETipoResistencia TipoResistencia
        {
            get => tipoResistencia;
            set => tipoResistencia = value;
        }
        public Cilindro()
        {

        }

        public Cilindro(int tamanio)
        {
            this.Tamanio = tamanio;
        }

        public Cilindro(int tamanio,ETipoResistencia tipoResistencia)
            :this(tamanio)
        {
            this.tipoResistencia = tipoResistencia;
        }   

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Resistencia: {this.tipoResistencia} ");
            sb.AppendLine($"Tamaño: {this.tamanio} ");
            sb.AppendLine($"Precio: {this.Precio} ");
            return sb.ToString();
        }
    }
}
