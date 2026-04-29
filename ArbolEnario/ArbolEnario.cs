namespace ArbolEnario;

public class ArbolEnario
{
    // Memoria estática: Un arreglo con un límite definido desde el inicio.
        public int[] Memoria;
        public int TotalNodos;
        public int MaximoNodos;

        // Constructor: Preparamos el arreglo
        public ArbolEnario(int tamañoMaximo)
        {
            MaximoNodos = tamañoMaximo;
            Memoria = new int[MaximoNodos];
            TotalNodos = 0; // Empezamos en cero
        }

        // --- INSERCIÓN EN ARREGLO ---
        // Como no es un árbol "de búsqueda", simplemente llenamos los espacios de izquierda a derecha.
        public void Insertar(int valor)
        {
            if (TotalNodos < MaximoNodos)
            {
                // Metemos el número en el siguiente espacio vacío del arreglo
                Memoria[TotalNodos] = valor;
                TotalNodos = TotalNodos + 1;
            }
            else
            {
                Console.WriteLine("\nError: El árbol está lleno. Se agotó la memoria estática.");
            }
        }

        // --- MÉTODOS PARA IMPRIMIR ---
        // Fórmulas matemáticas para un árbol de n=3 (Ternario):
        // Si estamos en la posición "i":
        // Su hijo Izquierdo está en la posición: (3 * i) + 1
        // Su hijo Central está en la posición:   (3 * i) + 2
        // Su hijo Derecho está en la posición:   (3 * i) + 3

        public void ImprimirPreorden(int indiceActual)
        {
            // Verificamos que el índice no se salga de los números que hemos ingresado
            if (indiceActual < TotalNodos)
            {
                // 1. Raíz (imprimimos primero)
                Console.Write(Memoria[indiceActual] + " ");

                // 2. Recorremos los 3 hijos
                ImprimirPreorden((3 * indiceActual) + 1); // Izquierdo
                ImprimirPreorden((3 * indiceActual) + 2); // Central
                ImprimirPreorden((3 * indiceActual) + 3); // Derecho
            }
        }

        public void ImprimirInorden(int indiceActual)
        {
            if (indiceActual < TotalNodos)
            {
                // 1. Hijo Izquierdo
                ImprimirInorden((3 * indiceActual) + 1);
                
                // 2. Raíz (imprimimos en medio)
                Console.Write(Memoria[indiceActual] + " ");

                // 3. Hijos Central y Derecho
                ImprimirInorden((3 * indiceActual) + 2);
                ImprimirInorden((3 * indiceActual) + 3);
            }
        }

        public void ImprimirPostorden(int indiceActual)
        {
            if (indiceActual < TotalNodos)
            {
                // 1. Recorremos los 3 hijos primero
                ImprimirPostorden((3 * indiceActual) + 1); // Izquierdo
                ImprimirPostorden((3 * indiceActual) + 2); // Central
                ImprimirPostorden((3 * indiceActual) + 3); // Derecho

                // 2. Al final imprimimos la Raíz
                Console.Write(Memoria[indiceActual] + " ");
            }
        }
}