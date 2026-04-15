namespace Stack;

public class Node<T>
{
    public T Data;
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
    }
}