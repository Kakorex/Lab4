using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class LimitedCapacityQueue
    {
        private readonly int _capacity;
        private List<char> _data;

        public event EventHandler<QueueOverflowEventArgs> QueueOverflow;

        public LimitedCapacityQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Queue capacity must be greater than zero.");
            }
            _capacity = capacity;
            _data = new List<char>(capacity);
        }
        protected virtual void OnQueueOverflow(char itemAttempted)
        {
            QueueOverflow?.Invoke(this, new QueueOverflowEventArgs(_capacity, _data.Count, itemAttempted));
        }
        public void Enqueue(char item)
        {
            if (_data.Count >= _capacity)
            {
                OnQueueOverflow(item);
            }
            else
            {
                _data.Add(item);
                Console.WriteLine($"[INFO] Added item: '{item}'. Size: {_data.Count}/{_capacity}");
            }
        }
        public char Dequeue()
        {
            if (_data.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            char item = _data[0];
            _data.RemoveAt(0);
            Console.WriteLine($"[INFO] Deleted item '{item}'. Size: {_data.Count}/{_capacity}");
            return item;
        }
    }
}
