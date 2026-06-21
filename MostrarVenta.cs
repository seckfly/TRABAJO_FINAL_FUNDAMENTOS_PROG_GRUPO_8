using System;

namespace SoftwareGestorDeVentas
{
    internal class MostrarVenta
    {
        public static void VerVenta()
        {
            Console.Write("Ingrese el código de venta: ");
            string codigoBuscado = Console.ReadLine();

            bool encontrado = false;
            double totalBoleta = 0;
            string cliente = "";

            Console.WriteLine("\n***** VENTA *****");

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (venta.Codigo == codigoBuscado)
                {
                    if (!encontrado)
                    {
                        cliente = venta.Cliente;
                        Console.WriteLine("Código: " + venta.Codigo);
                        Console.WriteLine("Cliente: " + cliente);
                        Console.WriteLine("--------------------------");
                    }

                    encontrado = true;

                    Console.WriteLine("Producto: " + venta.Producto);
                    Console.WriteLine("Cantidad: " + venta.Cantidad);
                    Console.WriteLine("Precio Unitario: " + venta.Precio);
                    Console.WriteLine("Subtotal: " + venta.Total);
                    Console.WriteLine("--------------------------");

                    totalBoleta += venta.Total;
                }
            }

            if (encontrado)
            {
                Console.WriteLine("Total de la boleta: " + totalBoleta);
                Console.WriteLine("*******************");
            }
            else
            {
                Console.WriteLine("No se encontró una venta con ese código.");
            }
        }
    }
}
