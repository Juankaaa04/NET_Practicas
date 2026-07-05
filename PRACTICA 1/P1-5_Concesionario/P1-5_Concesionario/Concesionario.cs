using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_5_Concesionario
{
    internal class Concesionario
    {
        private Coche[] _coches;
        private int _limite;
        private int _contador;

        public Concesionario(int limite)
        {
            this._coches = new Coche[limite];
            _limite = limite;
            _contador = 0;
        }
        public void AgregarCoche(Coche coche)
        {
            if (coche != null && _contador < _limite)
            {
                _coches[_contador] = coche;
                _contador++;
            }
            else
            {
                Console.WriteLine("No se pueden agregar más coches, se ha alcanzado el límite.");
            }
        }
        public void MostrarCoches()
        {
            for (int i = 0; i < _contador; i++)
            {
                Console.WriteLine(_coches[i].ToString());
            }
        }
        public void VaciarConcesionario()
        {
            this._coches = new Coche[_limite];
            _contador = 0;
        }
        public void EliminarCoche(Coche coche)
        {
            if (coche != null && _contador != 0)
            {
                int posicion = -1;
                for (int i = 0; i < _contador; i++)
                {
                    if (_coches[i].Id == coche.Id)
                    {
                        posicion = i;
                    }
                }
                if (posicion != -1)
                {
                    _coches[posicion] = null;
                    for (int j = posicion; j < _contador; j++)
                    {
                        _coches[j] = _coches[j+1];
                    }
                    _contador--;
                    Console.WriteLine("Coche eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró un coche con el ID especificado.");
                }
            }
        }
    }
}
