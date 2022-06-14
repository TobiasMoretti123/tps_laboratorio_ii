using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    [XmlInclude(typeof(Fisica))]
    [XmlInclude(typeof(Quimica))]
    [XmlInclude(typeof(Termica))]
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private string cuit;
        private Cilindro cilindro;

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }

        public int IdCliente
        {
            get => this.idCliente;
            set => this.idCliente = value;
        }
        public string Cuit
        {
            get => this.cuit;
            set => this.cuit = value;
        }

        public Cilindro Cilindro
        {
            get => this.cilindro;
            set => cilindro = value;
        }

        public Cliente()
        {

        }

        public Cliente(string nombre, string cuit)
        {
            this.nombre = nombre;
            this.cuit = cuit;
        }

        public Cliente(int id, string nombre, string cuit)
           : this(nombre, cuit)
        {
            this.idCliente = id;
        }

        public Cliente(string nombre, string cuit, Cilindro cilindro)
            : this(nombre, cuit)
        {
            this.Cilindro = cilindro;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Empresa: {this.nombre} ");
            sb.AppendLine($"Cuit: {this.cuit} ");
            return sb.ToString();
        }

        public static bool operator ==(Cliente clienteUno, Cliente clienteDos)
        {
            bool retorno = false;
            if (clienteUno.nombre == clienteDos.nombre)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Cliente clienteUno, Cliente clienteDos)
        {
            return !(clienteUno == clienteDos);
        }
    }
}
