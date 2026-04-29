namespace ArbolAVL;

public class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;
    public int Altura; // Nos ayuda a saber si el árbol está chueco (desbalanceado)

    // Constructor: se ejecuta cuando creamos un nodo nuevo
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
        Altura = 1; // Un nodo nuevo siempre empieza con una altura de 1
    }
}