namespace ArrayList;

class Program
{
    static void Main(string[] args)
    {
        ArrayList<int> arr1 = new ArrayList<int>();
        ArrayList<int> arr2 = new ArrayList<int>(new int[] { 1, 2});
        
        arr1.Print();
        arr2.Print();
        Console.WriteLine();
        
        arr1.Add(1);
        arr2.Add(2);
        arr2.Add(3);
        arr2.Add(5);
        
        arr1.Print();
        arr2.Print();
    }
}