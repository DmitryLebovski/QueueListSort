using bsbo_011215_22;
using System.Diagnostics;

internal class Application
{
    static public long N_OP = 0;
    static public int n = 10; //размер сортируемой очереди

    static void Main(string[] args)
    {
        var x = new Stopwatch();
        Random rnd = new Random();

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
            ////////////////////////////////////////////////////////////////////////
            //F(n) = 498n^3+70n^2+9n+4
            //O(F(n)) = n^3
            // Начало сортировки //
            // Переменная-флаг, по которой отслеживается факт выполнения перестановки на итерации

            N_OP += 1;
            bool swapFlag = false;                  // 1

            Application.n += 3;
            for (int i = 0; i < queue.Count; i++)			// 3 + ∑_(i=1)^n▒〖(1+498n^2+70n+5+3)=〗 498n^3+70n^2+9n+3
            {
                // сбрасывание флага перестановки
                swapFlag = false;                   // 1
                N_OP += 1;

                N_OP += 5;
                for (int j = 0; j < queue.Count - i - 1; j++)	// 5 + ∑_(i=1)^n▒〖(148n+25+350n+39+1+5)=〗 498n^2+70n+5  
                {

                    N_OP += 4;
                    if (queue[j] > queue[j + 1]) // 7 + 9+74n + 9+74n = 148n+25
                    {
                        N_OP += 7;
                        (queue[j], queue[j + 1]) = (queue[j + 1], queue[j]); // 7 + 2*(8+101n + 8+74n) = 39 + 350n

                        N_OP += 1;
                        swapFlag = true; 				// 1
                    }
                    N_OP += 5; //5
                }

                // Если на итерации не было перестановок, значит очередь отсортирована, поэтому можно закончить работу цикла
                if (!swapFlag) // 2
                {
                    N_OP += 2;
                    break;
                }
            }
            // Конец сортировки //
            ////////////////////////////////////////////////////////////////////////
            x.Stop();
            string k = x.ElapsedMilliseconds.ToString();
            Console.WriteLine($"Номер сортировки: {n} Количество отсортированных элементов: {n * 100} Время сортировки (ms): {k} Количество операций (N_Op): {N_OP}");
        }
    }
}
