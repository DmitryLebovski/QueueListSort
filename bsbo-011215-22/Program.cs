using System;
using bsbo_011215_22;

internal class Application
{
    static void Main(string[] args)
    {
        int n = 5;
        Queue queue = new Queue(n);

        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            queue.Add(rnd.Next(0, 100));
        }

        queue.Print();
        queue.Delete();
        queue.Print();

        queue.QueueSort();

        queue.Print();

    }
}

