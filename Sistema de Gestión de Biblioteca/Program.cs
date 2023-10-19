using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LogicaBiblioteca;

namespace Sistema_de_Gestión_de_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
               Ejercicio: Sistema de Gestión de Biblioteca

               Crea un sistema de gestión de una biblioteca utilizando clases en C#. La biblioteca contiene libros, usuarios y préstamos. Cada libro tiene un título, un autor y un número de identificación único. Cada usuario tiene un nombre, un número de identificación único y una lista de libros prestados. El sistema debe permitir agregar libros y usuarios, prestar y devolver libros, mostrar la información de los libros, los usuarios y los préstamos. 

              1- Crea una clase Libro con los siguientes atributos:

                -Id (int): para almacenar el número de identificación único del libro.
                -Titulo (string): para almacenar el título del libro.
                -Autor (string): para almacenar el autor del libro.
                -Prestado (bool): para indicar si el libro está prestado o no.
                
              2- Implementa un método en la clase Libro llamado MostrarInformacion que muestre por consola la información del libro (id, título, autor, estado de préstamo).

              3-Crea una clase Usuario con los siguientes atributos:

                -Id (int): para almacenar el número de identificación único del usuario.
                -Nombre (string): para almacenar el nombre del usuario.
                -LibrosPrestados (Lista de libros): para almacenar los libros prestados por el usuario.

              4- Implementa un método en la clase Usuario llamado MostrarInformacion que muestre por consola la información del usuario (id, nombre, libros prestados).

              5- Crea una clase Prestamo con los siguientes atributos:

                -Libro (objeto Libro): para almacenar el libro prestado.
                -Usuario (objeto Usuario): para almacenar el usuario que realizó el préstamo.
                -FechaPrestamo (DateTime): para almacenar la fecha de préstamo.

              6- Implementa un método en la clase Prestamo llamado MostrarInformacion que muestre por consola la información del préstamo (libro prestado, usuario, fecha de préstamo).

              7- Crea una clase GestorBiblioteca que contendrá listas de libros, usuarios y préstamos, y tendrá los siguientes métodos:

                -AgregarLibro: para agregar un libro a la lista de libros.
                -AgregarUsuario: para agregar un usuario a la lista de usuarios.
                -PrestarLibro: para prestar un libro a un usuario.
                -DevolverLibro: para devolver un libro prestado.
                -MostrarLibros: para mostrar la información de todos los libros.
                -MostrarUsuarios: para mostrar la información de todos los usuarios.
                -MostrarPrestamos: para mostrar la información de todos los préstamos.

              8- En el programa principal, crea instancias de GestorBiblioteca y realiza las siguientes operaciones:

                -Agrega al menos tres libros y tres usuarios.
                -Realiza algunos préstamos y devoluciones.
                -Muestra la información actualizada de libros, usuarios y préstamos.
            */


            Libro l1 = new Libro();
            Usuario u1 = new Usuario();
            GestorBiblioteca gestor = new GestorBiblioteca();
            string titulo;
            string autor;
            string nombre;
            bool prestado;
            int opcion = -1;
            int iD, idUsuario;

            gestor.AgregarLibro(new Libro { ID = l1.AsignarID(),Titulo = "El dolor", Autor = "Petra Ral", Prestado = false });
            gestor.AgregarLibro(new Libro { ID = l1.AsignarID(), Titulo = "Tiempo al tiempo", Autor = "Petra Ral", Prestado = false });
            gestor.AgregarLibro(new Libro { ID = l1.AsignarID(), Titulo = "Ser programador", Autor = "Emilia", Prestado = false });

            gestor.AgregarUsuario(new Usuario { ID = u1.AsignarID(), Nombre = "Ana Leone" });
            gestor.AgregarUsuario(new Usuario { ID = u1.AsignarID(), Nombre = "Rebecca Cannigia" });
            gestor.AgregarUsuario(new Usuario { ID = u1.AsignarID(), Nombre = "Emilia Reteegi" });

            do
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese 1 para agregar un libro.");
                Console.WriteLine("Ingrese 2 para ver la lista de libros.");
                Console.WriteLine("Ingrese 3 para ver información del libro.");
                Console.WriteLine("Ingrese 4 para pedir prestado un libro.");
                Console.WriteLine("Ingrese 5 para devolver un libro.");
                Console.WriteLine("Ingrese 6 para ver la lista de préstamos.");
                Console.WriteLine("Ingrese 7 para registrarse.");
                Console.WriteLine("Ingrese 8 para mostrar a los usuarios.");
                Console.WriteLine("Ingrese 9 para limpiar la consola.");
                Console.WriteLine("Ingrese 0 para salir");
                Console.WriteLine();

                string contenedorOpcion = Console.ReadLine();

                try
                {
                    int.TryParse(contenedorOpcion, out opcion);
                }
                catch (Exception error)
                {
                    throw error;
                }

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el título del libro: ");
                            titulo = Console.ReadLine();
                            Console.Write("Ingrese el autor del libro: ");
                            autor = Console.ReadLine();
                            Console.Write("Ingrese el estado del libro, true si está prestado y false si no lo está: ");

                            string estadoLibroTexto = Console.ReadLine();

                            if (bool.TryParse(estadoLibroTexto, out prestado))
                            {
                                gestor.AgregarLibro(new Libro { ID = l1.AsignarID(), Titulo = titulo, Autor = autor, Prestado = prestado });
                            }
                            else
                            {
                                Console.WriteLine("El estado del libro ingresado no es válido. Use 'true' o 'false'.");
                            }
                            break;
                        case 2:
                            gestor.MostrarLibros();
                            break;
                        case 3:
                            Console.Write("Ingrese el ID del libro para ver información detallada: ");
                            iD = int.Parse(Console.ReadLine());

                            gestor.MostrarInfoLibro(iD);
                            break;
                        case 4:
                            Console.Write("Ingrese el ID del libro que quiere: ");
                            iD = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese su ID de usuario: ");
                            idUsuario = int.Parse(Console.ReadLine());
                            gestor.PrestarLibro(iD, idUsuario);
                            break;
                        case 5:
                            Console.Write("Ingrese el ID del libro que desea devolver: ");
                            iD = int.Parse(Console.ReadLine());
                            Console.Write("Ahora ingrese su ID de usuario: ");
                            idUsuario = int.Parse( Console.ReadLine());

                            gestor.DevolverLibro(iD, idUsuario);
                            break;
                        case 6:
                            gestor.MostrarPrestamos();
                            break;
                        case 7:
                            Console.Write("Ingrese su nombre: ");
                            nombre = Console.ReadLine();

                            gestor.AgregarUsuario(new Usuario {  ID = u1.AsignarID(), Nombre = nombre });
                            break;
                        case 8:
                            gestor.MostrarUsuarios();
                            break;
                        case 9:
                            Console.Clear();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Ingrese un valor válido");
                            break;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            } while (opcion != 0);
        }
    }
}
