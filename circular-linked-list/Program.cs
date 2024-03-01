using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public static int LastParticipant(int N, int k, int l)
    {
        var lis = new MyCircularLinkedList<int>();
        for (int i = 1; i <= N; i++)
        {
            lis.Add(i);
        }

        var currentNumber = 1;
        var droppedOut = 0;
        foreach (int tag in lis)
        {
            if (currentNumber % k == 0)
            {
                droppedOut++;
                lis.Remove(tag);
            }
            if (droppedOut == l)
            {
                N++;
                droppedOut = 0;
                lis.Add(N);
            }

            if (lis.Count == 1)
            {
                break;
            }

            currentNumber++;
        }

        foreach (int i in lis)
        {
            return i;
        }

        return -1;
    }
}
