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
    public class TestEliminarCoche
    {
        private object ObtenerCampoPrivado(object objeto, string nombreCampo)
        {
            var tipo = objeto.GetType();
            var campo = tipo.GetField(nombreCampo, BindingFlags.NonPublic | BindingFlags.Instance);
            return campo.GetValue(objeto);
        }
        [TestMethod]
        public void EliminarCoche_CuandoCocheExiste_EliminaCocheYDecrementaContador()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche1 = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);
            Coche coche2 = new Coche(2, "Honda", "Civic", 20000, 3000.75);
            concesionario.AgregarCoche(coche1);
            concesionario.AgregarCoche(coche2);
            
            //Act
            concesionario.EliminarCoche(coche1);
            
            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(1, contadorActual, "El contador se decrementó correctamente");
            Assert.AreEqual(coche2.Id, listaCoches[0].Id, "El coche eliminado no está en la lista y el otro coche se ha desplazado correctamente");
        }

        [TestMethod]
        public void EliminarCoche_CuandoCocheNoExiste_NoDecrementaContadorYNoEliminaCoche()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche1 = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);
            Coche coche2 = new Coche(2, "Honda", "Civic", 20000, 3000.75);
            concesionario.AgregarCoche(coche1);

            //Act
            concesionario.EliminarCoche(coche2);

            //Assert
            int contadorActual = (int)ObtenerCampoPrivado(concesionario, "_contador");
            Coche[] listaCoches = (Coche[])ObtenerCampoPrivado(concesionario, "_coches");
            Assert.AreEqual(1, contadorActual, "El contador no se decrementó incorrectamente");
            Assert.AreEqual(coche1.Id, listaCoches[0].Id, "El coche que no existe no fue eliminado y el otro coche permanece en la lista");
        }
    }
}
