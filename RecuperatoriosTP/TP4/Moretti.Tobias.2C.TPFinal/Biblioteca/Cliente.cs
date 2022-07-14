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
        /// Atributo privado de la razon social del cliente
        /// </summary>
        private string razonSocial;
        /// <summary>
        /// Atributo privado de la direccion del cliente
        /// </summary>
        private string direccion;
        /// <summary>
        /// Atributo privado de la nacionalidad del cliente
        /// </summary>
        private ENacionalidad nacionalidad;
        /// <summary>
        /// Atributo privado del cuit del cliente
        /// </summary>
        private string cuit;
        /// <summary>
        /// Atributo privado del contacto del cliente
        /// </summary>
        private string contacto;
        /// <summary>
        /// Atributo privado del telefono del cliente
        /// </summary>
        private string telefono;
        /// <summary>
        /// Atributo privado del mail del cliente
        /// </summary>
        private string mail;
        /// <summary>
        /// Atributo privado del mail de la factura electronica del cliente
        /// </summary>
        private string mailFacturaElectronica;
        /// <summary>
        /// Atributo privado de los cilindros del cliente
        /// </summary>
        private List<Cilindro> cilindros;    
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado con las distintas nacionalidades del cliente
        /// </summary>
        public enum ENacionalidad
        {
            Argentina,Chilena,Uruguaya,Brazilera,Otra
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que establece y obtiene el id del cliente
        /// </summary>
        public int IdCliente
        {
            get => this.idCliente;
            set => this.idCliente = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene la razon social del cliente
        /// </summary>
        public string RazonSocial
        {
            get => this.razonSocial;
            set => this.razonSocial = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene la direccion del cliente
        /// </summary>
        public string Direccion
        {
            get => this.direccion;
            set => this.direccion = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene la nacionalidad del cliente
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get => this.nacionalidad;
            set => this.nacionalidad = value;
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
        /// Propiedad que establece y obtiene el contacto del cliente
        /// </summary>
        public string Contacto
        {
            get => this.contacto;
            set => this.contacto = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el telefono del cliente
        /// </summary>
        public string Telefono
        {
            get => this.telefono;
            set => this.telefono = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el mail del cliente
        /// </summary>
        public string Mail
        {
            get => this.mail;
            set => this.mail = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene el mail de la factura electronica del cliente
        /// </summary>
        public string MailFacturaElectronico
        {
            get => this.mailFacturaElectronica;
            set => this.mailFacturaElectronica = value;
        }
        /// <summary>
        /// Propiedad que establece y obtiene la lista de cilindros del cliente
        /// </summary>
        public List<Cilindro> Cilindros
        {
            get => this.cilindros;
            set => cilindros = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros de cliente
        /// </summary>
        public Cliente()
        {
            this.cilindros = new List<Cilindro>();
        }
        /// <summary>
        /// Constructor parametrizado con todos los datos del cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="razonSocial"></param>
        /// <param name="direccion"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="cuit"></param>
        /// <param name="contacto"></param>
        /// <param name="telefono"></param>
        /// <param name="mail"></param>
        /// <param name="mailFacturaElectronica"></param>
        public Cliente(int idCliente,string razonSocial,string direccion,ENacionalidad nacionalidad,
            string cuit,string contacto,string telefono,string mail,
            string mailFacturaElectronica)
            :this(razonSocial,direccion,nacionalidad,cuit,contacto,telefono,mail,mailFacturaElectronica)
        {
            this.idCliente = idCliente;
            
        }
        /// <summary>
        /// Contructor parametrizado del cliente con todos los datos menos el id
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <param name="direccion"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="cuit"></param>
        /// <param name="contacto"></param>
        /// <param name="telefono"></param>
        /// <param name="mail"></param>
        /// <param name="mailFacturaElectronica"></param>
        public Cliente(string razonSocial, string direccion, ENacionalidad nacionalidad,
            string cuit, string contacto, string telefono, string mail,
            string mailFacturaElectronica)
            : this()
        {
            this.razonSocial = razonSocial;
            this.direccion = direccion;
            this.nacionalidad = nacionalidad;
            this.cuit = cuit;
            this.contacto = contacto;
            this.telefono = telefono;
            this.mail = mail;
            this.mailFacturaElectronica = mailFacturaElectronica;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de cliente crea un stringbuilder 
        /// con nombre,direccion,nacionalidad y cuit del cliente
        /// </summary>
        /// <returns>El stringbuilder a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Cliente: {this.razonSocial} ");
            sb.AppendLine($"Direccion: {this.direccion} ");
            sb.AppendLine($"Nacionalidad: {this.nacionalidad} ");
            sb.AppendLine($"Cuit: {this.cuit} ");
            return sb.ToString();
        }
        /// <summary>
        /// Crea un stringbuilder con todos los datos del cliente a modo de factura con sus cilindros
        /// </summary>
        /// <returns>El stringbuilder a modo de string</returns>
        public string MostrarCliente()
        {
            StringBuilder sb = new StringBuilder();
            int precioTotal = 0;
            sb.AppendLine(this.ToString());
            sb.AppendLine($"Contacto: {this.contacto} ");
            sb.AppendLine($"Telefono: {this.telefono} ");
            sb.AppendLine($"Mail: {this.mail} ");
            sb.AppendLine($"Mail Factura Electronica: {this.mailFacturaElectronica} ");
            sb.AppendLine($"Cilindros:");
            foreach (Cilindro cilindro in Cilindros)
            {
                sb.AppendLine(cilindro.ToString());
                precioTotal += cilindro.Precio;
            }
            sb.AppendLine($"Total factura = ${precioTotal}");
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
            return clienteUno.razonSocial == clienteDos.razonSocial;
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
        /// <summary>
        /// Operador + agrega un cilindro a la lista de cilindros del cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="cilindro"></param>
        /// <returns></returns>
        public static Cliente operator +(Cliente cliente, Cilindro cilindro)
        {
            if(cilindro is not null)
            {
                cliente.cilindros.Add(cilindro);
            }
            return cliente;
        }
        #endregion
    }
}
