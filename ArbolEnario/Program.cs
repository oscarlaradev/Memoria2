namespace ArbolEnario;

class Program
{
    static void Main(string[] args)
    {
        // Creamos un árbol estático con capacidad máxima de 100 números
            ArbolEnario miArbol = new ArbolEnario(100);
            bool salir = false;

            while (salir == false)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("  MENÚ ÁRBOL ENARIO (ESTÁTICO N=3)");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Insertar un número");
                Console.WriteLine("2. Imprimir en Preorden");
                Console.WriteLine("3. Imprimir en Postorden");
                Console.WriteLine("4. Imprimir en Inorden");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");

                string entradaOpcion = Console.ReadLine();
                int opcion = 0;

                try
                {
                    opcion = int.Parse(entradaOpcion);
                }
                catch
                {
                    Console.WriteLine("\n Por favor, ingresa un número válido del 1 al 5.");
                    continue; 
                }

                if (opcion == 1)
                {
                    Console.Write("Ingresa el número entero que quieres insertar: ");
                    string entradaNumero = Console.ReadLine();
                    try
                    {
                        int numeroAInsertar = int.Parse(entradaNumero);
                        miArbol.Insertar(numeroAInsertar);
                        Console.WriteLine("\n Número " + numeroAInsertar + " insertado en el arreglo estático.");
                    }
                    catch
                    {
                        Console.WriteLine("\n Error: Solo se permiten números enteros.");
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("\n--- Recorrido Preorden ---");
                    // Siempre empezamos desde el índice 0 (la Raíz)
                    miArbol.ImprimirPreorden(0);
                    Console.WriteLine(); 
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("\n--- Recorrido Postorden ---");
                    miArbol.ImprimirPostorden(0);
                    Console.WriteLine();
                }
                else if (opcion == 4)
                {
                    Console.WriteLine("\n--- Recorrido Inorden ---");
                    miArbol.ImprimirInorden(0);
                    Console.WriteLine();
                }
                else if (opcion == 5)
                {
                    salir = true;
                    Console.WriteLine("\nSaliendo del programa.");
                }
                else
                {
                    Console.WriteLine("\n Opción incorrecta. Intenta de nuevo.");
                }
            }
        }
    }