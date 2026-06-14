using System;

namespace SoftwareGestorDeVentas
{
    internal class BuscarVenta
    {
        public static void BusquedaDeVenta()
        {
            Console.WriteLine("\n===== BUSCAR VENTA =====");

            if (RegistrarVenta.contador_de_pedidos == 0)
            {
                Console.WriteLine("No existen pedidos registrados.");
                return;
            }

            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine().Trim();

            bool encontrado = false;

            for (int i = 0; i < RegistrarVenta.contador_de_pedidos; i++)
            {
                if (RegistrarVenta.arreglo_de_clientes[i].ToLower().Contains(nombre.ToLower()))
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Cliente : " + RegistrarVenta.arreglo_de_clientes[i]);
                    Console.WriteLine("Producto: " + RegistrarVenta.arreglo_de_productos[i]);
                    Console.WriteLine("Cantidad: " + RegistrarVenta.arreglo_de_cantidades[i]);
                    Console.WriteLine("Precio  : S/ " + RegistrarVenta.arreglo_de_precios[i]);
                    Console.WriteLine("Total   : S/ " + RegistrarVenta.arreglo_de_totales[i]);
                    Console.WriteLine("Estado  : " + RegistrarVenta.arreglo_de_estados[i]);
                    Console.WriteLine("--------------------------------");

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró ninguna venta.");
            }
        }
    }
}
