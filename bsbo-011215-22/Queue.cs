namespace bsbo_011215_22
{
    public class Queue
    {
        public int Capacity;
        int[] _list; // Массив чисел
        public int Count = 0; // Размер текущей очереди		// 1

        public Queue()							// (1+2+4)=7
        {
            Capacity = Application.n; 						// 2
            _list = new int[Application.n]; 				// 4
            Application.N_OP += 7;
        }

        // Проверка на пустоту очереди
        public bool isEmpty()						// 1
        {
            Application.N_OP += 1;
            return Count == 0; 						// 1
        }

        // Добавление элемента в очередь
        public void Enqueue(int item)					// 1+(18+2)+3+2=26
        {
            // Если массив заполнен, а нужно добавить еще элементы - размер массива "увеличивается" 
            if (Count == Capacity)					// 1
            {
                Array.Resize(ref _list, Capacity * 2);		// 15 + 3 = 18
                Capacity *= 2;						// 2
            }
            _list[Count] = item;					// 3
            Count++; 							// 2
            Application.N_OP += 26;
        }

        // Удаление элемента из очереди
        public int Dequeue()						// 39
        {
            if (isEmpty())
            {						// 1
                throw new InvalidOperationException("Cannot index: Queue is empty.");
            }

            int res = _list[0];						// 3
            Array.Copy(_list, 1, _list, 0, Capacity - 1); 	// 6 + 27 = 33
            Count--;							// 2
            Application.N_OP += 39;
            return res;
        }

        // Получение значения элемента очереди
        public int Get(int index)					// 6+74n
        {
            if (index < 0 || index >= Count) // 3
            {
                throw new IndexOutOfRangeException();
            }
            Application.N_OP += 3;

            // Переменная для сохранения нужного элемента
            int item = 0;							// 1
            Application.N_OP += 1;

            Application.N_OP += 2;
            // Извлекаем элементы из очереди и восстанавливаем после получения нужного элемента
            for (int i = 0; i < Count; i++)				//2+∑_(i=1)^n▒〖(42+1+1+28+2)=〗 2+74n
            {
                int current = Dequeue(); 				// 2+39=41
                Application.N_OP += 2;

                Application.N_OP += 1;
                if (i == index)						// 1
                {
                    // Сохраняем нужный элемент
                    item = current;					// 1
                    Application.N_OP += 1;
                }
                Enqueue(current);					// 2+26=28 
                Application.N_OP += 2;

                Application.N_OP += 2;
            }
            return item;
        }
        // Установка значения элемента очереди по индексу
        // Та же логика, что и в Get(), но вместо возврата значения элемента ему устанавливается новое значение.
        public void Set(int index, int value)			// 5+101n
        {
            Application.N_OP += 3;
            if (index < 0 || index >= Count)				// 3
                throw new IndexOutOfRangeException();

            Application.N_OP += 2;
            // Извлекаем элементы из очереди и восстанавливаем после замены нужного элемента
            for (int i = 0; i < Count; i++) 				// 2+∑_(i=1)^n▒〖(42+1+28+28+2)=〗 2+101n
            {
                Application.N_OP += 2;
                int current = Dequeue(); 				// 2+39=41

                Application.N_OP += 1;
                if (i == index)						// 1
                {
                    // Заменяем элемент на нужном индексе
                    Enqueue(value);                     // 2+26=28
                    Application.N_OP += 2;
                }
                else
                {
                    // Восстанавливаем остальные элементы
                    Enqueue(current);                   // 2+26=28
                    Application.N_OP += 2;
                }
                Application.N_OP += 2;
            }
        }
        // Перегрузка []
        public int this[int index]
        {
            get
            {
                Application.N_OP += 2;
                return Get(index); 					// 2+(6+74n)=8+74n
            }
            set
            {
                Application.N_OP += 3;
                Set(index, value); 					// 3+(5+101n)=8+101n
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
