using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBiblioteca
{
    public class Usuario
    {
        private int conIDusuario = 1;

        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Libro> LibrosPrestados { get; private set; }

        public Usuario()
        {
            LibrosPrestados = new List<Libro>();
        }

        public void GuardarLibro(Libro libro)
        {
            LibrosPrestados.Add(libro);  // Agrega el libro a la lista de libros prestados
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID usuario: {ID}\nNombre: {Nombre}\nLibros prestados: {LibrosPrestados.Count}");
        }

        public int AsignarID()
        {
            return conIDusuario++;
        }
    }
}
