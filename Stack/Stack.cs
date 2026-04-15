namespace Stack;

public class Stack<T>
{
    private Node<T> _head { get; set; }

    public Stack(T data)
    {
        _head = new Node<T>(data);
    }

    public Stack()
    {
        _head = null;
    }

    public void Push(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            return;
        }

        newNode.Next = _head;
        _head = newNode;
    }

    public T Pop()
    {
        Node<T> temp = _head;
        
        if (_head == null)
        {
            throw new NullReferenceException();
        }
        
        _head = _head.Next;
        return temp.Data;
    }

    public T Peek()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }
        
        return _head.Data;
    }

    public void Clear()
    {
        _head = null;
    }

    public bool Contains(T data)
    {
        Node<T> pointer =  _head;

        while (pointer != null)
        {
            if (object.Equals(pointer.Data, data))
            {
                return true;
            }
            
            pointer = pointer.Next;
        }
        
        return false;
    }

    public int Count()
    {
        Node<T> pointer = _head;

        int count = 0;
        while (pointer != null)
        {
            count++;
            pointer = pointer.Next;
        }
        
        return count;
    }
    
    public void Print()
    {
        Node<T> pointer = _head;
        
        Console.Write("[ ");

        if (_head == null)
        {
            Console.WriteLine("]");
            return;
        }

        while (pointer != null)
        {
            Console.Write(pointer.Data + " ");
            pointer = pointer.Next;
        }

        Console.WriteLine("]");
    }
}