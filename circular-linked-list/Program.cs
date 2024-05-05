using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        var cirlce = new MyCircularLinkedList<int>();
        cirlce.Add(1);
        cirlce.Add(2);
        cirlce.Add(3);
        cirlce.Add(4);
        cirlce.Add(5);

        int count = 0;
        foreach (var item in cirlce)
        {
            Console.WriteLine(item);
            count++;

            if (count == 15) break;
        }
    }
}
