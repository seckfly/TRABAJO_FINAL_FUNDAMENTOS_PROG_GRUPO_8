﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
            string opcion;
            string codigoVenta;

            do
            {
                Console.WriteLine("Ingresa tu nombre y apellidos");
                persona = Console.ReadLine();
                do
                {
                    if (persona == "") 
                    {
                        Console.WriteLine("Por favor, ingresa tu nombre y apellido");
                        persona = Console.ReadLine();
                    }
                } while (persona == "");

                Console.WriteLine("Ingresa el nombre del producto: ");
                producto = Console.ReadLine();
                do
                {
                    if (producto == "")
                    {
                        Console.WriteLine("Porfavor, ingresa el nombre del producto: ");
                        producto = Console.ReadLine();
                    }
                } while (producto == "");

                Console.WriteLine("Ingresa la cantidad que deseas: ");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Ingresa un número entero mayor a 0.");
                    }
                } while (cantidad <= 0);

                Console.WriteLine("Ingresa su precio unitario");
                do
                {
                    if (!double.TryParse(Console.ReadLine(), out precioUnitario) || precioUnitario <= 0)
                    {
                        Console.WriteLine("Porfavor, el precio unitartio debe ser un numero entero y mayor a 0");
                    }
                } while (precioUnitario <= 0);

                total = precioUnitario * cantidad;
                codigoVenta = "V" + contadorVentas.ToString("0000");
                contadorVentas++;

                Venta nuevaVenta = new Venta();

                nuevaVenta.Codigo = codigoVenta;
                nuevaVenta.Cliente = persona;
                nuevaVenta.Producto = producto;
                nuevaVenta.Cantidad = cantidad;
                nuevaVenta.Precio = precioUnitario;
                nuevaVenta.Total = total;
                nuevaVenta.Estado = "PENDIENTE";

                ventas.Add(nuevaVenta);

                Console.WriteLine("******Boleta******");
                Console.WriteLine("*** N° " + codigoVenta);
                Console.WriteLine("Cliente: " + persona);
                Console.WriteLine("Producto:" + producto);
                Console.WriteLine("Cantidad: " + cantidad);
                Console.WriteLine("Precio Unitario: " + precioUnitario);
                Console.WriteLine("Total:" + total);
                Console.WriteLine("******************");


                do
                {
                    Console.WriteLine("¿Deseas registrar otro producto (SI/NO)");
                    opcion = Console.ReadLine().ToUpper();

                } while (opcion != "SI" && opcion != "NO");

            } while (opcion == "SI");
               
        }
    }
}