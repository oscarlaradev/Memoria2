namespace ArbolBinario;

public class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    // Constructor: se ejecuta cuando creamos un nodo nuevo
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}