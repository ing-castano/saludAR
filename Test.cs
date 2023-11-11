using System;

namespace SaludAr
{
    internal class Test
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                opcion = CargarMenu();

                switch (opcion)
                {
                    case 1:
                        // A realizar
                        Console.Write("¿Qué tipo de servicio desea agregar? (Internacion/Laboratorio/Medicamento):");
                        string nombreServicio = Console.ReadLine();
                        AgregarServicio(nombreServicio);
                        Console.WriteLine("su opcion es" + opcion + "\n");
                        break;
                    case 2:
                        //A realizar
                        Console.WriteLine("su opcion es" + opcion + "\n");
                        break;
                    case 3:
                        // A realizar
                        Console.WriteLine("su opcion es" + opcion + "\n");
                        break;
                    default:
                        Console.WriteLine("Esa opción no existe. Ingrese nuevamente\n");
                        break;
                }
            } while (opcion != 3);




            int CargarMenu()
            {
                Console.WriteLine("Bienvenido al Sistema de Facturación de la Clínica Médica");
                Console.WriteLine("1. Agregar nuevo servicio");
                Console.WriteLine("2. Mostrar detalles de los servicios");
                Console.WriteLine("3. Salir");
                Console.Write("Ingrese su opción: ");

                int opcion = int.Parse(Console.ReadLine());

                return opcion;
            }

            void AgregarServicio(string nombreServicio)
            {
                Console.WriteLine("A realizar");
                // if segun nombre de servicio
                // ServicioVentas nuevoServicio = new ServicioVentas(nombreServicio);
                // ServicioInternacion nuevoServicio = new ServicioInternacion(nombreServicio);
                // ServicioLaboratorio nuevoServicio = new ServicioLaboratorio(nombreServicio);
            }


        }

    }
}
