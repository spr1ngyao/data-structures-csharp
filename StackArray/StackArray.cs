namespace StackArray;

public class StackArray<T>
{
    private T[] _storage;
    private int _size;
    private int _capacity;

    public StackArray()
    {
        _capacity = 4;
        _storage = new T[_capacity];
        _size = 0;
    }

    public StackArray(T[] items)
    {
        if (items.Length == null)
        {
            throw new ArgumentException("Массив не может быть null.");
        }
            
        _capacity = items.Length;
        _size = items.Length;
        _storage = new T[_capacity];

        for (int i = 0; i < items.Length; i++)
        {
            _storage[i] = items[i];
        }
    }

    public void Push(T item)
    {
        if (_size == _capacity)
        {
            T[] temp = _storage;
            _capacity *= 2;
            _storage = new T[_capacity];
            for (int i = 0; i < _size; i++)
            {
                _storage[i] = temp[i];
            }
        }
        
        _storage[_size] = item;
        _size++;
    }

    public T Pop()
    {
        T temp = _storage[_size - 1];
        _storage[_size - 1] = default;
        _size--;
        return temp;
    }
    
    public T Peek()
    {
        return _storage[_size - 1];
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }
}