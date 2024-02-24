public class Program
{
    public static void Main(string[] args)
    {
        var fio = new MyCircularLinkedList<string>("Danis");

        fio.AddLast("Ilgamovich");
        foreach (var x in fio)
        {
            Console.WriteLine(x);
        }

        fio.AddFirst("Shakirov");
        foreach (var x in fio)
        {
            Console.WriteLine(x);
        }
    }
}
