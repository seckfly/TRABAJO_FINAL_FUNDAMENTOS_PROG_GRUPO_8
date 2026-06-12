
using System.Collections.Generic;
using System.Text;
using System;

namespace SoftwareGestorDeVentas
{
    internal class BuscarVenta
    {
        public static void BusquedaDeVenta()
        {
            Console.Write("Ingrese código, cliente o producto a buscar: ");
            string busqueda = Console.ReadLine().ToLower();

            bool encontrado = false;

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (venta.Codigo.ToLower().Contains(busqueda) ||
                    venta.Cliente.ToLower().Contains(busqueda) ||
                    venta.Producto.ToLower().Contains(busqueda))
                {
                    Console.WriteLine("\n***** VENTA ENCONTRADA *****");
                    Console.WriteLine("Código: " + venta.Codigo);
                    Console.WriteLine("Cliente: " + venta.Cliente);
                    Console.WriteLine("Producto: " + venta.Producto);
                    Console.WriteLine("Cantidad: " + venta.Cantidad);
                    Console.WriteLine("Precio Unitario: " + venta.Precio);
                    Console.WriteLine("Total: " + venta.Total);
                    Console.WriteLine("Estado: " + venta.Estado);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron ventas con ese dato.");
            }
        }
    }
}