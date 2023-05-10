using System;
using bsbo_011215_22;

internal class Application
{
    // Сортировка Стэка на массивах
    static void QueueSort()
    {
        int n = 5;

        Queue queue = new Queue(); 
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(rnd.Next(0, 100));
        }

        queue.Print();
        queue.Dequeue();
        queue.Print();

        /*
        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (queue[j] > queue[j + 1])
                {
                    (queue[j], queue[j + 1]) = (queue[j + 1], queue[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        queue.Print();
        */

    }

    static void Main(string[] args)
    {
        QueueSort();
    }
}

