namespace LinkedListWithoutTail;

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>(3);
        LinkedList<int> list2 = new LinkedList<int>();

        list.AddFirst(1);
        list.AddIndex(2, 1);
        list.Print();
        list2.Print();
        Console.WriteLine("--------------------------------");

        list.Reverse();
        list.Print();
        list2.Print();
    }
}