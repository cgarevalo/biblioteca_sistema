using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBiblioteca
{
    public class GestorBiblioteca
    {
        List<Libro> listaLibros = new List<Libro>();
        List<Usuario> listaUsuarios = new List<Usuario>();
        List<Prestamo> listaPrestamos = new List<Prestamo>();

        public void AgregarLibro(Libro libro)
        {
            listaLibros.Add(libro);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
        }

        public void PrestarLibro(int idLibro, int idUsuario)
        {
            // Buscar el libro por su ID
            Libro libro = listaLibros.Find(l => l.ID == idLibro);

            // Verificar si el libro existe y no está prestado
            if (libro != null && !libro.Prestado)
            {
                // Marca al libro como prestado
                libro.Prestado = true;
                
                // Busca al usuario por su ID
                Usuario usuario = listaUsuarios.Find(u => u.ID == idUsuario);

                // Verificar si el usuario existe
                if (usuario != null)
                {
                    // Agregar el libro prestado al usuario
                    usuario.LibrosPrestados.Add(libro);

                    // Crea un objeto Prestamo y lo guarda
                    Prestamo prestamo = new Prestamo { Libro = libro, Usuario = usuario, FechaPrestamo = DateTime.Now};

                    listaPrestamos.Add(prestamo);

                    Console.WriteLine("Libro prestado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado o ya ha sido prestado.");
            }


        }

        public void DevolverLibro(int idLibro, int idUsuario)
        {
            // Buscar el libro por su ID
            Libro libro = listaLibros.Find(l => l.ID == idLibro);

            // Verificar si el libro existe y está prestado
            if (libro != null && libro.Prestado)
            {
                // Marcar el libro como no prestado
                libro.Prestado = false;

                // Buscar el préstamo asociado al libro y usuario
                Prestamo prestamo = listaPrestamos.Find(p => p.Libro.ID == idLibro && p.Usuario.ID == idUsuario);

                // Verificar si se encontró un préstamo
                if (prestamo != null)
                {
                    // Eliminar el préstamo de la lista
                    listaPrestamos.Remove(prestamo);

                    // Buscar al usuario por su ID
                    Usuario usuario = listaUsuarios.Find(u => u.ID == idUsuario);

                    // Verificar si el usuario existe
                    if (usuario != null)
                    {
                        // Eliminar el libro de la lista de libros prestados del usuario
                        usuario.LibrosPrestados.Remove(libro);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }

                    Console.WriteLine("Libro devuelto de manera exitosa");
                }
                else
                {
                    Console.WriteLine("No se encontró un préstamo para el libro y usuario especificados.");
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado o no está prestado.");
            }
        }

        public void MostrarLibros()
        {
            string estadoLibro;
            foreach (Libro i in listaLibros)
            {
                if (i.Prestado)
                {
                    estadoLibro = "Prestado";
                }
                else
                {
                    estadoLibro = "No prestado";
                }
                Console.WriteLine($"ID: {i.ID}\nTítulo: {i.Titulo}\nEstado del libro: {estadoLibro}");
                Console.WriteLine("-------------------------------------");
            }
        }

        public void MostrarUsuarios()
        {
            
            foreach (Usuario usuario in listaUsuarios)
            {
                int cantidadLibrosPrestados = usuario.LibrosPrestados.Count();

                Console.WriteLine($"ID de usuario: {usuario.ID}\nNombre: {usuario.Nombre}\nLibros prestados: {cantidadLibrosPrestados}");
                Console.WriteLine("-------------------------------------");
            }
        }

        public void MostrarPrestamos()
        {
            if (listaPrestamos.Count > 0)
            {
                foreach (Prestamo prestamo in listaPrestamos)
                {
                    Console.WriteLine("Información del préstamo:");
                    Console.WriteLine($"ID del libro: {prestamo.Libro.ID}\nLibro: {prestamo.Libro.Titulo}\nUsuario ID: {prestamo.Usuario.ID}\nNombre del usuario: {prestamo.Usuario.Nombre}\nFecha del préstamo: {prestamo.FechaPrestamo}");
                    Console.WriteLine("-------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay ningun préstamo registrado.");
            }
        }

        public void MostrarInfoLibro(int id)
        {
            Libro l1 = listaLibros.Find(l => l.ID == id);

            if (l1 != null)
            {
                string respuesta;
                if (l1.Prestado)
                {
                    respuesta = "Sí";
                }
                else
                {
                    respuesta = "No";
                }

                Console.WriteLine("Estado del libro");
                Console.WriteLine($"ID: {l1.ID}\nTítulo: {l1.Titulo}\nAutor: {l1.Autor}\nPrestado: {respuesta}");
            }
        }
    }
}
