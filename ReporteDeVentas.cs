using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareGestorDeVentas
{
    internal class ReporteDeVentas
    {
        public static void ReportarVentas()
        {
            Console.WriteLine("\n===== REPORTE DE VENTAS =====");

            // Verificar si hay pedidos registrados antes de generar el reporte
            if (RegistrarVenta.contador_de_pedidos == 0)
            {
                Console.WriteLine("No hay pedidos registrados. No se puede generar el reporte.");
                return;
            }

            double total_acumulado_de_ventas = 0.0;
            double total_del_pedido_mas_alto = 0.0;
            string nombre_del_cliente_con_mayor_pedido = "";
            string nombre_del_producto_mas_vendido = "";
            int cantidad_maxima_acumulada_del_producto = 0;
            int contador_de_pedidos_pendientes = 0;
            int contador_de_pedidos_entregados = 0;

            // Recorrer todos los pedidos para calcular los datos del reporte 
            for (int indice_del_pedido = 0; indice_del_pedido < RegistrarVenta.contador_de_pedidos; indice_del_pedido++)
            {
                // Leer datos del pedido actual
                string nombre_del_cliente = RegistrarVenta.arreglo_de_clientes[indice_del_pedido];
                string nombre_del_producto = RegistrarVenta.arreglo_de_productos[indice_del_pedido];
                int cantidad_pedida = RegistrarVenta.arreglo_de_cantidades[indice_del_pedido];
                double total_del_pedido = RegistrarVenta.arreglo_de_totales[indice_del_pedido];
                string estado_del_pedido = RegistrarVenta.arreglo_de_estados[indice_del_pedido];

                // Acumular el total general de ventas
                total_acumulado_de_ventas += total_del_pedido;

                // Verificar si es el pedido con el total más alto
                if (total_del_pedido > total_del_pedido_mas_alto)
                {
                    total_del_pedido_mas_alto = total_del_pedido;
                    nombre_del_cliente_con_mayor_pedido = nombre_del_cliente;
                }

                // Calcular la cantidad total vendida del producto actual para encontrar el más vendido
                int cantidad_total_del_producto_actual = 0;

                for (int indice_interno = 0; indice_interno < RegistrarVenta.contador_de_pedidos; indice_interno++)
                {
                    if (RegistrarVenta.arreglo_de_productos[indice_interno].ToLower() == nombre_del_producto.ToLower())
                        cantidad_total_del_producto_actual += RegistrarVenta.arreglo_de_cantidades[indice_interno];
                }

                if (cantidad_total_del_producto_actual > cantidad_maxima_acumulada_del_producto)
                {
                    cantidad_maxima_acumulada_del_producto = cantidad_total_del_producto_actual;
                    nombre_del_producto_mas_vendido = nombre_del_producto;
                }

                // Contar pedidos por estado
                if (estado_del_pedido.ToLower() == "pendiente")
                    contador_de_pedidos_pendientes++;
                else if (estado_del_pedido.ToLower() == "entregado")
                    contador_de_pedidos_entregados++;
            }

            // Variable que guarda el promedio de ventas por pedido
            double promedio_de_venta_por_pedido = total_acumulado_de_ventas / RegistrarVenta.contador_de_pedidos;

            // Mostrar resumen general 

            Console.WriteLine("\n--- Resumen General ---");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"  Total de pedidos registrados : {RegistrarVenta.contador_de_pedidos}");
            Console.WriteLine($"  Pedidos pendientes           : {contador_de_pedidos_pendientes}");
            Console.WriteLine($"  Pedidos entregados           : {contador_de_pedidos_entregados}");
            Console.WriteLine($"  Total acumulado de ventas    : S/ {total_acumulado_de_ventas:F2}");
            Console.WriteLine($"  Promedio de venta por pedido : S/ {promedio_de_venta_por_pedido:F2}");
            Console.WriteLine($"  Pedido más alto              : S/ {total_del_pedido_mas_alto:F2} ({nombre_del_cliente_con_mayor_pedido})");
            Console.WriteLine($"  Producto más vendido         : {nombre_del_producto_mas_vendido} ({cantidad_maxima_acumulada_del_producto} unidades)");
            Console.WriteLine(new string('-', 45));

            // Detalle completo de pedidos 

            Console.WriteLine("\n--- Detalle de todos los pedidos ---");
            Console.WriteLine($"\n{"N°",-4} {"Cliente",-20} {"Producto",-20} {"Cant.",-7} {"Precio",-12} {"Total",-12} {"Estado",-15}");
            Console.WriteLine(new string('-', 90));

            for (int indice_del_pedido = 0; indice_del_pedido < RegistrarVenta.contador_de_pedidos; indice_del_pedido++)
            {
                int numero_de_pedido = indice_del_pedido + 1;
                string nombre_del_cliente = RegistrarVenta.arreglo_de_clientes[indice_del_pedido];
                string nombre_del_producto = RegistrarVenta.arreglo_de_productos[indice_del_pedido];
                int cantidad_pedida = RegistrarVenta.arreglo_de_cantidades[indice_del_pedido];
                double precio_unitario = RegistrarVenta.arreglo_de_precios[indice_del_pedido];
                double total_del_pedido = RegistrarVenta.arreglo_de_totales[indice_del_pedido];
                string estado_del_pedido = RegistrarVenta.arreglo_de_estados[indice_del_pedido];

                Console.WriteLine(
                    $"{numero_de_pedido,-4} " +
                    $"{nombre_del_cliente,-20} " +
                    $"{nombre_del_producto,-20} " +
                    $"{cantidad_pedida,-7} " +
                    $"S/{precio_unitario,-11:F2} " +
                    $"S/{total_del_pedido,-11:F2} " +
                    $"{estado_del_pedido,-15}"
                );
            }

            Console.WriteLine(new string('-', 90));
            Console.WriteLine($"\nTOTAL GENERAL DE VENTAS: S/ {total_acumulado_de_ventas:F2}");
        }
    }
}
