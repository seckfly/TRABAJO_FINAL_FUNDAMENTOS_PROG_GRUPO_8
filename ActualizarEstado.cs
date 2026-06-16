
using System.Collections.Generic;
using System.Text;
using System;

namespace SoftwareGestorDeVentas
{
    internal class ActualizarEstado
    {
        public static void ActualizacionDeEstado()
        {
            Console.Write("Ingrese el código de la venta a actualizar: ");
            string codigoBuscado = Console.ReadLine().ToUpper();

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (venta.Codigo.ToUpper() == codigoBuscado)
                {
                    Console.WriteLine("\n***** VENTA ENCONTRADA *****");
                    Console.WriteLine("Código: " + venta.Codigo);
                    Console.WriteLine("Cliente: " + venta.Cliente);
                    Console.WriteLine("Producto: " + venta.Producto);
                    Console.WriteLine("Estado actual: " + venta.Estado);

                    Console.WriteLine("\nEstados disponibles:");
                    Console.WriteLine("1. PENDIENTE");
                    Console.WriteLine("2. PAGADO");
                    Console.WriteLine("3. ENTREGADO");
                    Console.WriteLine("4. CANCELADO");

                    Console.Write("Seleccione el nuevo estado: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            venta.Estado = "PENDIENTE";
                            break;
                        case "2":
                            venta.Estado = "PAGADO";
                            break;
                        case "3":
                            venta.Estado = "ENTREGADO";
                            break;
                        case "4":
                            venta.Estado = "CANCELADO";
                            break;
                        default:
                            Console.WriteLine("Opción inválida. No se actualizó el estado.");
                            return;
                    }

                    Console.WriteLine("Estado actualizado correctamente a: " + venta.Estado);
                    return;
                }
            }

            Console.WriteLine("No se encontró una venta con ese código.");
        }
    }
}
