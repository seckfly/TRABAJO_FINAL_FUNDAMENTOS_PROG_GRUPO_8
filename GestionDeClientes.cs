using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareGestorDeVentas
{
    internal class GestionDeClientes
    {
        // Arreglos que almacenan los datos de cada cliente registrado
        public static string[] arreglo_de_nombres_de_clientes = new string[50]; 
        public static string[] arreglo_de_telefonos_de_clientes = new string[50]; 
        public static string[] arreglo_de_correos_de_clientes = new string[50]; 
        public static int contador_de_clientes = 0;              

        public static void GestionarClientes()
        {
            // Variable que guarda la opción elegida dentro del submenú de clientes
            int opcion_de_gestion = 0;

            // Mostrar submenú de gestión de clientes 
            Console.WriteLine("\n===== GESTIÓN DE CLIENTES =====");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Mostrar clientes");
            Console.WriteLine("3. Buscar cliente");
            Console.WriteLine("4. Volver al menú principal");
            Console.WriteLine("");

            // Leer y validar la opción del submenú 
            Console.Write("Seleccione una opción: ");
            while (!int.TryParse(Console.ReadLine(), out opcion_de_gestion) || opcion_de_gestion < 1 || opcion_de_gestion > 4)
                Console.Write("Entrada inválida. Ingrese una opción válida (1-4): ");

            switch (opcion_de_gestion)
            {
                case 1:
                    RegistrarCliente();
                    break;
                case 2:
                    MostrarClientes();
                    break;
                case 3:
                    BuscarCliente();
                    break;
                default:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Registra un nuevo cliente solicitando sus datos al usuario
        // ─────────────────────────────────────────────────────────────────────
        private static void RegistrarCliente()
        {
            Console.WriteLine("\n--- Registrar nuevo cliente ---");

            // Verificar que no se haya superado el límite máximo de clientes
            if (contador_de_clientes >= 50)
            {
                Console.WriteLine("ERROR: Se alcanzó el límite máximo de 50 clientes.");
                return;
            }

            // Ingresar nombre completo del cliente 
            string nombre_completo_del_cliente = "";
            do
            {
                Console.Write("Ingrese el nombre completo del cliente: ");
                nombre_completo_del_cliente = Console.ReadLine().Trim();

                if (nombre_completo_del_cliente == "")
                    Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");

            } while (nombre_completo_del_cliente == "");

            // Ingresar teléfono del cliente 
            string numero_de_telefono_del_cliente = "";
            do
            {
                Console.Write("Ingrese el teléfono del cliente: ");
                numero_de_telefono_del_cliente = Console.ReadLine().Trim();

                if (numero_de_telefono_del_cliente == "")
                    Console.WriteLine("El teléfono no puede estar vacío. Intente nuevamente.");

            } while (numero_de_telefono_del_cliente == "");

            // Ingresar correo electrónico del cliente 
            string correo_electronico_del_cliente = "";
            do
            {
                Console.Write("Ingrese el correo del cliente: ");
                correo_electronico_del_cliente = Console.ReadLine().Trim();

                if (correo_electronico_del_cliente == "")
                    Console.WriteLine("El correo no puede estar vacío. Intente nuevamente.");

            } while (correo_electronico_del_cliente == "");

            // Guardar los datos en los arreglos globales 
            arreglo_de_nombres_de_clientes[contador_de_clientes] = nombre_completo_del_cliente;
            arreglo_de_telefonos_de_clientes[contador_de_clientes] = numero_de_telefono_del_cliente;
            arreglo_de_correos_de_clientes[contador_de_clientes] = correo_electronico_del_cliente;

            // Incrementar el contador de clientes 
            contador_de_clientes++;

            // --- Confirmar registro exitoso ---
            Console.WriteLine("\n✔ Cliente registrado exitosamente.");
            Console.WriteLine($"   Nombre  : {nombre_completo_del_cliente}");
            Console.WriteLine($"   Teléfono: {numero_de_telefono_del_cliente}");
            Console.WriteLine($"   Correo  : {correo_electronico_del_cliente}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // Muestra en consola la lista completa de clientes registrados
        // ─────────────────────────────────────────────────────────────────────
        private static void MostrarClientes()
        {
            Console.WriteLine("\n--- Lista de clientes registrados ---");

            // Verificar si hay clientes registrados
            if (contador_de_clientes == 0)
            {
                Console.WriteLine("No hay clientes registrados en el sistema.");
                return;
            }

            // Encabezado de la tabla 
            Console.WriteLine($"\n{"N°",-4} {"Nombre",-25} {"Teléfono",-15} {"Correo",-30}");
            Console.WriteLine(new string('-', 75));

            // Recorrer e imprimir cada cliente registrado 
            for (int indice_del_cliente = 0; indice_del_cliente < contador_de_clientes; indice_del_cliente++)
            {
                // Número visible para el usuario (empieza desde 1)
                int numero_de_cliente = indice_del_cliente + 1;

                // Leer datos del cliente actual
                string nombre_completo_del_cliente = arreglo_de_nombres_de_clientes[indice_del_cliente];
                string numero_de_telefono_del_cliente = arreglo_de_telefonos_de_clientes[indice_del_cliente];
                string correo_electronico_del_cliente = arreglo_de_correos_de_clientes[indice_del_cliente];

                Console.WriteLine(
                    $"{numero_de_cliente,-4} " +
                    $"{nombre_completo_del_cliente,-25} " +
                    $"{numero_de_telefono_del_cliente,-15} " +
                    $"{correo_electronico_del_cliente,-30}"
                );
            }

            Console.WriteLine(new string('-', 75));
            Console.WriteLine($"Total de clientes registrados: {contador_de_clientes}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // Busca un cliente por nombre y muestra sus datos
        // ─────────────────────────────────────────────────────────────────────
        private static void BuscarCliente()
        {
            Console.WriteLine("\n--- Buscar cliente ---");

            // Verificar si hay clientes registrados antes de buscar
            if (contador_de_clientes == 0)
            {
                Console.WriteLine("No hay clientes registrados en el sistema.");
                return;
            }

            // Ingresar el nombre del cliente a buscar 
            string nombre_del_cliente_a_buscar = "";
            do
            {
                Console.Write("Ingrese el nombre del cliente a buscar: ");
                nombre_del_cliente_a_buscar = Console.ReadLine().Trim();

                if (nombre_del_cliente_a_buscar == "")
                    Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");

            } while (nombre_del_cliente_a_buscar == "");

            // Variable que indica si se encontró al menos un resultado
            bool se_encontro_cliente = false;

            Console.WriteLine($"\n{"N°",-4} {"Nombre",-25} {"Teléfono",-15} {"Correo",-30}");
            Console.WriteLine(new string('-', 75));

            // Recorrer los arreglos buscando coincidencias por nombre 
            for (int indice_del_cliente = 0; indice_del_cliente < contador_de_clientes; indice_del_cliente++)
            {
                string nombre_completo_del_cliente = arreglo_de_nombres_de_clientes[indice_del_cliente];

                // Comparar ignorando mayúsculas y minúsculas
                bool es_coincidencia = nombre_completo_del_cliente.ToLower().Contains(nombre_del_cliente_a_buscar.ToLower());

                if (es_coincidencia)
                {
                    int numero_de_cliente = indice_del_cliente + 1;
                    string numero_de_telefono_del_cliente = arreglo_de_telefonos_de_clientes[indice_del_cliente];
                    string correo_electronico_del_cliente = arreglo_de_correos_de_clientes[indice_del_cliente];

                    Console.WriteLine(
                        $"{numero_de_cliente,-4} " +
                        $"{nombre_completo_del_cliente,-25} " +
                        $"{numero_de_telefono_del_cliente,-15} " +
                        $"{correo_electronico_del_cliente,-30}"
                    );

                    se_encontro_cliente = true;
                }
            }

            Console.WriteLine(new string('-', 75));

            if (!se_encontro_cliente)
                Console.WriteLine($"No se encontró ningún cliente con el nombre \"{nombre_del_cliente_a_buscar}\".");
        }
    }
}