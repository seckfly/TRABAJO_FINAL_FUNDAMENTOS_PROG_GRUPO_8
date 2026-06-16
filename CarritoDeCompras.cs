using System;

namespace SoftwareGestorDeVentas
{
    internal class CarritoDeCompras
    {
        public static void MostrarCarrito()
        {
            if (RegistrarVenta.ventas.Count == 0)
            {
                Console.WriteLine("No hay productos registrados en el carrito.");
                return;
            }

            double totalGeneral = 0;

            Console.WriteLine("***** CARRITO DE COMPRAS *****");

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Código: {venta.Codigo}");
                Console.WriteLine($"Cliente: {venta.Cliente}");
                Console.WriteLine($"Producto: {venta.Producto}");
                Console.WriteLine($"Cantidad: {venta.Cantidad}");
                Console.WriteLine($"Precio Unitario: {venta.Precio}");
                Console.WriteLine($"Total: {venta.Total}");
                Console.WriteLine($"Estado: {venta.Estado}");

                totalGeneral += venta.Total;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total general del carrito: {totalGeneral}");
            Console.WriteLine("******************************");
        }
    }
}
