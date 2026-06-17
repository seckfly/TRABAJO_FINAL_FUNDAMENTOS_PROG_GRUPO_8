using System;

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

            int cantidadVentas = 0;

            Console.WriteLine("***** SIMULACIÓN DE CAJA *****");

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                cantidadVentas++;
                totalGeneral += venta.Total;

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Código: {venta.Codigo}");
                Console.WriteLine($"Cliente: {venta.Cliente}");
                Console.WriteLine($"Producto: {venta.Producto}");
                Console.WriteLine($"Total: {venta.Total}");
                Console.WriteLine($"Estado: {venta.Estado}");

                switch (venta.Estado)
                {
                    case "PENDIENTE":
                        totalPendiente += venta.Total;
                        break;

                    case "PAGADO":
                        totalPagado += venta.Total;
                        dineroRecibido += venta.Total;
                        break;

                    case "ENTREGADO":
                        totalEntregado += venta.Total;
                        dineroRecibido += venta.Total;
                        break;

                    case "CANCELADO":
                        totalCancelado += venta.Total;
                        break;

                    default:
                        Console.WriteLine("Estado no reconocido.");
                        break;
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("RESUMEN DE CAJA");
            Console.WriteLine($"Cantidad de ventas registradas: {cantidadVentas}");
            Console.WriteLine($"Total general de ventas: {totalGeneral}");
            Console.WriteLine($"Total pendiente: {totalPendiente}");
            Console.WriteLine($"Total pagado: {totalPagado}");
            Console.WriteLine($"Total entregado: {totalEntregado}");
            Console.WriteLine($"Total cancelado: {totalCancelado}");
            Console.WriteLine($"Dinero recibido en caja: {dineroRecibido}");
            Console.WriteLine("******************************");
        }
    }
}
