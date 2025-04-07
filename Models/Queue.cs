using System;
using System.Collections.Generic;

namespace QueueApp.Models
{
    public class Queue<T>
    {
        private List<T> items;

        public Queue()
        {
            items = new List<T>();
        }

        public T? CurrentItem => items.Count > 0 ? items[0] : default(T);
        public int Count => items.Count;
        public bool IsEmpty => items.Count == 0;

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}