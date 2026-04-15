namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>(1);
        stack.Push(2);
        stack.Push(3);
        stack.Print();

        // Console.WriteLine("Pop: " + stack.Pop());
        
        // stack.Clear();

        // Console.WriteLine(stack.Contains(2));
        // Console.WriteLine(stack.Contains(20));
        
        // Console.WriteLine(stack.Peek());
        
        Stack<int> stack2 = new Stack<int>();
        stack.Push(10);

        // Console.WriteLine(stack2.Count());
        // Console.WriteLine(stack.Count());
    }
}