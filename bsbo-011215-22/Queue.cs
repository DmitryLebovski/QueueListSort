namespace bsbo_011215_22
{
    // Линейная структура "Очередь"
    public class Queue
    {
        private int N;
        private int[] list; // массив данных
        private int next; // указатель на начало

        public Queue(int n)
        {
            list = new int[n];
            next = 0;
            N = n;
        }

        // Проверка очереди на полноту
        public bool IsFull()
        {
            return next == N;
        }

        // Проверка очереди на пустоту
        public bool IsEmpty()
        {
            return next == 0;
        }

        // Добавление нового элемента в очередь
        public void Add(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("\nОчередь заполнена\n\n");
                return;
            }

            list[next++] = value;
        }

        // Удаление элемента из очереди
        public void Delete()
        {   
            for (int i = 0; i < next && i < N - 1; i++)
            {
                list[i] = list[i + 1];
            }
            next--;
            list[next] = int.MaxValue;
        }

        // Получение первого элемента
        public int Top()
        {
            return list[0];
        }

        // Получение размера очереди
        public int Size()
        {
            return next;
        }

        // Перегрузка оператора индексации [] 
        public int this[int index]
        {
            get {
                if (index < 0 || index >= Size()) { 
                    throw new ArgumentOutOfRangeException("index");
                }
                return list[index];
            }

            set {
                if (index < 0 || index >= Size())
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                list[index] = value;
            }   
        }

        // Вывод очереди в консоль
        public void Print()
        {
            for (int i = 0; i < next; i++) {
                Console.Write($"{list[i].ToString()} ");
            }
            Console.WriteLine();
        }


        // Реализации алгоритма сортировки очереди на массивах
        public void QueueSort()
        {
            
            bool swapFlag = false;
            for (int i = 0; i < N; i++)
            {
                swapFlag = false;
                for (int j = 0; j < N - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                    break;
            }
        }
    }
}

