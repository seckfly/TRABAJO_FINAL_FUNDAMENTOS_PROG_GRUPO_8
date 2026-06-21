using System;
using System.Collections.Generic;

namespace SoftwareGestorDeVentas
{
    internal class SimularCaja
    {
        public static void SimulacionDeCaja()
        {
            if (RegistrarVenta.ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas para simular la caja.");
                return;
            }

            double totalGeneral = 0;
            double totalPendiente = 0;
            double totalPagado = 0;
            double totalEntregado = 0;
            double totalCancelado = 0;
            double dineroRecibido = 0;

            int cantidadBoletas = 0;
            List<string> codigosMostrados = new List<string>();

            Console.WriteLine("***** SIMULACIÓN DE CAJA *****");

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                if (!codigosMostrados.Contains(venta.Codigo))
                {
                    codigosMostrados.Add(venta.Codigo);
                    cantidadBoletas++;

                    double totalBoleta = 0;
                    string cliente = venta.Cliente;
                    string estadoBoleta = venta.Estado;

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Código : " + venta.Codigo);
                    Console.WriteLine("Cliente: " + cliente);
                    Console.WriteLine("Estado : " + estadoBoleta);
                    Console.WriteLine();
                    Console.WriteLine("Productos:");

                    foreach (Venta detalle in RegistrarVenta.ventas)
                    {
                        if (detalle.Codigo == venta.Codigo)
                        {
                            Console.WriteLine("- " + detalle.Producto + " | Cantidad: " + detalle.Cantidad + " | Subtotal: S/ " + detalle.Total.ToString("0.00"));
                            totalBoleta += detalle.Total;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Total de boleta: S/ " + totalBoleta.ToString("0.00"));

                    totalGeneral += totalBoleta;

                    switch (estadoBoleta)
                    {
                        case "PENDIENTE":
                            totalPendiente += totalBoleta;
                            break;

                        case "PAGADO":
                            totalPagado += totalBoleta;
                            dineroRecibido += totalBoleta;
                            break;

                        case "ENTREGADO":
                            totalEntregado += totalBoleta;
                            dineroRecibido += totalBoleta;
                            break;

                        case "CANCELADO":
                            totalCancelado += totalBoleta;
                            break;

                        default:
                            Console.WriteLine("Estado no reconocido.");
                            break;
                    }
                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("RESUMEN DE CAJA");
            Console.WriteLine("Cantidad de boletas registradas: " + cantidadBoletas);
            Console.WriteLine("Total general de ventas: S/ " + totalGeneral.ToString("0.00"));
            Console.WriteLine("Total pendiente: S/ " + totalPendiente.ToString("0.00"));
            Console.WriteLine("Total pagado: S/ " + totalPagado.ToString("0.00"));
            Console.WriteLine("Total entregado: S/ " + totalEntregado.ToString("0.00"));
            Console.WriteLine("Total cancelado: S/ " + totalCancelado.ToString("0.00"));
            Console.WriteLine("Dinero recibido en caja: S/ " + dineroRecibido.ToString("0.00"));
            Console.WriteLine("******************************");
        }
    }
}
