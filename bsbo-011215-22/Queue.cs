namespace bsbo_011215_22
{
    // Линейная структура "Очередь"
    public class Queue
    {
        private int N = 5; // размер очереди
        private int[] list; // массив данных
        private int next; // указатель на начало

        public Queue()
        {
            list = new int[N];
            next = 0;
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
        public int Delete()
        {   
            for (int i = 0; i < next && i < N - 1; i++)
            {
                list[i] = list[i + 1];
            }
            next--;
            int rmpD = list[next];
            list[next] = int.MaxValue;
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
            return next;
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
                // Поэтапно удаляем верхний элемент очереди, помещая его в другую очередь,
                // пока "на поверхности" не окажется нужный нам элемент. Если в процессе
                // очередь внезапно "закончится", его следует вернуть в исходное состояние.
                tmp.Add(this.Delete());
                if (IsEmpty())
                {
                    while (!tmp.IsEmpty())  // Восстановление очереди к исходному состоянию
                        this.Add(tmp.Delete());
                    throw new InvalidOperationException("Indexing failed: out of range.");
                }
            }

            int result = list[next]; // Сохранение значения перед восстановлением очереди

            // Восстановление очереди к исходному состоянию.
            while (!tmp.IsEmpty())
                this.Add(tmp.Delete());

            return result;
        }

        // Установка значения элемента очереди по индексу
        // Та же логика, что и в Get(), но вместо возврата значения элемента ему устанавливается новое значение.
        public void Set(int index, int value, Queue tmp)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot index: Stack is empty.");

            for (int i = 0; i < index; i++)
            {
                tmp.Add(this.Delete());
                if (this.IsEmpty())
                {
                    while (!tmp.IsEmpty())
                        this.Add(tmp.Delete());
                    throw new InvalidOperationException("Indexing failed: out of range.");
                }
            }

            list[next] = value; // подстановка значения

            while (!tmp.IsEmpty())
                this.Add(tmp.Delete());
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

