using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

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
            Cliente cl1 = new Cliente("juan", "2012131415", new Fisica(100));
            Cliente cl2 = new Cliente("juan", "2012131415", new Fisica(100));
            Cliente cl3 = new Cliente("juan", "2012131415", new Fisica(100));
            empresa += cl1;
            empresa += cl2;
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
        public void MetodoExtendido_RetornaTrueSiElCuitTiene11Digitos()
        {
            string cuit = "12345678911";

            bool actual = cuit.CacularCuit();

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
