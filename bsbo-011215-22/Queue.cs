namespace bsbo_011215_22
{
    public class Queue
    {
        public int Capacity;
        int[] _list; // Массив чисел
        public int Count = 0; // Размер текущей очереди (1)

        public Queue()
        {
            Capacity = Application.n; // 2
            _list = new int[Application.n]; // 4
            Application.N_OP += 7;
        }

        // Проверка на пустоту очереди
        public bool isEmpty()
        {
            Application.N_OP += 1;
            return Count == 0; // 1
        }

        // Добавление элемента в очередь
        public void Enqueue(int item)
        {
            Application.N_OP += 1;
            // Если массив заполнен, а нужно добавить еще элементы - размер массива "увеличивается" 
            if (Count == Capacity) // 1
            {
                Array.Resize(ref _list, Capacity * 2); // 3 + 13 = 16 
                Capacity *= 2; // 2
                Application.N_OP += 18;
            }
            _list[Count] = item; // 3
            Count++; // 1
            Application.N_OP += 4;
        }

        // Удаление элемента из очереди
        public int Dequeue()
        {
            if (isEmpty()) { 
                throw new InvalidOperationException("Cannot index: Queue is empty.");
            }// 1
            Application.N_OP += 1;


            Application.N_OP += 38;
            int res = _list[0]; // 3
            Array.Copy(_list, 1, _list, 0, Capacity - 1); // 6 + 
            Count--; // 1
            return res; // 1
        }

        // Получение значения элемента очереди
        public int Get(int index)
        {
            Application.N_OP += 3;
            if (index < 0 || index >= Count) {
                throw new IndexOutOfRangeException();
            }

            // Переменная для сохранения нужного элемента
            int item = 0; Application.N_OP += 1;

            Application.N_OP += 1; 
            // Извлекаем элементы из очереди и восстанавливаем после получения нужного элемента
            for (int i = 0; i < Count; i++)
            {
                Application.N_OP += 2;
                int current = Dequeue();// 2

                Application.N_OP += 1;
                //1
                if (i == index)
                {
                    // Сохраняем нужный элемент
                    item = current; // 1
                    Application.N_OP += 1;
                }

                Application.N_OP += 2;
                Enqueue(current); // 2

                Application.N_OP += 2;
            }
            return item;
        }

        // Установка значения элемента очереди по индексу
        // Та же логика, что и в Get(), но вместо возврата значения элемента ему устанавливается новое значение.
        public void Set(int index, int value) 
        {
            //3
            Application.N_OP += 3;
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            Application.N_OP += 1;
            // Извлекаем элементы из очереди и восстанавливаем после замены нужного элемента
            for (int i = 0; i < Count; i++)
            {
                Application.N_OP += 2;
                int current = Dequeue(); // 2

                Application.N_OP += 1;
                if (i == index)
                {
                    // Заменяем элемент на нужном индексе
                    Enqueue(value); // 2
                    Application.N_OP += 2;
                }
                else
                {
                    // Восстанавливаем остальные элементы
                    Enqueue(current); // 2
                    Application.N_OP += 2;
                }

                Application.N_OP += 2;
            }
        }

        // Перегрузка []
        public int this[int index]
        {
            get // 2
            {
                Application.N_OP += 2;
                return Get(index); 
            }

            set // 3
            {
                Application.N_OP += 3;
                Set(index, value); 
            }
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

