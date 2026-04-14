using System.Globalization;
using System.Reflection;

namespace LinkedListWithoutTail;

public class LinkedList<T>
{
    public Node<T> _head { get; set; }

    public LinkedList(T data)
    {
        if (_head == null)
        {
            Node<T> newNode = new Node<T>(data);
            _head = newNode;
        }
    }

    public LinkedList()
    {
        _head = null;
    }

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _head.Prev = null;
            _head.Next = null;
            return;
        }

        newNode.Next = _head;
        _head.Prev = newNode;
        _head = newNode;
        _head.Prev = null;
    }

    public void AddIndex(T data, int index)
    {
        Node<T> newNode = new Node<T>(data);
        Node<T> pointer = _head;

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

        if (_head == null)
        {
            Console.WriteLine("Индекс указан некорректно.");
            return;
        }

        for (int i = 0; i < index; i++)
        {
            if (pointer == null)
            {
                Console.WriteLine("Индекс вышел за конечные границы списка.");
                return;
            }

            pointer = pointer.Next;
        }

        if (pointer == null)
        {
            AddLast(data);
            return;
        }

        newNode.Prev = pointer.Prev;
        pointer.Prev.Next = newNode;
        newNode.Next = pointer;
        pointer.Prev = newNode;
    }

    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        Node<T> pointer = _head;

        if (_head == null)
        {
            _head = newNode;
            _head.Prev = null;
            _head.Next = null;
            return;
        }

        while (pointer.Next != null)
        {
            pointer = pointer.Next;
        }

        pointer.Next = newNode;
        newNode.Prev = pointer;
        newNode.Next = null;
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
            return;
        }

        _head = _head.Next;
        _head.Prev = null;
    }

    public void RemoveAt(int index)
    {
        Node<T> pointer = _head;

        if (_head == null)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        if (index == 0)
        {
            RemoveFirst();
            return;
        }

        if (index < 0)
        {
            Console.WriteLine("Индекс не может быть отрицательным.");
            return;
        }

        for (int i = 0; i < index; i++)
        {
            if (pointer == null)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                return;
            }

            pointer = pointer.Next;
        }

        if (pointer == null)
        {
            Console.WriteLine("Индекс выходит за границы списка.");
            return;
        }

        if (pointer.Next == null)
        {
            pointer.Prev.Next = null;
            return;
        }

        pointer.Prev.Next = pointer.Next;
        pointer.Next.Prev = pointer.Prev;
    }

    public void RemoveLast()
    {
        Node<T> pointer = _head;

        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        if (_head.Next == null)
        {
            _head = null;
            return;
        }

        while (pointer.Next != null)
        {
            pointer = pointer.Next;
        }

        pointer.Prev.Next = null;
    }

    public void RemoveRange(int index)
    {
        Node<T> pointer = _head;

        if (index == 0)
        {
            _head = null;
            return;
        }

        if (index < 0)
        {
            Console.WriteLine("Индекс списка не может быть отрицательным.");
            return;
        }

        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        for (int i = 0; i < index; i++)
        {
            pointer = pointer.Next;

            if (pointer == null)
            {
                Console.WriteLine("Индекс  выходит за границы списка.");
                return;
            }
        }

        pointer.Prev.Next = null;
    }

    public void RemoveAllOccurences(T data)
    {
        Node<T> pointer = _head;

        if (_head == null)
        {
            Console.WriteLine("Список уже пуст.");
            return;
        }

        while (pointer != null)
        {
            if (object.Equals(pointer.Data, data))
            {
                if (pointer == _head && _head.Next == null)
                {
                    _head = null;
                    return;
                }
                else if (pointer == _head)
                {
                    _head = pointer.Next;
                    if (_head != null)
                    {
                        _head.Prev = null;
                    }

                    pointer = _head;
                    continue;
                }

                if (pointer.Next == null)
                {
                    pointer.Prev.Next = null;
                    return;
                }

                pointer.Prev.Next = pointer.Next;
                pointer.Next.Prev = pointer.Prev;
                pointer = pointer.Next;
            }
        }
    }

    public bool Contains(T data)
    {
        Node<T> pointer = _head;

        if (_head == null)
        {
            Console.WriteLine("Список пуст.");
            return false;
        }
        
        while (object.Equals(pointer.Data, data) == false)
        {
            pointer = pointer.Next;

            if (pointer == null)
            {
                return false;
            }
        }

        return true;
    }

    public void Clear()
    {
        _head = null;
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

    public void FindAllIndices(T data)
    {
        Node<T> pointer = _head;
        int index = 0;

        Console.WriteLine("Индексы, на которых встречается данное значение:\n");

        while (pointer != null)
        {
            if (object.Equals(pointer.Data, data))
            {
                Console.Write(index + " ");
            }

            pointer = pointer.Next;
            index++;
        }
    }

    public void Reverse() // Шизо-говно код. Как кот Шрёдингера, жив и мёртв наполовину.
    {
        Node<T> pointer = _head;

        if (_head == null)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        if (_head.Next == null)
        {
            return;
        }
        
        pointer = pointer.Next;
        pointer.Prev.Next = null;
        pointer.Prev = null;
        
        while (pointer != null)
        {
            pointer = pointer.Next;
            if (pointer == null)
            {
                return;
            }
            pointer.Prev.Next = _head;
            _head.Prev = pointer.Prev;
            _head = pointer.Prev;
            pointer.Prev = null;
            if (pointer.Next == null)
            {
                pointer.Next = _head;
                _head.Prev = pointer;
                _head = pointer;
            }
        }
    }

    public void Print()
    {
        Node<T> pointer = _head;

        Console.Write("[ ");

        while (pointer != null)
        {
            Console.Write(pointer.Data.ToString() + " ");
            pointer = pointer.Next;
        }

        Console.WriteLine("]");
    }
}