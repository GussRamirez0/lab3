using System;
using System.Collections.Generic;

namespace Listadotareas
{
    class Program
    {
        static List<string> tareas = new List<string>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Administrador de Tareas del Día");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Eliminar tarea");
                Console.WriteLine("3. Mostrar tareas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarTarea();
                            break;
                        case 2:
                            EliminarTarea();
                            break;
                        case 3:
                            MostrarTareas();
                            break;
                        case 4:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                }

                Console.WriteLine();
            }
        }

        static void AgregarTarea()
        {
            Console.Write("Ingrese la nueva tarea: ");
            string nuevaTarea = Console.ReadLine();
            tareas.Add(nuevaTarea);
            Console.WriteLine("Tarea agregada correctamente.");
        }

        static void EliminarTarea()
        {
            if (tareas.Count > 0)
            {
                MostrarTareas();
                Console.Write("Ingrese el índice de la tarea que desea eliminar: ");
                int indice;
                if (int.TryParse(Console.ReadLine(), out indice) && indice >= 0 && indice < tareas.Count)
                {
                    tareas.RemoveAt(indice);
                    Console.WriteLine("Tarea eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Índice no válido. Por favor, ingrese un índice válido.");
                }
            }
            else
            {
                Console.WriteLine("No hay tareas para eliminar.");
            }
        }

        static void MostrarTareas()
        {
            Console.WriteLine("Lista de Tareas:");
            if (tareas.Count > 0)
            {
                for (int i = 0; i < tareas.Count; i++)
                {
                    Console.WriteLine($"{i}. {tareas[i]}");
                }
            }
            else
            {
                Console.WriteLine("No hay tareas en la lista.");
            }
        }
    }
}
