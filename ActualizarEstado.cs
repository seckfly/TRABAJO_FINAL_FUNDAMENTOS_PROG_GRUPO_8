using System;

namespace SoftwareGestorDeVentas
{
    internal class ActualizarEstado
    {
        public static void ActualizacionDeEstado()
        {
            Console.Write("Ingrese el código de la venta a actualizar: ");
            string codigoBuscado = (Console.ReadLine() ?? "").ToUpper();

            if (codigoBuscado == "")
            {
                Console.WriteLine("Debe ingresar un código de venta.");
                return;
            }

            bool encontrado = false;
            double totalBoleta = 0;
            string cliente = "";
            string estadoActual = "";
            int numeroProducto = 1;

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if ((venta.Codigo ?? "").ToUpper() == codigoBuscado)
                {
                    if (!encontrado)
                    {
                        cliente = venta.Cliente;
                        estadoActual = venta.Estado;

                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("           VENTA ENCONTRADA");
                        Console.WriteLine("========================================");
                        Console.WriteLine("Código        : " + venta.Codigo);
                        Console.WriteLine("Cliente       : " + cliente);
                        Console.WriteLine("Estado actual : " + estadoActual);
                        Console.WriteLine("----------------------------------------");
                    }

                    encontrado = true;

                    Console.WriteLine("Producto " + numeroProducto + "      : " + venta.Producto);
                    Console.WriteLine("Cantidad        : " + venta.Cantidad);
                    Console.WriteLine("Precio unitario : S/ " + venta.Precio.ToString("0.00"));
                    Console.WriteLine("Subtotal        : S/ " + venta.Total.ToString("0.00"));
                    Console.WriteLine("----------------------------------------");

                    totalBoleta += venta.Total;
                    numeroProducto++;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró una venta con ese código.");
                return;
            }

            Console.WriteLine("Total de boleta : S/ " + totalBoleta.ToString("0.00"));
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("Estados disponibles:");
            Console.WriteLine("1. PENDIENTE");
            Console.WriteLine("2. PAGADO");
            Console.WriteLine("3. ENTREGADO");
            Console.WriteLine("4. CANCELADO");

            Console.Write("Seleccione el nuevo estado: ");
            string opcion = Console.ReadLine() ?? "";

            string nuevoEstado;

            switch (opcion)
            {
                case "1":
                    nuevoEstado = "PENDIENTE";
                    break;
                case "2":
                    nuevoEstado = "PAGADO";
                    break;
                case "3":
                    nuevoEstado = "ENTREGADO";
                    break;
                case "4":
                    nuevoEstado = "CANCELADO";
                    break;
                default:
                    Console.WriteLine("Opción inválida. No se actualizó el estado.");
                    return;
            }

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if ((venta.Codigo ?? "").ToUpper() == codigoBuscado)
                {
                    venta.Estado = nuevoEstado;
                }
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(" Estado actualizado correctamente");
            Console.WriteLine(" Código : " + codigoBuscado);
            Console.WriteLine(" Estado : " + nuevoEstado);
            Console.WriteLine("========================================");
        }
    }
}
