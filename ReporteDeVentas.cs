using System;

namespace SoftwareGestorDeVentas
{
    internal class ReporteDeVentas
    {
        public static void ReportarVentas()
        {
            Console.WriteLine("\n===== REPORTE DE VENTAS =====");

            if (RegistrarVenta.ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas. No se puede generar el reporte.");
                return;
            }

            double total_acumulado_de_ventas = 0;
            double total_de_venta_mas_alta = 0;
            string nombre_del_cliente_con_mayor_venta = "";
            string nombre_del_producto_mas_vendido = "";
            int cantidad_maxima_acumulada_del_producto = 0;

            int contador_de_ventas_pendientes = 0;
            int contador_de_ventas_pagadas = 0;
            int contador_de_ventas_entregadas = 0;
            int contador_de_ventas_canceladas = 0;

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                total_acumulado_de_ventas += venta.Total;

                if (venta.Total > total_de_venta_mas_alta)
                {
                    total_de_venta_mas_alta = venta.Total;
                    nombre_del_cliente_con_mayor_venta = venta.Cliente;
                }

                int cantidad_total_del_producto_actual = 0;

                foreach (Venta venta_interna in RegistrarVenta.ventas)
                {
                    if (venta_interna.Producto.ToLower() == venta.Producto.ToLower())
                    {
                        cantidad_total_del_producto_actual += venta_interna.Cantidad;
                    }
                }

                if (cantidad_total_del_producto_actual > cantidad_maxima_acumulada_del_producto)
                {
                    cantidad_maxima_acumulada_del_producto = cantidad_total_del_producto_actual;
                    nombre_del_producto_mas_vendido = venta.Producto;
                }

                if (venta.Estado == "PENDIENTE")
                {
                    contador_de_ventas_pendientes++;
                }
                else if (venta.Estado == "PAGADO")
                {
                    contador_de_ventas_pagadas++;
                }
                else if (venta.Estado == "ENTREGADO")
                {
                    contador_de_ventas_entregadas++;
                }
                else if (venta.Estado == "CANCELADO")
                {
                    contador_de_ventas_canceladas++;
                }
            }

            double promedio_de_venta = total_acumulado_de_ventas / RegistrarVenta.ventas.Count;

            Console.WriteLine("\n--- Resumen General ---");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"Total de ventas registradas : {RegistrarVenta.ventas.Count}");
            Console.WriteLine($"Ventas pendientes           : {contador_de_ventas_pendientes}");
            Console.WriteLine($"Ventas pagadas              : {contador_de_ventas_pagadas}");
            Console.WriteLine($"Ventas entregadas           : {contador_de_ventas_entregadas}");
            Console.WriteLine($"Ventas canceladas           : {contador_de_ventas_canceladas}");
            Console.WriteLine($"Total acumulado de ventas   : S/ {total_acumulado_de_ventas:F2}");
            Console.WriteLine($"Promedio por venta          : S/ {promedio_de_venta:F2}");
            Console.WriteLine($"Venta más alta              : S/ {total_de_venta_mas_alta:F2} ({nombre_del_cliente_con_mayor_venta})");
            Console.WriteLine($"Producto más vendido        : {nombre_del_producto_mas_vendido} ({cantidad_maxima_acumulada_del_producto} unidades)");
            Console.WriteLine(new string('-', 45));

            Console.WriteLine("\n--- Detalle de todas las ventas ---");
            Console.WriteLine($"\n{"N°",-4} {"Código",-8} {"Cliente",-22} {"Producto",-18} {"Cant.",-7} {"Precio",-12} {"Total",-12} {"Estado",-12}");
            Console.WriteLine(new string('-', 100));

            int numero_de_venta = 1;

            foreach (Venta venta in RegistrarVenta.ventas)
            {
                Console.WriteLine(
                    $"{numero_de_venta,-4} " +
                    $"{venta.Codigo,-8} " +
                    $"{venta.Cliente,-22} " +
                    $"{venta.Producto,-18} " +
                    $"{venta.Cantidad,-7} " +
                    $"S/{venta.Precio,-10:F2} " +
                    $"S/{venta.Total,-10:F2} " +
                    $"{venta.Estado,-12}"
                );

                numero_de_venta++;
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"\nTOTAL GENERAL DE VENTAS: S/ {total_acumulado_de_ventas:F2}");
        }
    }
}
