using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using P1_5_Concesionario;

namespace TestConcesionario
{
    [TestClass]
    public class TestVaciarConcesionario
    {
        private object ObtenerCampoPrivado(object objeto, string nombreCampo)
        {
            var tipo = objeto.GetType();
            var campo = tipo.GetField(nombreCampo, BindingFlags.NonPublic | BindingFlags.Instance);
            return campo.GetValue(objeto);
        }
        [TestMethod]
        public void VaciarConcesionario_CuandoHayCoches_VaciaListaYReseteaContador()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche1 = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);
            Coche coche2 = new Coche(2, "Honda", "Civic", 20000, 3000.75);
            concesionario.AgregarCoche(coche1);
            concesionario.AgregarCoche(coche2);

            // Verificar que el concesionario tiene coches antes de vaciarlo
            int contadorAntes = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Assert.AreEqual(2, contadorAntes, "El concesionario debería tener 2 coches antes de vaciarlo");

            //Act
            concesionario.VaciarConcesionario();
            
            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(0, contadorActual, "El contador se reseteó correctamente");
            Assert.AreEqual(limite, listaCoches.Length, "La lista de coches tiene la longitud correcta después de vaciarla");
            Assert.IsNull(listaCoches[0], "El primer elemento del array debe ser nulo");
            Assert.IsNull(listaCoches[1], "El segundo elemento del array debe ser nulo");
        }

        [TestMethod]
        public void VaciarConcesionario_CuandoNoHayCoches_ReseteaContadorYMantieneListaVacia()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            
            // Verificar que el concesionario está vacío antes de vaciarlo
            int contadorAntes = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Assert.AreEqual(0, contadorAntes, "El concesionario debería estar vacío antes de vaciarlo");
            
            //Act
            concesionario.VaciarConcesionario();

            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(0, contadorActual, "El contador se reseteó correctamente");
            Assert.AreEqual(limite, listaCoches.Length, "La lista de coches tiene la longitud correcta después de vaciarla");
            Assert.IsNull(listaCoches[0], "El primer elemento del array debe ser nulo");
            Assert.IsNull(listaCoches[1], "El segundo elemento del array debe ser nulo");
        }
    }
}
