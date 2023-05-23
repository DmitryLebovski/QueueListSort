namespace bsbo_011215_22
{
    // Линейная структура "Очередь"
    public class Queue
    {
        private int N = Application.n; 
        private int[] list; // массив чисел
        private int head; // начало очереди
        private int tail; // хвост очереди
        public int Count { get; private set; } // размер текущей очереди
        public int Capacity { get; private set; } // изначальный размер очереди

        public Queue()
        {
            list = new int[N];
            head = 0;
            tail = 0;
            Count = 0;
            Capacity = N;
        }

        // Добавление нового элемента в очередь
        public void Enqueue(int item)
        {
            //После добавления элемента в очередь,
            //индекс tail сдвигается вперед(вправо) к следующему свободному элементу в массиве, а Count (размер текущей очереди) увеличится на 1
            list[tail] = item;
            tail = (tail + 1) % Capacity;
            Count++;
        }

        // Удаление элемента из очереди
        public int Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            //После удаления элемента из очереди,
            //индекс head сдвигается вперед к следующему элементу, а Count (размер текущей очереди) уменьшается на 1
            int item = list[head];
            list[head] = 0; // освобождаем как пустой элемент
            head = (head + 1) % Capacity;
            Count--;
            return item;
        }

        // Получение значения элемента очереди
        public int Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            // Переменная для сохранения нужного элемента
            int item = 0;

            // Извлекаем элементы из очереди и восстанавливаем после получения нужного элемента
            for (int i = 0; i < Count; i++)
            {
                int current = Dequeue();
                if (i == index)
                {
                    item = current; // Сохраняем нужный элемент
                }
                Enqueue(current);
            }

            return item;
        }

        // Установка значения элемента очереди по индексу
        // Та же логика, что и в Get(), но вместо возврата значения элемента ему устанавливается новое значение.
        public void Set(int index, int value)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            // Извлекаем элементы из очереди и восстанавливаем после замены нужного элемента
            for (int i = 0; i < Count; i++)
            {
                int current = Dequeue();
                if (i == index)
                {
                    Enqueue(value); // Заменяем элемент на нужном индексе
                }
                else
                {
                    Enqueue(current); // Восстанавливаем остальные элементы
                }
            }
        }

        public int this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        // Вывод очереди в консоль
        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                int elem = Dequeue();
                Console.Write($"{elem} ");
                Enqueue(elem);
            }
            Console.WriteLine();
        }
    }
}

