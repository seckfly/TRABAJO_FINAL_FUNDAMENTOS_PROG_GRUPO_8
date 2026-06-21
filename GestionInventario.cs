using System;
using System.Collections.Generic;

namespace SoftwareGestorDeVentas
{
    internal class GestionInventario
    {
        public static List<Producto> productos = new List<Producto>()
        {
            new Producto { Codigo = "P001", Nombre = "Arroz Extra COSTEÑO Bolsa 750g", Precio = 4.50, Stock = 30 },
            new Producto { Codigo = "P002", Nombre = "Arroz Añejo Extra COSTEÑO Bolsa 5kg", Precio = 19.90, Stock = 12 },
            new Producto { Codigo = "P003", Nombre = "Azúcar Rubia M&K Bolsa 1kg", Precio = 4.29, Stock = 25 },
            new Producto { Codigo = "P004", Nombre = "Azúcar Blanca M&K Bolsa 1kg", Precio = 4.69, Stock = 20 },
            new Producto { Codigo = "P005", Nombre = "Aceite Vegetal PRIMOR Clásico Botella 900ml", Precio = 8.50, Stock = 18 },
            new Producto { Codigo = "P006", Nombre = "Aceite Vegetal PRIMOR Premium Botella 900ml", Precio = 9.50, Stock = 15 },
            new Producto { Codigo = "P007", Nombre = "Fideos DON VITTORIO Spaghetti Bolsa 500g", Precio = 3.80, Stock = 35 },
            new Producto { Codigo = "P008", Nombre = "Fideos DON VITTORIO Codo Chico Bolsa 250g", Precio = 1.80, Stock = 30 },
            new Producto { Codigo = "P009", Nombre = "Leche Evaporada Entera GLORIA Lata 390g", Precio = 3.90, Stock = 36 },
            new Producto { Codigo = "P010", Nombre = "Sal Marina EMSAL Mesa Bolsa 1kg", Precio = 2.00, Stock = 25 },
            new Producto { Codigo = "P011", Nombre = "Café Instantáneo ALTOMAYO Gourmet Frasco 170g", Precio = 27.50, Stock = 8 },
            new Producto { Codigo = "P012", Nombre = "Trozos de Atún FLORIDA en Aceite Vegetal Lata 140g", Precio = 5.25, Stock = 24 },
            new Producto { Codigo = "P013", Nombre = "Grated de Atún CAMPOMAR en Aceite Vegetal Lata 160g", Precio = 3.35, Stock = 24 },
            new Producto { Codigo = "P014", Nombre = "Galletas de Soda SAN JORGE Paquete 7un", Precio = 4.00, Stock = 30 },
            new Producto { Codigo = "P015", Nombre = "Galletas Saladas FIELD Cream Cracker Paquete 258g", Precio = 5.50, Stock = 20 },
            new Producto { Codigo = "P016", Nombre = "Gaseosa COCA COLA Botella 600ml", Precio = 3.00, Stock = 24 },
            new Producto { Codigo = "P017", Nombre = "Gaseosa INCA KOLA Botella 1.5L", Precio = 6.40, Stock = 18 },
            new Producto { Codigo = "P018", Nombre = "Lejía CLOROX Tradicional Botella 860g", Precio = 2.30, Stock = 20 },
            new Producto { Codigo = "P019", Nombre = "Jabón de Lavar BOLÍVAR Cuidado Total Bolsa 190g", Precio = 2.80, Stock = 25 },
            new Producto { Codigo = "P020", Nombre = "Jabón para Ropa POPEYE Extra Blancura Barra 210g", Precio = 2.50, Stock = 25 },
            new Producto { Codigo = "P021", Nombre = "Papel Higiénico SUAVE Cuidado Completo Paquete 12un", Precio = 17.00, Stock = 10 },
            new Producto { Codigo = "P022", Nombre = "Papel Higiénico ELITE Professional Bolsa 8un", Precio = 22.90, Stock = 8 }
        };

        public static void GestionarInventario()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("----- GESTIÓN DE INVENTARIO -----");
                Console.WriteLine("1. Ver inventario");
                Console.WriteLine("2. Aumentar stock de producto existente");
                Console.WriteLine("3. Agregar nuevo producto");
                Console.WriteLine("4. Volver al menú principal");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.Write("Opción inválida. Ingrese una opción válida: ");
                }

