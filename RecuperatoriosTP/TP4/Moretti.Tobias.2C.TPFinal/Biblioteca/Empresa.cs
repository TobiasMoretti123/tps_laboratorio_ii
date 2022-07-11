using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Biblioteca
{
    /// <summary>
    /// Clase publica empresa
    /// </summary>
    public class Empresa
    {
        #region Atributos
        /// <summary>
        /// Atributo privado del nombre de la empresa
        /// </summary>
        private string nombreEmpresa;
        /// <summary>
        /// Atributo privado de la direccion de la empresa
        /// </summary>
        private string direccionEmpresa;
        /// <summary>
        /// Atributo privado del pais de la empresa
        /// </summary>
        private string paisEmpresa;
        /// <summary>
        /// Atributo privado del cuit de la empresa
        /// </summary>
        private string cuitEmpresa;
        /// <summary>
        /// Atributo privado del contacto de la empresa
        /// </summary>
        private string contactoEmpresa;
        /// <summary>
        /// Atributo privado del telefono de la empresa
        /// </summary>
        private string telefonoEmpresa;
        /// <summary>
        /// Atributo privado del mail de la empresa
        /// </summary>
        private string mailEmpresa;
        /// <summary>
        /// Atributo privado del mail para consultas de la empresa
        /// </summary>
        private string mailConsultaEmpresa;
        /// <summary>
        /// Atributo privado de la lista de clientes de la empresa
        /// </summary>
        private List<Cliente> clientes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que obtiene y establece el nombre de la empresa
        /// </summary>
        public string NombreEmpresa
        {
            get => this.nombreEmpresa;
            set => this.nombreEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece la direccion de la empresa
        /// </summary>
        public string DireccionEmpresa
        {
            get => this.direccionEmpresa;
            set => this.direccionEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el pais de la empresa
        /// </summary>
        public string PaisEmpresa
        {
            get => this.paisEmpresa;
            set => this.paisEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el cuit de la empresa
        /// </summary>
        public string CuitEmpresa
        {
            get => this.cuitEmpresa;
            set => this.cuitEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el contacto de la empresa
        /// </summary>
        public string ContactoEmpresa
        {
            get => this.contactoEmpresa;
            set => this.contactoEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el telefono de la empresa
        /// </summary>
        public string TelefonoEmpresa
        {
            get => this.telefonoEmpresa;
            set => this.telefonoEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el mail de la empresa
        /// </summary>
        public string MailEmpresa
        {
            get => this.mailEmpresa;
            set => this.mailEmpresa = value;
        }
        /// <summary>
        /// Propiedad que obtiene y establece el mail de consulta de la empresa
        /// </summary>
        public string MailConsultaEmpresa
        {
            get => this.mailConsultaEmpresa;
            set => this.mailConsultaEmpresa = value;
        }

        /// <summary>
        /// Propiedad que obtiene y establece la lista de clientes de la empresa
        /// </summary>
        public List<Cliente> Clientes
        {
            get => this.clientes;
            set => this.clientes = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor privado sin parametros de empresa que inicializa la lista de clientes
        /// </summary>
        private Empresa()
        {
            this.clientes = new List<Cliente>();
        }
        public Empresa(string nombreEmpresa)
            : this()
        {
            this.nombreEmpresa = nombreEmpresa;
        }
        /// <summary>
        /// Constructor publico parametrizado de la empresa con todos sus datos sin el nombre
        /// </summary>
        /// <param name="direccionEmpresa"></param>
        /// <param name="paisEmpresa"></param>
        /// <param name="cuitEmpresa"></param>
        /// <param name="contactoEmpresa"></param>
        /// <param name="telefonoEmpresa"></param>
        /// <param name="mailEmpresa"></param>
        /// <param name="mailConsultaEmpresa"></param>
        public Empresa(string nombreEmpresa,string direccionEmpresa,string paisEmpresa,string cuitEmpresa,
            string contactoEmpresa,string telefonoEmpresa,string mailEmpresa,string mailConsultaEmpresa)
            : this(nombreEmpresa)
        {
            this.direccionEmpresa = direccionEmpresa;
            this.paisEmpresa = paisEmpresa;
            this.cuitEmpresa = cuitEmpresa;
            this.contactoEmpresa = contactoEmpresa;
            this.telefonoEmpresa = telefonoEmpresa;
            this.mailEmpresa = mailEmpresa;
            this.mailConsultaEmpresa = mailConsultaEmpresa;

        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo TuString de cliente crea un stringbuilder con los datos de la empresa
        /// </summary>
        /// <returns>El stringbuilder a modo de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Empresa: {this.nombreEmpresa} ");
            sb.AppendLine($"Direccion: {this.direccionEmpresa} ");
            sb.AppendLine($"Nacionalidad: {this.paisEmpresa} ");
            sb.AppendLine($"Cuit: {this.cuitEmpresa} ");
            sb.AppendLine($"Contacto: {this.contactoEmpresa} ");
            sb.AppendLine($"Telefono: {this.telefonoEmpresa}");
            sb.AppendLine($"Mail: {this.mailEmpresa} ");
            sb.AppendLine($"Mail De Consultas: {this.mailConsultaEmpresa} ");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador + agregara un cliente a la lista siempre y cuando el cliente no este en la misma
        /// </summary>
        /// <param name="em"></param>
        /// <param name="cl"></param>
        /// <returns>La empresa con el cliente agregado</returns>
        public static Empresa operator +(Empresa em, Cliente cl)
        {
            if (em == cl)
            {
                em -= cl;
            }
            else
            {
                em.clientes.Add(cl);
            }
            return em;
        }
        /// <summary>
        /// Operador - Elimina un cliente de la lista 
        /// </summary>
        /// <param name="em"></param>
        /// <param name="cl"></param>
        /// <returns>La empresa con el cliente eliminado</returns>
        public static Empresa operator -(Empresa em, Cliente cl)
        {
            if (em == cl)
            {
                em.clientes.Remove(cl);
            }
            return em;
        }
        /// <summary>
        /// Un cliente y una empresa son iguales si la empresa ya tiene dicho cliente
        /// </summary>
        /// <param name="em"></param>
        /// <param name="cl"></param>
        /// <returns></returns>
        public static bool operator ==(Empresa em, Cliente cl)
        {
            foreach (Cliente c in em.clientes)
            {
                if (c == cl)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Un cliente y una empresa son distintos si la empresa no tiene dicho cliente
        /// </summary>
        /// <param name="em"></param>
        /// <param name="cl"></param>
        /// <returns></returns>
        public static bool operator !=(Empresa em, Cliente cl)
        {
            return !(em == cl);
        }
        #endregion
    }
}
