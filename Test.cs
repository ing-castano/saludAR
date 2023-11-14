using System;
using System.Collections.Generic;

namespace SaludAr
{
    internal class Test
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            List<Servicios> servicios = new List<Servicios>();

            do
            {
                opcion = CargarMenu();

                switch (opcion)
                {
                    case 1:
                        // A realizar
                        Console.Write("¿Qué tipo de servicio desea agregar? (Internacion/Laboratorio/Medicamento):");
                        string tipoServ = Console.ReadLine();
                        TipoServicioEnum? tipoServicio = ValidarServicio(tipoServ);
                        AgregarServicio(tipoServicio);
                        break;
                    case 2:
                        Console.WriteLine("\nDetalle de Servicios:");
                        MostrarServicios(servicios);
                        break;
                    case 3:
                        // A realizar
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

                string opcion = Console.ReadLine();
                int op = 0;

                int.TryParse(opcion, out op);
                
                return op;
                    
            }

            TipoServicioEnum? ValidarServicio(string tipoServ)
            {
                TipoServicioEnum? tipoServicio = null;

                if (tipoServ.ToLower().Equals("internacion"))
                    tipoServicio = TipoServicioEnum.INTERNACION;

                else if (tipoServ.ToLower().Equals("laboratorio"))
                    tipoServicio = TipoServicioEnum.LABORATORIO;

                else if (tipoServ.ToLower().Equals("medicamento"))
                    tipoServicio = TipoServicioEnum.VENTA;

                else
                    throw new ApplicationException("Servicio Invalido");
                    
                return tipoServicio;
            }


            void AgregarServicio(TipoServicioEnum? tipoServicio)
            {
                switch (tipoServicio)
                {
                    case TipoServicioEnum.LABORATORIO:
                        // Servicios s = new ServicioInternacion(TODO);
                        break;

                    case TipoServicioEnum.INTERNACION:
                        {
                            Console.Write("Ingrese el nombre de la especialidad: ");
                            string especialidad = Console.ReadLine();
                            Console.Write("Ingrese cantidad de días de internación: ");
                            int diasInternado = int.Parse(Console.ReadLine());
                            servicios.Add(new ServicioInternacion(TipoServicioEnum.INTERNACION, especialidad, diasInternado));
                            Console.WriteLine("Servicio Agregado correctamente\n");
                            break;
                        }

                    case TipoServicioEnum.VENTA:
                        {
                            Console.Write("Ingrese el nombre del medicamento: ");
                            string nombreMedicamento = Console.ReadLine();
                            Console.Write("Ingrese un porcentaje de ganancia (sin signo %): ");
                            string aux = Console.ReadLine();
                            int.TryParse(aux, out int porcentajeGanancia);
                            Console.Write("Ingrese el precio de lista (sin signo $ y sin puntos): ");
                            aux = Console.ReadLine();
                            float.TryParse(aux, out float precioLista);
                            Console.Write("Ingrese cantidad vendida: ");
                            aux = Console.ReadLine();
                            int.TryParse(aux, out int cantidadVendida);
                            servicios.Add(new ServicioVenta(TipoServicioEnum.VENTA, nombreMedicamento, precioLista, porcentajeGanancia, cantidadVendida));
                            Console.WriteLine("Servicio Agregado correctamente\n");
                            break;
                        }
                    default:
                        Console.WriteLine("Ese servicios no existe. Ingrese nuevamente\n");
                        break;
                }
            }

            void MostrarServicios(List<Servicios> servicios)
            {
                foreach (Servicios servicio in servicios)
                {
                    Console.WriteLine("\n" + servicio);
                    float precioFinal = servicio.calcularPrecio();
                    string resultado = String.Format("{0:$#,##0.00;($#,##0.00);Zero}", precioFinal); 
                    Console.WriteLine("Precio final: " + resultado + "\n" );
                }
            }
        }

    }
}
