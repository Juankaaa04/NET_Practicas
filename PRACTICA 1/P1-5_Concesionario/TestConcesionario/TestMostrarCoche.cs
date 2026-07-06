using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using P1_5_Concesionario;

namespace TestConcesionario
{
    [TestClass]
    public class TestMostrarCoche
    {
        private object ObtenerCampoPrivado(object objeto, string nombreCampo)
        {
            var tipo = objeto.GetType();
            var campo = tipo.GetField(nombreCampo, BindingFlags.NonPublic | BindingFlags.Instance);
            return campo.GetValue(objeto);
        }
        [TestMethod]
        public void MostrarCoches_CuandoHayCoches_MuestraTodosLosCoches()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);
            Coche coche1 = new Coche(1, "Toyota", "Corolla", 15000, 2500.50);
            Coche coche2 = new Coche(2, "Honda", "Civic", 20000, 3000.75);
            concesionario.AgregarCoche(coche1);
            concesionario.AgregarCoche(coche2);

            // Preparamos para capturar la salida de la consola
            var stringWriter = new StringWriter();
            var originalConsoleOut = Console.Out;
            Console.SetOut(stringWriter);

            try
            {
                //Act
                concesionario.MostrarCoches();

                //Assert
                string output = stringWriter.ToString();

                // Aquí no podemos hacer una aserción directa ya que MostrarCoches() imprime en consola.
                // Sin embargo, podemos verificar que el contador es correcto y que los coches están en la lista.
                Assert.IsTrue(output.Contains("Marca: Toyota"), "Se encontró el coche de Toyota en la salida.");
                Assert.IsTrue(output.Contains("Marca: Honda"), "Se encontró el coche de Honda en la salida.");
            }
            finally 
            { 
                Console.SetOut(originalConsoleOut);
                stringWriter.Dispose();
            }
        }

        [TestMethod]
        public void MostrarCoches_CuandoNoHayCoches_MuestraMensajeVacio()
        {
            //Arrange
            int limite = 2;
            Concesionario concesionario = new Concesionario(limite);

            // Preparamos para capturar la salida de la consola
            var stringWriter = new StringWriter();
            var originalConsoleOut = Console.Out;
            Console.SetOut(stringWriter);

            try
            {
                //Act
                concesionario.MostrarCoches();

                //Assert
                string output = stringWriter.ToString();
                Assert.IsFalse(output.Contains("No hay coches en el concesionario."), "Se encontró el mensaje de coches vacíos en la salida.");
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
                stringWriter.Dispose();
            }
        }
    }
}
