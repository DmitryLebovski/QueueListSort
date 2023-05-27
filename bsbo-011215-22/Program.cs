using bsbo_011215_22;
using System.Diagnostics;

internal class Application
{
    static public long N_OP = 0;
    static public int n = 10; // начальный размер сортируемой очереди

    static void Main(string[] args)
    {
        var x = new Stopwatch();
        Random rnd = new Random();

        Queue queue = new Queue();
        // Заполнение очереди n случайными элементами
        for (int i = 0; i < 500; i++)
        {
            queue.Enqueue(rnd.Next(1000));
        }
        N_OP = 0;
        x.Restart();

        Console.WriteLine("До сортировки:");
        queue.Print();

        // Начало сортировки //
        // Переменная-флаг, по которой отслеживается факт выполнения перестановки на итерации
        N_OP += 1;
        bool swapFlag = false; // 1

        N_OP += 3;
        //4
        for (int i = 0; i < queue.Count; i++)
        {
            // сбрасывание флага перестановки
            swapFlag = false; // 1
            N_OP += 4;

            N_OP += 5;
            for (int j = 0; j < queue.Count - i - 1; j++) // 5
            {
                N_OP += 4;
                if (queue[j] > queue[j + 1])
                {
                    (queue[j], queue[j + 1]) = (queue[j + 1], queue[j]); 
                    N_OP += 9;
                    swapFlag = true;
                }
                N_OP += 5;
            }

            // Если на итерации не было перестановок, значит очередь отсортирована, поэтому можно закончить работу цикла
            N_OP += 2;
            if (!swapFlag) // 2
            {
                N_OP += 1;
                break; // 1
            }
        }
        // Конец сортировки //
        Console.WriteLine("После сортировки:");
        queue.Print();

        /*
        for (int n = 1; n <= 10; n++) 
        {
            Queue queue = new Queue();
            // Заполнение очереди n случайными элементами
            for (int i = 0; i < n * 100; i++) 
            {
                queue.Enqueue(rnd.Next(1000));
            }
            N_OP = 0;
            x.Restart();

            // Начало сортировки //
            // Переменная-флаг, по которой отслеживается факт выполнения перестановки на итерации
            N_OP += 1;
            bool swapFlag = false; // 1

            N_OP += 3;
            //4
            for (int i = 0; i < queue.Count; i++)
            {
                // сбрасывание флага перестановки
                swapFlag = false; // 1
                N_OP += 4;

                N_OP += 5;
                for (int j = 0; j < queue.Count - i - 1; j++) // 5
                {
                    N_OP += 4;
                    if (queue[j] > queue[j + 1]) // 4, 9n + 6
                    {
                        (queue[j], queue[j + 1]) = (queue[j + 1], queue[j]); // 2 * (9n + 6) + 2 * (10n + 9)
                        N_OP += 9;
                        swapFlag = true;
                    }
                    N_OP += 5;
                }

                // Если на итерации не было перестановок, значит очередь отсортирована, поэтому можно закончить работу цикла
                N_OP += 2;
                if (!swapFlag) // 2
                {
                    N_OP += 1;
                    break; // 1
                }
            }
            // Конец сортировки //


            x.Stop();
            string k = x.ElapsedMilliseconds.ToString();
            Console.WriteLine($"Номер сортировки: {n} Количество отсортированных элементов: {n * 100} Время сортировки (ms): {k} Количество операций (N_Op): {N_OP}");
        }
        */
    }
}

