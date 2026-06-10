using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareGestorDeVentas
{
    internal class RegistrarVenta
    {
        public static string[] arreglo_de_clientes = new string[50]; 
        public static string[] arreglo_de_productos = new string[50];
        public static int[] arreglo_de_cantidades = new int[50];    
        public static double[] arreglo_de_precios = new double[50]; 
        public static double[] arreglo_de_totales = new double[50];
        public static string[] arreglo_de_estados = new string[50]; 
        public static int contador_de_pedidos = 0;              

        public static void RegistroDeVenta()
        {
            Console.WriteLine("\n===== REGISTRAR PEDIDO =====");

            // Verificar que no se haya superado el límite máximo de pedidos
            if (contador_de_pedidos >= 50)
            {
                Console.WriteLine("ERROR: Se alcanzó el límite máximo de 50 pedidos.");
                return;
            }

            // --- Ingresar nombre del cliente ---
            string nombre_del_cliente = "";
            do
            {
                Console.Write("Ingrese el nombre del cliente: ");
                nombre_del_cliente = Console.ReadLine().Trim();

                if (nombre_del_cliente == "")
                    Console.WriteLine("El nombre del cliente no puede estar vacío. Intente nuevamente.");

            } while (nombre_del_cliente == "");

            // --- Ingresar nombre del producto ---
            string nombre_del_producto = "";
            do
            {
                Console.Write("Ingrese el nombre del producto: ");
                nombre_del_producto = Console.ReadLine().Trim();

                if (nombre_del_producto == "")
                    Console.WriteLine("El nombre del producto no puede estar vacío. Intente nuevamente.");

            } while (nombre_del_producto == "");

            // --- Ingresar cantidad pedida ---
            int cantidad_pedida = 0;
            bool es_cantidad_valida = false;
            do
            {
                Console.Write("Ingrese la cantidad pedida: ");
                es_cantidad_valida = int.TryParse(Console.ReadLine(), out cantidad_pedida);

                if (!es_cantidad_valida || cantidad_pedida <= 0)
                {
                    Console.WriteLine("La cantidad debe ser un número entero mayor a 0. Intente nuevamente.");
                    es_cantidad_valida = false;
                }
            } while (!es_cantidad_valida);

            // --- Ingresar precio unitario del producto ---
            double precio_unitario = 0.0;
            bool es_precio_valido = false;
            do
            {
                Console.Write("Ingrese el precio unitario (S/): ");
                es_precio_valido = double.TryParse(Console.ReadLine(), out precio_unitario);

                if (!es_precio_valido || precio_unitario <= 0)
                {
                    Console.WriteLine("El precio debe ser un número mayor a 0. Intente nuevamente.");
                    es_precio_valido = false;
                }
            } while (!es_precio_valido);

            // --- Calcular el total del pedido ---
            double total_del_pedido = cantidad_pedida * precio_unitario;

            // --- Estado inicial asignado automáticamente ---
            string estado_inicial_del_pedido = "Pendiente";

            // --- Guardar los datos en los arreglos globales ---
            arreglo_de_clientes[contador_de_pedidos] = nombre_del_cliente;
            arreglo_de_productos[contador_de_pedidos] = nombre_del_producto;
            arreglo_de_cantidades[contador_de_pedidos] = cantidad_pedida;
            arreglo_de_precios[contador_de_pedidos] = precio_unitario;
            arreglo_de_totales[contador_de_pedidos] = total_del_pedido;
            arreglo_de_estados[contador_de_pedidos] = estado_inicial_del_pedido;

            // --- Incrementar el contador de pedidos ---
            contador_de_pedidos++;

            // --- Confirmar registro exitoso ---
            Console.WriteLine("\n✔ Pedido registrado exitosamente.");
            Console.WriteLine($"   Cliente  : {nombre_del_cliente}");
            Console.WriteLine($"   Producto : {nombre_del_producto}");
            Console.WriteLine($"   Cantidad : {cantidad_pedida}");
            Console.WriteLine($"   Precio   : S/ {precio_unitario:F2}");
            Console.WriteLine($"   Total    : S/ {total_del_pedido:F2}");
            Console.WriteLine($"   Estado   : {estado_inicial_del_pedido}");
        }
    }
}
