using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_5_Concesionario
{
    public class Coche
    {
        private int _id;
        private string _marca;
        private string _modelo;
        private int _km;
        private double _precio;

        public Coche(int id, string marca, string modelo, int km, double precio)
        {
            this._id = id;
            this._marca = marca;
            this._modelo = modelo;
            this._km = km;
            this._precio = precio;
        }

        public int Id { get => _id; set => _id = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Km { get => _km; set => _km = value; }
        public double Precio { get => _precio; set => _precio = value; }

        public override string ToString()
        {
            return "Marca: " + Marca + ", Modelo: " + Modelo + ", Precio: " + Precio;
        } 
    }
}
