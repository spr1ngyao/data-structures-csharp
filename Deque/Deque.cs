namespace Deque;

public class Deque<T>
{
    private Node<T> _head { get; set; }
    private Node<T> _tail { get; set; }
    
    public Deque(T data)
    {
        Node<T> newNode = new Node<T>(data);
        _head = newNode;
        _tail = newNode;
    }

    public Deque()
    {
        _head = _tail = null;
    }

    public void PushFront(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        
        _head.Prev = newNode;
        newNode.Next = _head;
        _head = newNode;
    }
    
    public void PushBack(T data)
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

    public T PopFront()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Дек пуст.");
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

    public T PopBack()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Дек пуст.");
        }
        
        Node<T> temp = _tail;
        
        _tail = _tail.Prev;
        
        if (_tail == null)
        {
            _head = null;
        }
        else
        {
            _tail.Next = null;
        }
        
        return temp.Data;
    }

    public T PeekFront()
    {
        if (_head == null)
        {
            throw  new InvalidOperationException("Дек пуст.");
        }
        
        return _head.Data;
    }

    public T PeekBack()
    {
        if (_head == null)
        {
            throw  new InvalidOperationException("Дек пуст.");
        }
        
        return _tail.Data;
    }
}