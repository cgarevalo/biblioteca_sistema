using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBiblioteca
{
    public class Libro
    {
        private int conID = 1;

        public int ID { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Prestado { get; set; }

        public void MostrarInformacion(int id)
        {
            string respuesta;
            if (Prestado)
            {
                respuesta = "Sí";
            }
            else
            {
                respuesta = "No";
            }

            Console.WriteLine("Estado del libro");
            Console.WriteLine($"ID: {ID}\nTítulo: {Titulo}\nAutor: {Autor}\nPrestado: {respuesta}");
        }

        public int AsignarID()
        {
            return conID++;
        }
    }
}
