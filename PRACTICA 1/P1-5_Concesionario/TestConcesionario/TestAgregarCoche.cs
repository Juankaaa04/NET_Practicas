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
    public class TestAgregarCoche
    {
        private object ObtenerCampoPrivado(object objeto, string nombreCampo)
        {
            var tipo = objeto.GetType();
            var campo = tipo.GetField(nombreCampo, BindingFlags.NonPublic | BindingFlags.Instance);
            return campo.GetValue(objeto);
        }
        [TestMethod]
        public void AgregarCoche_CuandoHayEspacio_IncrementaContadorYGuardaCoche()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);

            //Act
            concesionario.AgregarCoche(coche);

            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(1, contadorActual, "El contador se incrementó correctamente");
            Assert.IsNotNull(listaCoches[0], "La lista de coches no está vacía");
            Assert.AreEqual(coche.Id, listaCoches[0].Id, "El coche se guardó correctamente");
        }

        [TestMethod]
        public void AgregarCoche_CuandoNoHayEspacio_NoIncrementaContadorYNoGuardaCoche()
        {
            //Arrange
            int limite = 1;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche1 = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);
            Coche coche2 = new Coche(2, "Honda", "Civic", 20000, 3000.75);
            
            //Act
            concesionario.AgregarCoche(coche1);
            concesionario.AgregarCoche(coche2);
            
            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(1, contadorActual, "El contador se incrementó incorrectamente");
            Assert.IsNotNull(listaCoches[0], "La lista de coches está vacía");
            Assert.AreEqual(coche1.Id, listaCoches[0].Id, "El primer coche no se guardó correctamente");
        }
    }
}
