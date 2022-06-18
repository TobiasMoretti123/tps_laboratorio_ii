using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    /// <summary>
    /// Clase publica cliente
    /// </summary>
    [XmlInclude(typeof(Fisica))]
    [XmlInclude(typeof(Quimica))]
    [XmlInclude(typeof(Termica))] 
    public class Cliente
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del id del cliente
        /// </summary>
        private int idCliente;
        /// <summary>
        /// Atributo privado del nombre del cliente
        /// </summary>
        private string nombre;
        /// <summary>
        /// Atributo privado del cuit del cliente
        /// </summary>
        private string cuit;
        /// <summary>
        /// Atributo privado del cilindro del cliente
        /// </summary>
        private Cilindro cilindro;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que establece y obtiene el nombre del cliente
        /// </summary>
        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el id del cliente
        /// </summary>
        public int IdCliente
        {
            get => this.idCliente;
            set => this.idCliente = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el cuit del cliente
        /// </summary>
        public string Cuit
        {
            get => this.cuit;
            set => this.cuit = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el cilindro del cliente
        /// </summary>
        public Cilindro Cilindro
        {
            get => this.cilindro;
            set => cilindro = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros de cliente
        /// </summary>
        public Cliente()
        {

        }
        /// <summary>
        /// Constructor parametrizado que establece el nombre y el cuit
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cuit"></param>
        public Cliente(string nombre, string cuit)
        {
            this.nombre = nombre;
            this.cuit = cuit;
        }
        /// <summary>
        /// Contructor parametrizado que establece el nombre, el cuit y el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="cuit"></param>
        public Cliente (int id)
        {
            this.idCliente = id;
        }
        public Cliente(int id, string nombre, string cuit)
           : this(nombre, cuit)
        {
            this.idCliente = id;
        }
        /// <summary>
        /// Constructor parametrizado que establece el nombre, el cuit y el cilindro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cuit"></param>
        /// <param name="cilindro"></param>
        public Cliente(string nombre, string cuit, Cilindro cilindro)
            : this(nombre, cuit)
        {
            this.Cilindro = cilindro;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de cliente crea un stringbuilder con los datos del cliente
        /// </summary>
        /// <returns>El stringbuilder a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Empresa: {this.nombre} ");
            sb.AppendLine($"Cuit: {this.cuit} ");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos clientes seran iguales cuando sus nombres sean iguales
        /// </summary>
        /// <param name="clienteUno"></param>
        /// <param name="clienteDos"></param>
        /// <returns></returns>
        public static bool operator ==(Cliente clienteUno, Cliente clienteDos)
        {
            bool retorno = false;
            if (clienteUno.nombre == clienteDos.nombre)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Dos clientes seran distintos cuando sus nombres sean distintos
        /// </summary>
        /// <param name="clienteUno"></param>
        /// <param name="clienteDos"></param>
        /// <returns></returns>
        public static bool operator !=(Cliente clienteUno, Cliente clienteDos)
        {
            return !(clienteUno == clienteDos);
        }
        #endregion
    }
}
