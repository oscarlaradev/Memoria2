namespace ArbolBinario;

public class ArbolBinario
{
    public Nodo Raiz;

        // --- INSERCIÓN BÁSICA ---
        public Nodo Insertar(Nodo nodo, int valor)
        {
            // PASO 1: Si llegamos a un espacio vacío, ahí colocamos el nuevo número.
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            // PASO 2: Si el número es menor que el nodo actual, lo mandamos por la rama izquierda.
            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
            }
            // PASO 3: Si el número es mayor, lo mandamos por la rama derecha.
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = Insertar(nodo.Derecho, valor);
            }
            // (Si el número es exactamente igual, no lo insertamos para evitar duplicados)

            // Devolvemos el nodo para que las ramas no se desconecten
            return nodo; 
        }

        // --- MÉTODOS PARA IMPRIMIR ---

        // Preorden: Primero la Raíz, luego Izquierda, luego Derecha
        public void ImprimirPreorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                ImprimirPreorden(nodo.Izquierdo);
                ImprimirPreorden(nodo.Derecho);
            }
        }

        // Inorden: Izquierda, Raíz, Derecha (Imprime los números de menor a mayor)
        public void ImprimirInorden(Nodo nodo)
        {
            if (nodo != null)
            {
                ImprimirInorden(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                ImprimirInorden(nodo.Derecho);
            }
        }

        // Postorden: Izquierda, Derecha, Raíz al final
        public void ImprimirPostorden(Nodo nodo)
        {
            if (nodo != null)
            {
                ImprimirPostorden(nodo.Izquierdo);
                ImprimirPostorden(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }
}