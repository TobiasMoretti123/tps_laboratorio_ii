using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Biblioteca
{
    public class Eventos
    {
        #region Delegados
        /// <summary>
        /// Delegado encargado de ser el handler del evento guardar
        /// </summary>
        /// <param name="c"></param>
        public delegate void GuardarHandler(Cliente c);
        /// <summary>
        /// Delegado encargado de ser el handler del evento leer
        /// </summary>
        public delegate void LeerHandler();
        #endregion

        #region Eventos
        /// <summary>
        /// Evento guardar
        /// </summary>
        public event GuardarHandler OnGuardar;
        /// <summary>
        /// Evento leer
        /// </summary>
        public event LeerHandler OnLeer;
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que invoca al evento leer
        /// </summary>
        public void Leer()
        {
            if (OnLeer is not null)
            {
                OnLeer.Invoke();
            }
        }
        /// <summary>
        /// Metodo que invoca al evento guardar
        /// </summary>
        public void Guardar(Cliente c)
        {
            if (OnGuardar is not null)
            {
                OnGuardar.Invoke(c);
            }
        }
        #endregion
    }
}
