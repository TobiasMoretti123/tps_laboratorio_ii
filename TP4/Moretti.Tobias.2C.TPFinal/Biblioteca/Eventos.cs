using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Biblioteca
{
    public delegate void GuardarHandler(Cliente c);
    public delegate void LeerHandler();
    public class Eventos
    {
        Empresa empresa = new Empresa("Rotadyne");
        public event GuardarHandler OnGuardar;
        public event LeerHandler OnLeer;

        public void Guardar(Cliente c)
        {
            empresa += c;

            if (OnGuardar is not null)
            {
                OnGuardar.Invoke(c);
            }
        }

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
