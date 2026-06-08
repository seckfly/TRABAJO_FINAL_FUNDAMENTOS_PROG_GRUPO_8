namespace SoftwareGestorDeVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- GESTOR DE VENTAS -----");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Mostrar venta");
            Console.WriteLine("3. Buscar venta");
            Console.WriteLine("4. Actualizar estado");
            Console.WriteLine("5. Carrito de compras");
            Console.WriteLine("6. Simular caja");
            Console.WriteLine("7. Gestión de clientes");
            Console.WriteLine("8. Reporte de ventas");
            Console.WriteLine("9. Salir");

            
            Console.WriteLine("");
            Console.Write("Ingresa el índice de lo que deseas hacer: ");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 9) Console.Write("Entrada inválida. Ingrese una opción válida: ");

            switch (opcion)
            {
                    case 1:
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
                        CarritoDeCompras.MostrarCarrito();
                    break;
                    case 6:
                        SimularCaja.SimulacionDeCaja();
                    break;
                    case 7:
                        GestionDeClientes.GestioanrClientes();
                    break;
                    case 8:
                        ReporteDeVentas.ReportarVentas();
                    break;
                default: 
                    Console.WriteLine("El programa se cerró con éxito");
                    break;
            
            }
            } while (opcion != 9);
            Console.WriteLine("Programa Finalizado...");

            
        }
    }
}
