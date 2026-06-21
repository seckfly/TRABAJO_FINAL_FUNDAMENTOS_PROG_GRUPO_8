using System;

namespace SoftwareGestorDeVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("----- GESTOR DE VENTAS -----");
                Console.WriteLine("1. Registrar venta");
                Console.WriteLine("2. Mostrar venta");
                Console.WriteLine("3. Buscar venta");
                Console.WriteLine("4. Actualizar estado");
                Console.WriteLine("5. Simular caja");
                Console.WriteLine("6. Reporte de ventas");
                Console.WriteLine("7. Gestión de inventario");
                Console.WriteLine("8. Salir");
                Console.WriteLine("");

                Console.Write("Ingresa el índice de lo que deseas hacer: ");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 8)
                {
                    Console.Write("Entrada inválida. Ingrese una opción válida: ");
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarVenta.RegistroDeVenta();
                        break;

                    case 2:
                        MostrarVenta.VerVenta();
                        break;

                    case 3:
                        BuscarVenta.BusquedaDeVenta();
                        break;

                    case 4:
                        ActualizarEstado.ActualizacionDeEstado();
                        break;

                    case 5:
                        SimularCaja.SimulacionDeCaja();
                        break;

                    case 6:
                        ReporteDeVentas.ReportarVentas();
                        break;

                    case 7:
                        GestionInventario.GestionarInventario();
                        break;

                    case 8:
                        Console.WriteLine("El programa se cerró con éxito");
                        break;
                }

            } while (opcion != 8);

            Console.WriteLine("Programa Finalizado...");
        }
    }
}
