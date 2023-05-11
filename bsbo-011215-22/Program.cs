using System;
using bsbo_011215_22;

internal class Application
{
    static void Main(string[] args)
    {
        int n = 5; // размер сортируемого стэка.
        Queue queue = new Queue();

        // Заполнение очереди n случайными элементами
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(rnd.Next(0, 100));
        }

        Console.Write("Очередь до сортировки: ");
        queue.Print();
        //queue.Print();

        queue.QueueSort();
        
        Console.Write("Очередь после сортировки: ");
        queue.Print();
    }
    public static Queue tmp = new Queue();
}

