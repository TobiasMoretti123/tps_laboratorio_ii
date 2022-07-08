using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using Excepciones;

namespace TP4Test
{
    [TestClass]
    public class TestClases
    {
        [TestMethod]
        public void PropiedadPrecio_RetornaElPrecioSegunElTipoResistencia()
        {
            Fisica cilindrofisico = new Fisica(120);
            double actual = cilindrofisico.Precio;
            double expected = 26000;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperadorMasEmpresa_NoAgregaClienteRepetido()
        {
            Empresa empresa = new Empresa("Rotadyne");
            Cliente cl1 = new Cliente("juan", "2012131415","Uruguay 822",Cliente.ENacionalidad.Otra,"1541591556",new Fisica(100));
            Cliente cl2 = new Cliente("juan", "2012131415", "Uruguay 822", Cliente.ENacionalidad.Otra, "1541591556", new Fisica(100));
            Cliente cl3 = new Cliente("juan", "2012131415", "Uruguay 822", Cliente.ENacionalidad.Otra, "1541591556", new Fisica(100));
            empresa += cl1;
            empresa += cl2;
            empresa += cl3;
            int actual = empresa.Clientes.Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropiedadTipoResistencia_RetornaLaResistencia()
        {
            Fisica cilindrofisico = new Fisica(120);
            Cilindro.ETipoResistencia actual = cilindrofisico.TipoResistencia;
            Cilindro.ETipoResistencia expected = Cilindro.ETipoResistencia.Fisica;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(CuitInvalidoException))]
        public void MetodoExtendidoCalcularCuit_RetornaExepcionCuandoNoTiene11Digitos()
        {
            string cuit = "1234567891";

            bool actual = cuit.CacularCuit();

        }

        [TestMethod]
        public void ClientesIguales_RetornaTrueSiClientesSonIguales()
        {
            bool esperado = true;
            Cliente c2 = new Cliente("juan", "2012131415", "Uruguay 822", Cliente.ENacionalidad.Otra, "1541591556");
            Cliente c = new Cliente("juan", "2012131415", "Uruguay 822", Cliente.ENacionalidad.Otra, "1541591556");
            bool actual;

            actual = (c == c2);

            Assert.AreEqual(esperado, actual);

        }

        [TestMethod]
        public void MetodoExtendidoValidarNombre_RetornaElStringVacioSiElStringContieneNumeros()
        {
            string nombre = "12345678911";

            string actual = nombre.ValidarNombre();

            string expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MetodoExtendidoValidarTelefono_Retorna1EnCasoDeSerCelular()
        {
            string telefonoCelular = "1541591556";
            int expected = 1;
            int actual = telefonoCelular.ValidarTelefono();

            Assert.AreEqual(expected, actual);
        }
    }
}
