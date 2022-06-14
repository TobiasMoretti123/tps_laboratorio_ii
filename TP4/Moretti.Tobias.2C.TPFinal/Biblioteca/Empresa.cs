using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Biblioteca
{
    public class Empresa
    {
        private string nombreEmpresa;
        private List<Cliente> clientes;

        public string NombreEmpresa
        {
            get => this.nombreEmpresa;
            set => this.nombreEmpresa = value;
        }

        public List<Cliente> Clientes
        {
            get => this.clientes;
            set => this.clientes = value;
        }

        private Empresa()
        {
            this.clientes = new List<Cliente>();
        }

        public Empresa(string nombreEmpresa)
            : this()
        {
            this.nombreEmpresa = nombreEmpresa;
        }

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

        public static Empresa operator -(Empresa em, Cliente cl)
        {
            if (em == cl)
            {
                em.clientes.Remove(cl);
            }
            return em;
        }

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

        public static bool operator !=(Empresa em, Cliente cl)
        {
            return !(em == cl);
        }
    }
}
