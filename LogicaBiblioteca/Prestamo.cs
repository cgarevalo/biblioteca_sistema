using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBiblioteca
{
    public class Prestamo
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Libros prestado: {Libro}\nUsuario: {Usuario}\nFecha del préstamo: {FechaPrestamo}");
        }
    }
}
