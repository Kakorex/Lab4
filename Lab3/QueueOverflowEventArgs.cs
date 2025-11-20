using System;

namespace Lab3
{
    public class QueueOverflowEventArgs : EventArgs
    {
        public int MaxCapacity { get; }
        public int CurrentSize { get; }
        public char ItemAttempted { get; }

        public QueueOverflowEventArgs(int capacity, int size, char attemptedItem)
        {
            MaxCapacity = capacity;
            CurrentSize = size;
            ItemAttempted = attemptedItem;
        }
    }
}
