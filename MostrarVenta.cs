using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareGestorDeVentas
{
    internal class MostrarVenta
    {
        public static void VerVenta()
        {
            Console.Write("Ingrese el código de venta: ");
            string codigoBuscado = Console.ReadLine();

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (venta.Codigo == codigoBuscado)
                {
                    Console.WriteLine("\n***** VENTA *****");
                    Console.WriteLine("Código: " + venta.Codigo);
                    Console.WriteLine("Cliente: " + venta.Cliente);
                    Console.WriteLine("Producto: " + venta.Producto);
                    Console.WriteLine("Cantidad: " + venta.Cantidad);
                    Console.WriteLine("Precio Unitario: " + venta.Precio);
                    Console.WriteLine("Total: " + venta.Total);
                    return;
                }
            }

            Console.WriteLine("No se encontró una venta con ese código.");
        }
    }
}
