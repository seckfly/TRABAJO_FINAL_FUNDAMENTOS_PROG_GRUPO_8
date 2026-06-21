using System;
using System.Collections.Generic;

namespace SoftwareGestorDeVentas
{
    internal class RegistrarVenta
    {
        static int contadorVentas = 1;
        public static List<Venta> ventas = new List<Venta>();

        public static void RegistroDeVenta()
        {
            string persona;
            string opcion;
            string codigoVenta;
            double totalBoleta = 0;

            codigoVenta = "V" + contadorVentas.ToString("0000");
            contadorVentas++;

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("          REGISTRO DE NUEVA VENTA");
            Console.WriteLine("========================================");
            Console.Write("Cliente: ");
            persona = Console.ReadLine();

            while (persona == "")
            {
                Console.Write("Por favor, ingresa un cliente válido: ");
                persona = Console.ReadLine();
            }

            do
            {
                Producto productoSeleccionado = GestionInventario.SeleccionarProductoParaVenta();

                if (productoSeleccionado == null)
                {
                    Console.WriteLine("No se agregó ningún producto a la boleta.");
                }
                else if (productoSeleccionado.Stock == 0)
                {
                    Console.WriteLine("El producto seleccionado no tiene stock disponible.");
                    Console.WriteLine("No se agregó ningún producto a la boleta.");
                }
                else
                {
                    int cantidad = 0;

                    Console.WriteLine();
                    Console.WriteLine("Producto seleccionado: " + productoSeleccionado.Nombre);
                    Console.WriteLine("Precio unitario: S/ " + productoSeleccionado.Precio.ToString("0.00"));
                    Console.WriteLine("Stock disponible: " + productoSeleccionado.Stock);
                    Console.Write("Ingresa la cantidad que deseas vender: ");

                    while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad > productoSeleccionado.Stock)
                    {
                        Console.Write("Cantidad inválida. Ingrese una cantidad mayor a 0 y menor o igual al stock disponible: ");
                    }

                    double total = productoSeleccionado.Precio * cantidad;
                    totalBoleta += total;

                    productoSeleccionado.Stock -= cantidad;

                    Venta nuevaVenta = new Venta();
                    nuevaVenta.Codigo = codigoVenta;
                    nuevaVenta.Cliente = persona;
                    nuevaVenta.Producto = productoSeleccionado.Nombre;
                    nuevaVenta.Cantidad = cantidad;
                    nuevaVenta.Precio = productoSeleccionado.Precio;
                    nuevaVenta.Total = total;
                    nuevaVenta.Estado = "PENDIENTE";

                    ventas.Add(nuevaVenta);

                    Console.WriteLine();
                    Console.WriteLine("========================================");
                    Console.WriteLine("   PRODUCTO AGREGADO A LA BOLETA " + codigoVenta);
                    Console.WriteLine("========================================");
                    Console.WriteLine("Producto        : " + productoSeleccionado.Nombre);
                    Console.WriteLine("Cantidad        : " + cantidad);
                    Console.WriteLine("Precio unitario : S/ " + productoSeleccionado.Precio.ToString("0.00"));
                    Console.WriteLine("Subtotal        : S/ " + total.ToString("0.00"));
                    Console.WriteLine("Stock restante  : " + productoSeleccionado.Stock);
                    Console.WriteLine("========================================");
                    Console.WriteLine();
                }

                do
                {
                    Console.WriteLine("¿Deseas registrar otro producto en la misma boleta? (SI/NO)");
                    opcion = Console.ReadLine().ToUpper();
                } while (opcion != "SI" && opcion != "NO");

            } while (opcion == "SI");

            if (totalBoleta > 0)
            {
                Console.WriteLine("****** Boleta ******");
                Console.WriteLine("*** N° " + codigoVenta);
                Console.WriteLine("Cliente: " + persona);
                Console.WriteLine("Total de la boleta: S/ " + totalBoleta.ToString("0.00"));
                Console.WriteLine("Estado: PENDIENTE");
                Console.WriteLine("********************");
            }
            else
            {
                Console.WriteLine("No se registró ningún producto en la boleta.");
            }
        }
    }
}

