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
            string producto;
            int cantidad = 0;
            double precioUnitario = 0;
            double total = 0;
            double totalBoleta = 0;
            string opcion;
            string codigoVenta;

            codigoVenta = "V" + contadorVentas.ToString("0000");
            contadorVentas++;

            Console.WriteLine("Ingresa tu nombre y apellidos");
            persona = Console.ReadLine();

            while (persona == "")
            {
                Console.WriteLine("Por favor, ingresa tu nombre y apellido");
                persona = Console.ReadLine();
            }

            do
            {
                Console.WriteLine("Ingresa el nombre del producto: ");
                producto = Console.ReadLine();

                while (producto == "")
                {
                    Console.WriteLine("Por favor, ingresa el nombre del producto: ");
                    producto = Console.ReadLine();
                }

                Console.WriteLine("Ingresa la cantidad que deseas: ");
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Ingresa un número entero mayor a 0.");
                }

                Console.WriteLine("Ingresa su precio unitario");
                while (!double.TryParse(Console.ReadLine(), out precioUnitario) || precioUnitario <= 0)
                {
                    Console.WriteLine("Por favor, el precio unitario debe ser un número mayor a 0");
                }

                total = precioUnitario * cantidad;
                totalBoleta += total;

                Venta nuevaVenta = new Venta();
                nuevaVenta.Codigo = codigoVenta;
                nuevaVenta.Cliente = persona;
                nuevaVenta.Producto = producto;
                nuevaVenta.Cantidad = cantidad;
                nuevaVenta.Precio = precioUnitario;
                nuevaVenta.Total = total;
                nuevaVenta.Estado = "PENDIENTE";

                ventas.Add(nuevaVenta);

                Console.WriteLine("Producto agregado a la boleta " + codigoVenta);
                Console.WriteLine("Producto: " + producto);
                Console.WriteLine("Cantidad: " + cantidad);
                Console.WriteLine("Precio Unitario: " + precioUnitario);
                Console.WriteLine("Subtotal: " + total);

                do
                {
                    Console.WriteLine("¿Deseas registrar otro producto en la misma boleta? (SI/NO)");
                    opcion = Console.ReadLine().ToUpper();
                } while (opcion != "SI" && opcion != "NO");

            } while (opcion == "SI");

            Console.WriteLine("****** Boleta ******");
            Console.WriteLine("*** N° " + codigoVenta);
            Console.WriteLine("Cliente: " + persona);
            Console.WriteLine("Total de la boleta: " + totalBoleta);
            Console.WriteLine("Estado: PENDIENTE");
            Console.WriteLine("********************");
        }
    }
}
