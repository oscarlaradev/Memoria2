namespace ArbolAVL;

public class ArbolAVL
{
    public Nodo Raiz;

        // Función auxiliar para obtener la altura sin errores (por si el nodo está vacío)
        public int ObtenerAltura(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return nodo.Altura;
        }

        // Función básica para saber qué número es mayor (sin atajos matemáticos avanzados)
        public int ObtenerMayor(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        // Calcula la diferencia de altura entre el lado izquierdo y el derecho
        public int ObtenerBalance(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }

        // --- ROTACIONES PARA MANTENER EL EQUILIBRIO ---

        // Rotación a la Derecha (Se usa cuando hay mucho "peso" a la izquierda)
        public Nodo RotacionDerecha(Nodo y)
        {
            Nodo x = y.Izquierdo;
            Nodo T2 = x.Derecho;

            // Realizamos el giro
            x.Derecho = y;
            y.Izquierdo = T2;

            // Actualizamos las alturas de los nodos que se movieron
            y.Altura = ObtenerMayor(ObtenerAltura(y.Izquierdo), ObtenerAltura(y.Derecho)) + 1;
            x.Altura = ObtenerMayor(ObtenerAltura(x.Izquierdo), ObtenerAltura(x.Derecho)) + 1;

            // 'x' es la nueva "cabeza" de esta sección del árbol
            return x;
        }

        // Rotación a la Izquierda (Se usa cuando hay mucho "peso" a la derecha)
        public Nodo RotacionIzquierda(Nodo x)
        {
            Nodo y = x.Derecho;
            Nodo T2 = y.Izquierdo;

            // Realizamos el giro
            y.Izquierdo = x;
            x.Derecho = T2;

            // Actualizamos alturas
            x.Altura = ObtenerMayor(ObtenerAltura(x.Izquierdo), ObtenerAltura(x.Derecho)) + 1;
            y.Altura = ObtenerMayor(ObtenerAltura(y.Izquierdo), ObtenerAltura(y.Derecho)) + 1;

            return y;
        }

        // --- INSERCIÓN PRINCIPAL ---
        public Nodo Insertar(Nodo nodo, int valor)
        {
            // PASO 1: Inserción normal. Buscamos el lugar vacío como en cualquier árbol binario.
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = Insertar(nodo.Derecho, valor);
            }
            else
            {
                // Si el número es igual, no hacemos nada (no se permiten duplicados)
                return nodo; 
            }

            // PASO 2: Actualizamos la altura del nodo por donde acabamos de pasar.
            nodo.Altura = 1 + ObtenerMayor(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho));

            // PASO 3: Revisamos si este nodo se desbalanceó (si la diferencia de altura es más de 1 o menos de -1)
            int balance = ObtenerBalance(nodo);

            // PASO 4: Si se desbalanceó, aplicamos las rotaciones (Hay 4 casos posibles)

            // Caso 1: Izquierda - Izquierda
            if (balance > 1 && valor < nodo.Izquierdo.Valor)
            {
                return RotacionDerecha(nodo);
            }

            // Caso 2: Derecha - Derecha
            if (balance < -1 && valor > nodo.Derecho.Valor)
            {
                return RotacionIzquierda(nodo);
            }

            // Caso 3: Izquierda - Derecha (Requiere rotación doble)
            if (balance > 1 && valor > nodo.Izquierdo.Valor)
            {
                nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
                return RotacionDerecha(nodo);
            }

            // Caso 4: Derecha - Izquierda (Requiere rotación doble)
            if (balance < -1 && valor < nodo.Derecho.Valor)
            {
                nodo.Derecho = RotacionDerecha(nodo.Derecho);
                return RotacionIzquierda(nodo);
            }

            // Devolvemos el nodo tal cual si no hubo que balancearlo
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

        // Inorden: Izquierda, Raíz, Derecha (¡Este recorrido imprime los números de menor a mayor!)
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