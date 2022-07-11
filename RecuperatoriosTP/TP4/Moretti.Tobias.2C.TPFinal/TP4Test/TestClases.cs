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
            Cilindro cilindrofisico = new Cilindro(120,Cilindro.ETipoResistencia.Fisica);
            double actual = cilindrofisico.Precio;
            double expected = 26000;

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
        public void MetodoExtendidoValidarNombre_RetornaElStringVacioSiElStringContieneNumeros()
        {
            string nombre = "12345678911";

            string actual = nombre.ValidarNombre();

            string expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }
    }
}