                switch (opcion)
                {
                    case 1:
                        MostrarInventario();
                        break;

                    case 2:
                        AumentarStock();
                        break;

                    case 3:
                        AgregarProducto();
                        break;

                    case 4:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;
                }

            } while (opcion != 4);
        }

        public static void MostrarInventario()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("              INVENTARIO DISPONIBLE");
            Console.WriteLine("==============================================");

            foreach (Producto producto in productos)
            {
                Console.WriteLine("Código : " + producto.Codigo);
                Console.WriteLine("Producto: " + producto.Nombre);
                Console.WriteLine("Precio : S/ " + producto.Precio.ToString("0.00"));
                Console.WriteLine("Stock  : " + producto.Stock);
                Console.WriteLine("----------------------------------------------");
            }
        }

        public static Producto BuscarProductoPorCodigo(string codigo)
        {
            foreach (Producto producto in productos)
            {
                if (producto.Codigo.ToUpper() == codigo.ToUpper())
                {
                    return producto;
                }
            }

            return null;
        }

        public static Producto SeleccionarProductoParaVenta()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("          BÚSQUEDA DE PRODUCTO");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Puede buscar por código o palabra clave.");
            Console.WriteLine("Ejemplos: P001, arroz, costeño, primor, gloria");
            Console.WriteLine("----------------------------------------");
            Console.Write("Ingrese código o palabra clave: ");

            string busqueda = (Console.ReadLine() ?? "").ToLower();

            if (busqueda == "")
            {
                Console.WriteLine("Debe ingresar un código o palabra clave.");
                return null;
            }

            foreach (Producto producto in productos)
            {
                if (producto.Codigo.ToLower() == busqueda)
                {
                    return producto;
                }
            }

            List<Producto> coincidencias = new List<Producto>();

            foreach (Producto producto in productos)
            {
                if (producto.Codigo.ToLower().Contains(busqueda) ||
                    producto.Nombre.ToLower().Contains(busqueda))
                {
                    coincidencias.Add(producto);
                }
            }

            if (coincidencias.Count == 0)
            {
                Console.WriteLine("No se encontraron productos con ese dato.");
                return null;
            }

            if (coincidencias.Count == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Producto encontrado:");
                Console.WriteLine(coincidencias[0].Codigo + " - " + coincidencias[0].Nombre + " - S/ " + coincidencias[0].Precio.ToString("0.00") + " - Stock: " + coincidencias[0].Stock);
                return coincidencias[0];
            }

            Console.WriteLine();
            Console.WriteLine("Productos encontrados:");

            for (int i = 0; i < coincidencias.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + coincidencias[i].Codigo + " - " + coincidencias[i].Nombre + " - S/ " + coincidencias[i].Precio.ToString("0.00") + " - Stock: " + coincidencias[i].Stock);
            }

            int opcion = 0;

            Console.Write("Seleccione el producto (ingrese el número de la lista): ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > coincidencias.Count)
            {
                Console.Write("Opción inválida. Ingrese el número del producto que desea seleccionar: ");
            }

            return coincidencias[opcion - 1];
        }

        static void AumentarStock()
        {
            MostrarInventario();

            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine();

            Producto producto = BuscarProductoPorCodigo(codigo);

            if (producto == null)
            {
                Console.WriteLine("No se encontró un producto con ese código.");
                return;
            }

            int cantidad = 0;

            Console.Write("Ingrese la cantidad que desea agregar al stock: ");

            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.Write("Ingrese una cantidad válida mayor a 0: ");
            }

            producto.Stock += cantidad;

            Console.WriteLine();
            Console.WriteLine("Stock actualizado correctamente.");
            Console.WriteLine("Producto: " + producto.Nombre);
            Console.WriteLine("Nuevo stock: " + producto.Stock);
        }

        static void AgregarProducto()
        {
            string nuevoCodigo = "P" + (productos.Count + 1).ToString("000");

            Console.Write("Ingrese el nombre del nuevo producto: ");
            string nombre = Console.ReadLine();

            while (nombre == "")
            {
                Console.Write("Ingrese un nombre válido: ");
                nombre = Console.ReadLine();
            }

            double precio = 0;

            Console.Write("Ingrese el precio unitario: ");

            while (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.Write("Ingrese un precio válido mayor a 0: ");
            }

            int stock = 0;

            Console.Write("Ingrese el stock inicial: ");

            while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
            {
                Console.Write("Ingrese un stock válido: ");
            }

            Producto nuevoProducto = new Producto();
            nuevoProducto.Codigo = nuevoCodigo;
            nuevoProducto.Nombre = nombre;
            nuevoProducto.Precio = precio;
            nuevoProducto.Stock = stock;

            productos.Add(nuevoProducto);

            Console.WriteLine();
            Console.WriteLine("Producto agregado correctamente al inventario.");
            Console.WriteLine("Código : " + nuevoProducto.Codigo);
            Console.WriteLine("Nombre : " + nuevoProducto.Nombre);
            Console.WriteLine("Precio : S/ " + nuevoProducto.Precio.ToString("0.00"));
            Console.WriteLine("Stock  : " + nuevoProducto.Stock);
        }
    }
}

