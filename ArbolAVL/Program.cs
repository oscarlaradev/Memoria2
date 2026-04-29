namespace ArbolAVL;

class Program
{
    static void Main(string[] args)
    {
      ArbolAVL miArbol = new ArbolAVL();
            bool salir = false;

            while (salir == false)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("    MENÚ DEL ÁRBOL AVL");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Insertar un número");
                Console.WriteLine("2. Imprimir en Preorden");
                Console.WriteLine("3. Imprimir en Postorden");
                Console.WriteLine("4. Imprimir en Inorden");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");

                string entradaOpcion = Console.ReadLine();
                int opcion = 0;

                // Intentamos convertir el texto a número de forma directa
                try
                {
                    opcion = int.Parse(entradaOpcion);
                }
                catch
                {
                    Console.WriteLine("\n[!] Por favor, ingresa un número válido del 1 al 5.");
                    continue; // Detiene esta vuelta del ciclo y regresa a mostrar el menú
                }

                // Usamos ifs simples en lugar de un switch complejo para mayor claridad
                if (opcion == 1)
                {
                    Console.Write("Ingresa el número entero que quieres insertar: ");
                    string entradaNumero = Console.ReadLine();
                    try
                    {
                        int numeroAInsertar = int.Parse(entradaNumero);
                        // Llamamos a la función Insertar y actualizamos la raíz
                        miArbol.Raiz = miArbol.Insertar(miArbol.Raiz, numeroAInsertar);
                        Console.WriteLine("\n[+] Número " + numeroAInsertar + " insertado y balanceado correctamente.");
                    }
                    catch
                    {
                        Console.WriteLine("\n[!] Error: Solo se permiten números enteros.");
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("\n--- Recorrido Preorden ---");
                    miArbol.ImprimirPreorden(miArbol.Raiz);
                    Console.WriteLine(); 
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("\n--- Recorrido Postorden ---");
                    miArbol.ImprimirPostorden(miArbol.Raiz);
                    Console.WriteLine();
                }
                else if (opcion == 4)
                {
                    Console.WriteLine("\n--- Recorrido Inorden ---");
                    miArbol.ImprimirInorden(miArbol.Raiz);
                    Console.WriteLine();
                }
                else if (opcion == 5)
                {
                    salir = true;
                    Console.WriteLine("\nSaliendo del programa. ¡Éxito con la entrega!");
                }
                else
                {
                    Console.WriteLine("\n[!] Opción incorrecta. Intenta de nuevo.");
                }
            }
        }
    }