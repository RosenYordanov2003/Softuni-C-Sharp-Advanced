using Collection_Hierarchy.Collections;
using System;
using System.Text;

namespace Collection_Hierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            StringBuilder addCollectionAddResult = new StringBuilder();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            StringBuilder addRemoveCollectionAddResult = new StringBuilder();
            MyList myList = new MyList();
            StringBuilder myListAddResult = new StringBuilder();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in input)
            {
                addCollectionAddResult.Append($"{addCollection.Add(item)} ");
                addRemoveCollectionAddResult.Append($"{addRemoveCollection.Add(item)} ");
                myListAddResult.Append($"{myList.Add(item)} ");
            }
            Console.WriteLine(addCollectionAddResult.ToString());
            Console.WriteLine(addRemoveCollectionAddResult.ToString());
            Console.WriteLine(myListAddResult.ToString());
            StringBuilder addRemoveColectonRemoveMethod = new StringBuilder();
            StringBuilder myListRemoveMethod = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                addRemoveColectonRemoveMethod.Append($"{addRemoveCollection.Remove()} ");
                myListRemoveMethod.Append($"{myList.Remove()} ");
            }
            Console.WriteLine(addRemoveColectonRemoveMethod.ToString());
            Console.WriteLine(myListRemoveMethod.ToString());
        }
    }
}
