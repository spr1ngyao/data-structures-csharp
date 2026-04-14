namespace CustomListWithTail;

public class CustomListWithTail<T>
{
    private Node<T> _head;
    private Node<T> _tail;
    
    public CustomListWithTail(T data) 
    {
        if (_head == null)
        {
            Node<T> newNode = new Node<T>(data);
            _head = newNode;
        }
    }

    public CustomListWithTail()
    {
        _head = null;
    }

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        newNode.Next = _head;
        _head = newNode;
    }

    public void AddIndex(int index, T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (index < 0)
        {
            Console.WriteLine("Индекс не может быть отрицательным.");
            return;
        }
        
        if (index == 0)
        {
            AddFirst(data);
            return;
        }

        Node<T> pointer = _head;
        for(int i = 0; i < index - 1; i++)
        {
            if (pointer.Next == null)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                return;
            }
            pointer = pointer.Next;
        }
        
        newNode.Next = pointer.Next;
        pointer.Next = newNode;
    }
    
    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        
        _tail.Next = newNode;
        _tail = newNode;
    }

    public void AddRange(T[] data)
    {
            for (int i = 0; i < data.Length; i++)
            {
                AddLast(data[i]);
            }
    }

    public void RemoveFirst()
    {
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        if (_head.Next == null)
        {
            _head = null;
            _tail = null;
            return;
        }
        
        _head = _head.Next;
    }

    public void RemoveAt(int index)
    {
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        if (index == 0)
        {
            RemoveFirst();
            return;
        }

        if (index < 0)
        {
            Console.WriteLine("Индекс не может быть отрицательным значением.");
            return;
        }
        
        Node<T> pointer = _head;
        for (int i = 0; i < index - 1; i++)
        {
            if (pointer.Next == null)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                return;
            }
            pointer = pointer.Next;
        }
        pointer.Next = pointer.Next.Next;
    }

    public void RemoveLast()
    {
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        if (_head.Next == null)
        {
            _head = null;
            _tail = null;
            return;
        }

        Node<T> pointer = _head;

        while (pointer.Next != _tail)
        {
            pointer = pointer.Next;
        }

        pointer.Next = null;
        _tail = pointer;
    }

    public void RemoveValue(T data)
    {
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
        }
        
        Node<T> pointer = _head;
        while (pointer.Next != null)
        {
            if (object.Equals(pointer.Next.Data, data))
            {
                pointer.Next = pointer.Next.Next; 
            }
            else
            {
                pointer = pointer.Next;
            }
        }
    }

    public void RemoveValue(T data, int count)
    {
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
        }
        
        Node<T> pointer = _head;
        int i = 0;
        while ((pointer.Next != null) && (i < count))
        {
            if (object.Equals(pointer.Next.Data, data))
            {
                pointer.Next = pointer.Next.Next; 
                i++;
            }
            else
            {
                pointer = pointer.Next;
            }
        }
    }
    
    public void RemoveRange(int index)
    {
        Node<T> pointer = _head;
        
        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }
        
        for (int i = 0; i < index - 1; i++)
        {
            pointer = pointer.Next;
            
            if (pointer.Next == null)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                return;
            }
        }

        pointer.Next = null;
    }

    public bool Contains(T data)
    {
        Node<T> pointer = _head;

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

    public void Clear()
    {
        _head = null;
        _tail = null;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }

    public int Size()
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

    public void Reverse()
    {
        Node<T> pointer = _head;
        Node<T> oldHead = _head;
        Node<T> prev = null;
        Node<T> next = null;

        while (pointer != null)
        {
            next = pointer.Next;
            pointer.Next = prev;
            prev = pointer;
            pointer = next;
        }
        
        _head = prev;
        _tail = oldHead;
    }
    
    public void Print()
    {
        if (_head == null)
        {
            Console.WriteLine("[ ]");
            return;
        }

        Node<T> pointer = _head;
        string result = "[ ";
        while (pointer != null)
        {
            result += pointer.Data.ToString() + " ";
            pointer = pointer.Next;
        }
        result += "]";
        
        Console.WriteLine(result);
    }
}