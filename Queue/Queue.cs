namespace Queue;

public class Queue<T>
{
    private Node<T> _head { get; set; }
    private Node<T> _tail { get; set; }

    public Queue(T data)
    {
        Node<T> newNode = new Node<T>(data);
        _head = newNode;
        _tail = newNode;
    }

    public Queue()
    {
        _head = _tail = null;
    }

    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);
        
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }

    public T Dequeue()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }
        
        Node<T> temp = _head;
        
        _head = _head.Next;
        
        if (_head == null)
        {
            _tail = null;
        }
        else
        {
            _head.Prev = null;
        }
        
        return temp.Data;
    }

    public T Peek()
    {
        if (_head == null)
        {
            throw  new InvalidOperationException("Очередь пуста.");
        }
        
        return _head.Data;
    }
}