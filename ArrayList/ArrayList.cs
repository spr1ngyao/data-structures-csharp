namespace ArrayList;

public class ArrayList<T>
{
    private T[] _storage;
    private int _size;
    private int _capacity;

    public ArrayList()
    {
        _capacity = 4;
        _storage = new T[_capacity];
        _size = 0;
    }

    public ArrayList(T[] items)
    {
        if (items == null)
            throw new ArgumentNullException("Массив не может быть null");
        _capacity = items.Length;
        _size = items.Length;
        _storage = new T[_capacity];

        for (int i = 0; i < items.Length; i++)
        {
            _storage[i] = items[i];
        }
    }

    public void Add(T data)
    {
        if (_size >= _capacity)
        {
            T[] oldStorage = _storage;
            _capacity *= 2;
            _storage = new T[_capacity];
            for (int i = 0; i < oldStorage.Length; i++)
            {
                _storage[i] = oldStorage[i];
            }
        }

        _storage[_size] = data;
        _size++;
    }

    public T Get(int index)
    {
        if (index < 0 || index > _size - 1)
        {
            Console.WriteLine("Индекс выходит за границы списка.");
            return default;
        }

        return _storage[index];
    }

    public void Set(int index, T data)
    {
        if (index < 0 || index > _size - 1)
        {
            Console.WriteLine("Индекс выходит за границы списка.");
            return;
        }

        _storage[index] = data;
    }

    public void Insert(int index, T data)
    {
        if (index < 0 || index > _size)
        {
            Console.WriteLine("Индекс выходит за границы списка.");
            return;
        }

        if (_size >= _capacity)
        {
            T[] oldStorage = _storage;
            _capacity *= 2;
            _storage = new T[_capacity];
            for (int i = 0; i < oldStorage.Length; i++)
            {
                _storage[i] = oldStorage[i];
            }
        }

        if (index == _size)
        {
            Add(data);
            return;
        }

        for (int i = _size - 1; i != index; i--)
        {
            _storage[i + 1] = _storage[i];
        }

        _storage[index] = data;
        _size++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _size - 1)
        {
            Console.WriteLine("Индекс выходит за границы массива.");
            return;
        }

        for (int i = index; i != _size - 1; i++)
        {
            _storage[i] = _storage[i + 1];
        }

        _storage[_size - 1] = default;
        _size--;
    }

    public void Remove(T data)
    {
        if (_size == 0)
        {
            Console.WriteLine("Массив уже пуст.");
            return;
        }

        for (int i = 0; i != _size; i++)
        {
            if (object.Equals(_storage[i], data))
            {
                RemoveAt(i);
                return;
            }
        }
    }

    public int IndexOf(T data)
    {
        for (int i = 0; i < _size; i++)
        {
            if (object.Equals(_storage[i], data))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T data)
    {
        return IndexOf(data) != -1;
    }

    public int Size()
    {
        return _size;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _storage[i] = default;
        }
        
        _size = 0;
    }

    public void Reverse()
    {
        T temp;
        
        if (_size == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        if (_size == 1)
        {
            return;
        }

        int i = 0;
        int j = _size - 1;
        while (i < j)
        {
            temp = _storage[i];
            _storage[i] = _storage[j];
            _storage[j] = temp;
            i++;
            j--;
        }
    }

    public void Print()
    {
        Console.Write("[ ");

        for (int i = 0; i < _size; i++)
        {
            Console.Write(_storage[i] + " ");
        }

        Console.WriteLine("]");
    }
}