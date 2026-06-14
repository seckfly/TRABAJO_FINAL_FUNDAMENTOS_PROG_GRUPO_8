using System;

namespace SoftwareGestorDeVentas
{
    internal class Carrito
    {
        public static void MostrarCarrito()
        {
            Console.WriteLine("\n===== CARRITO DE COMPRAS =====");

            // Verificar si existen pedidos registrados
            if (RegistrarVenta.contador_de_pedidos == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            double totalGeneral = 0;

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("N°\tCliente\t\tProducto\tCant.\tPrecio\t\tTotal");
            Console.WriteLine("--------------------------------------------------------------------------");

            // Recorrer todos los pedidos registrados
            for (int i = 0; i < RegistrarVenta.contador_de_pedidos; i++)
            {
                Console.WriteLine(
                    (i + 1) + "\t" +
                    RegistrarVenta.arreglo_de_clientes[i] + "\t\t" +
                    RegistrarVenta.arreglo_de_productos[i] + "\t\t" +
                    RegistrarVenta.arreglo_de_cantidades[i] + "\t" +
                    "S/ " + RegistrarVenta.arreglo_de_precios[i].ToString("F2") + "\t" +
                    "S/ " + RegistrarVenta.arreglo_de_totales[i].ToString("F2")
                );

                totalGeneral += RegistrarVenta.arreglo_de_totales[i];
            }

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("TOTAL DEL CARRITO: S/ " + totalGeneral.ToString("F2"));
            Console.WriteLine("--------------------------------------------------------------------------");
        }
    }
}
