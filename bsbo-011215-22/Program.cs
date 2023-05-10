using System;
using bsbo_011215_22;

internal class Application
{
    static void Main(string[] args)
    {
        Queue queue = new Queue();

        Random rnd = new Random();

        int n = 5;
        for (int i = 0; i < n; i++)
        {
            queue.Add(rnd.Next(0, 100));
        }

        queue.Print();
        //queue.Delete();
        //queue.Print();

        queue.QueueSort();
        queue.Print();
    }
    public static Queue tmp = new Queue();
}

