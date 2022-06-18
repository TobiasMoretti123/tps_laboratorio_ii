using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Biblioteca
{
    /// <summary>
    /// Delegado handler que utilizara el evento guardar
    /// </summary>
    /// <param name="c"></param>
    public delegate void GuardarHandler(Cliente c);
    /// <summary>
    /// Delegado handler que utilizara el evento leer
    /// </summary>
    public delegate void LeerHandler();
    /// <summary>
    /// Clase publica eventos
    /// </summary>
    public class Eventos
    {
        /// <summary>
        /// Atributo privado empresa
        /// </summary>
        private Empresa empresa = new Empresa("Rotadyne");
        /// <summary>
        /// Evento publico de guardar
        /// </summary>
        public event GuardarHandler OnGuardar;
        /// <summary>
        /// Evento publico de leer
        /// </summary>
        public event LeerHandler OnLeer;

        /// <summary>
        /// El metodo donde el evento guardar sera invocado
        /// </summary>
        /// <param name="c"></param>
        public void Guardar(Cliente c)
        {
            empresa += c;

            if (OnGuardar is not null)
            {
                OnGuardar.Invoke(c);
            }
        }

        /// <summary>
        /// El metodo donde el evento leer sera invocado
        /// </summary>
        public void Leer()
        {
            empresa.ToString();

            if(OnLeer is not null)
            {
                OnLeer.Invoke();
            }       
        }
    }
}
