using System.ComponentModel;
using System.Drawing;

namespace CustomList;

class Program
{
    static void Main(string[] args)
    {
        CustomList<int> list1 = new CustomList<int>(1);
        CustomList<int> list2 = new CustomList<int>();
        
        list1.AddLast(3);
        
        list1.AddFirst(0);
        list1.AddFirst(10);
        
        list1.AddIndex(4, 5);
        list1.Print();
        
        list1.Reverse();
        list1.Print(); 
    }
}