namespace bsbo_011215_22
{
    // Линейная структура "Очередь"
    public class Queue
    {
        private int N = 5; // размер очереди
        private int[] list; // массив данных
        private int start; // указатель на начало

        public Queue()
        {
            list = new int[N];
            start = 0;
        }

        // Проверка очереди на полноту
        public bool IsFull()
        {
            return start == N;
        }

        // Проверка очереди на пустоту
        public bool IsEmpty()
        {
            return start == 0;
        }

        // Добавление нового элемента в очередь
        public void Enqueue(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("\nОчередь заполнена\n\n");
                return;
            }

            list[start++] = value;
        }

        // Удаление элемента из очереди
        public int Dequeue()
        {   
            for (int i = 0; i < start && i < N - 1; i++)
            {
                list[i] = list[i + 1];
            }
            start--;
            int rmpD = list[start];
            list[start] = int.MaxValue;
            return rmpD;
        }

        // Получение первого элемента
        public int Top()
        {
            return list[0];
        }

        // Получение размера очереди
        public int Size()
        {
            return start;
        }

        // Получение значения элемента очереди
        public int Get(int index, Queue tmp)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot index: Queue is empty.");
            }

            for (int i = 0; i < index; i++)
            {
                // Удаляется верхний элемент очереди, помещается в другую очередь,
                // пока верхним не окажется нужный элемент. Если в процессе
                // очередь закончится, очередь возвращается в исходное состояние
                tmp.Enqueue(Dequeue());
                if (IsEmpty())
                {
                    while (!tmp.IsEmpty())  // Восстановление очереди к исходному состоянию
                        Enqueue(tmp.Dequeue());
                    throw new InvalidOperationException("Indexing failed: out of range.");
                }
            }
                
            int result = list[start]; // Сохранение значения перед восстановлением очереди

            // Восстановление очереди к исходному состоянию
            while (!tmp.IsEmpty())
                Enqueue(tmp.Dequeue());

            return result;
        }

        // Установка значения элемента очереди по индексу
        // Та же логика, что и в Get(), но вместо возврата значения элемента ему устанавливается новое значение.
        public void Set(int index, int value, Queue tmp)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot index: Queue is empty.");

            for (int i = 0; i < index; i++)
            {
                tmp.Enqueue(Dequeue());
                if (IsEmpty())
                {
                    while (!tmp.IsEmpty())
                        Enqueue(tmp.Dequeue());
                    throw new InvalidOperationException("Indexing failed: out of range.");
                }
            }

            list[start] = value; // подстановка значения

            while (!tmp.IsEmpty())
                Enqueue(tmp.Dequeue());
        }

        // Перегрузка оператора индексации []
        public int this[int index]
        {
            get => Get(index, Application.tmp);
            set => Set(index, value, Application.tmp);
        }

        // Вывод очереди в консоль
        public void Print()
        {
            for (int i = 0; i < start; i++) {
                Console.Write($"{list[i].ToString()} ");
            }
            Console.WriteLine();
        }


        /* Описание  алгоритма пузырьковой сортировки:*
        1. Итерация по очереди: Алгоритм начинает сравнивать пары соседних элементов, начиная с первой пары(индексы 0 и 1) и до последней пары(индексы N-2 и N-1), где N - размер очереди;
        2. Сравнение и перестановка: Для каждой пары элементов сравниваются их значения.Если значение текущего элемента больше значения следующего элемента, они меняются местами;
        3. Подъём наибольшего элемента: В результате первой итерации самый большой элемент "всплывает" к концу очереди (индекс N-1);
        4. Повторение итераций: Процесс повторяется для всех оставшихся элементов, и каждый раз самый большой элемент "всплывает" на одну позицию ближе к концу очереди;
        5. Условие завершения: После каждой итерации проверяется, была ли выполнена перестановка элементов. Если на текущей итерации не было ни одной перестановки, значит очередь уже отсортирована, и сортировка завершается;
        6. Повторение цикла: Если были произведены перестановки, алгоритм повторяет весь процесс итераций до тех пор, пока не будет достигнуто условие завершения(swapFlag = false) */

        // Реализации алгоритма пузырьковой сортировки
        public void QueueSort()
        { 
            bool swapFlag = false; // переменная-флаг, по которой отслеживается факт выполнения перестановки на итерации
            for (int i = 0; i < N; i++)
            {
                swapFlag = false; // сбрасывание флага перестановки

                for (int j = 0; j < N - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                        swapFlag = true;
                    }
                }
                // Если на итерации не было перестановок, значит очередь отсортирована, поэтому можно закончить работу цикла
                if (!swapFlag)
                    break;
            }
        }
    }
}

