using System;
using System.Collections.Generic;

namespace bsbo_011215_22
{
    public class Queue
    {
        private List<int> _list;

        public Queue() {
            _list = new List<int>();
        }

        // Получение длины очереди
        public int Count {
            get { return _list.Count; }
        }

        // Проверка очереди на пустоту
        public bool isEmpty()
        {
            return Count == 0;
        }

        // Добавление элемента в очередь
        public void Enqueue(int item)
        {
            _list.Add(item);
        }

        // Удаление элемента из очереди
        public int Dequeue()
        {
           if (isEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            int item = _list[0];
            _list.RemoveAt(0);
            return item;
        }
        
        // Вывод элемента в начале очереди без его удаления
        public int Peek() {
            if (isEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            
            return _list[0];
        }

        // Перегрузка оператора индексации [] 
        public int this[int index]
        {
            get {
                if (index < 0 || index >= Count) { 
                    throw new ArgumentOutOfRangeException("index");
                }
                return _list[index % Count];
            }

            set {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                _list[index % Count] = value;
            }
        }


        // Вывод списка в консоль
        public void Print()
        {
            foreach (int item in _list)
            {
                Console.Write($"{item.ToString()} ");
            }
            Console.WriteLine();
        }
    }
}

