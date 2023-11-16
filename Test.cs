using System;
using System.Collections.Generic;
using System.Numerics;

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
                        Console.Write("¿Qué tipo de servicio desea agregar? (Internacion/Laboratorio/Medicamento):");
                        string tipoServ = Console.ReadLine();
                        TipoServicioEnum? tipoServicio = ValidarServicio(tipoServ);
                        while (tipoServicio == null)
                        {
                            Console.WriteLine("Error en el ingreso. Intente nuevamente...");
                            Console.Write("¿Qué tipo de servicio desea agregar? (Internacion/Laboratorio/Medicamento):");
                            tipoServ = Console.ReadLine();
                            tipoServicio = ValidarServicio(tipoServ);
                        }
                        AgregarServicio(tipoServicio);
                        break;
                    case 2:
                        Console.WriteLine("\nDetalle de Servicios:");
                        MostrarServicios(servicios);
                        break;
                    case 3:
                        montoTotalFacturado(servicios);
                        cantServiciosSimples(servicios);
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
                    
                return tipoServicio;
            }


            void AgregarServicio(TipoServicioEnum? tipoServicio)
            {
                switch (tipoServicio)
                {
                    case TipoServicioEnum.LABORATORIO:
                        {
                            Console.Write("Ingrese el nombre del servicio de Laboratorio: ");
                            string nombreServicio = Console.ReadLine();
                            Console.Write("Ingrese cantidad de días del servicio de Laboratorio: ");
                            int diasDeProcesamiento = int.Parse(Console.ReadLine());
                            string compl;
                            do
                            {
                                Console.Write("Ingrese nivel de complejidad (numero del 1 al 5): ");
                                compl = Console.ReadLine();
                            } while ( !(compl.Equals("1") || compl.Equals("2") || compl.Equals("3") || compl.Equals("4") || compl.Equals("5")) );
                            
                            ComplejidadEnum complejidad = validarComplejidad(compl);

                            servicios.Add(new ServicioLaboratorio(TipoServicioEnum.LABORATORIO, nombreServicio, diasDeProcesamiento, complejidad));
                            Console.WriteLine("Servicio Agregado correctamente\n");
                            
                            break;
                        }

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
            
            ComplejidadEnum validarComplejidad (string compl)
            {
                ComplejidadEnum complejidad;

                switch (compl)
                {
                    case "1":
                        {
                            complejidad = ComplejidadEnum.UNO;
                            break;
                        }
                    case "2":
                        {
                            complejidad = ComplejidadEnum.DOS;
                            break;
                        }
                    case "3":
                        {
                            complejidad = ComplejidadEnum.TRES;
                            break;
                        }
                    case "4":
                        {
                            complejidad = ComplejidadEnum.CUATRO;
                            break;
                        }
                    case "5":
                        {
                            complejidad = ComplejidadEnum.CINCO;
                            break;
                        }
                    default:
                        {
                            complejidad = ComplejidadEnum.UNKNOWN;
                            break;
                        }
                }
                return complejidad;

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

            void montoTotalFacturado(List<Servicios> servicios)
            {
                float montoTotalFacturado = 0F;

                foreach (Servicios servicio in servicios)
                {
                    float precioFinal = servicio.calcularPrecio();
                    montoTotalFacturado += precioFinal;
                }
                string resultado = String.Format("{0:$#,##0.00;($#,##0.00);Zero}", montoTotalFacturado);
                Console.WriteLine("\nMonto Total Facturado: " + resultado + "\n");
            }

            void cantServiciosSimples(List<Servicios> servicios)
            {
                int count = 0;
                int compl;

                foreach (Servicios servicio in servicios)
                {
                   
                    if ( servicio.GetType() == typeof(ServicioLaboratorio) )
                    {
                        compl = (int)(((ServicioLaboratorio)servicio).Complejidad);
                        if ( ((ServicioLaboratorio)servicio).Complejidad < ComplejidadEnum.TRES)
                            count++;
                    }

                   
                }
                Console.WriteLine("Cantidad de Servicios Simples: " + count + "\n");
            }
        }

    }
}
