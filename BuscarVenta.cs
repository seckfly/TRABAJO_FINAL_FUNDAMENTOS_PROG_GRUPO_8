using System;
using System.Collections.Generic;

namespace SoftwareGestorDeVentas
{
    internal class BuscarVenta
    {
        public static void BusquedaDeVenta()
        {
            Console.Write("Ingrese código, cliente o producto a buscar: ");
            string busqueda = (Console.ReadLine() ?? "").ToLower();

            if (busqueda == "")
            {
                Console.WriteLine("Debe ingresar un dato para buscar.");
                return;
            }

            bool encontrado = false;
            List<string> codigosMostrados = new List<string>();

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (venta.Codigo.ToLower().Contains(busqueda) ||
                    venta.Cliente.ToLower().Contains(busqueda) ||
                    venta.Producto.ToLower().Contains(busqueda))
                {
                    if (!codigosMostrados.Contains(venta.Codigo))
                    {
                        codigosMostrados.Add(venta.Codigo);
                        encontrado = true;

                        double totalBoleta = 0;

                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("             VENTA ENCONTRADA");
                        Console.WriteLine("========================================");
                        Console.WriteLine("Código  : " + venta.Codigo);
                        Console.WriteLine("Cliente : " + venta.Cliente);
                        Console.WriteLine("Estado  : " + venta.Estado);
                        Console.WriteLine("----------------------------------------");

                        foreach (Venta detalle in RegistrarVenta.ventas)
                        {
                            if (detalle.Codigo == venta.Codigo)
                            {
                                Console.WriteLine("Producto        : " + detalle.Producto);
                                Console.WriteLine("Cantidad        : " + detalle.Cantidad);
                                Console.WriteLine("Precio unitario : S/ " + detalle.Precio.ToString("0.00"));
                                Console.WriteLine("Subtotal        : S/ " + detalle.Total.ToString("0.00"));
                                Console.WriteLine("----------------------------------------");

                                totalBoleta += detalle.Total;
                            }
                        }

                        Console.WriteLine("Total de boleta : S/ " + totalBoleta.ToString("0.00"));
                        Console.WriteLine("========================================");
                    }
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron ventas con ese dato.");
            }
        }
    }
}
