namespace Queue;

public class Node<T>
{
    public Node<T> Next;
    public Node<T> Prev;
    public T Data { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}