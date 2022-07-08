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
        /// <summary>
        /// Constructor parametrizado que establece el nombre de la empresa
        /// </summary>
        /// <param name="nombreEmpresa"></param>
        public Empresa(string nombreEmpresa)
            : this()
        {
            this.nombreEmpresa = nombreEmpresa;
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
