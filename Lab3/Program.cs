using Lab3;
using System;

namespace Program
{
    class Program
    {
        public delegate void ArraySortDelegate(char[] array);
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            char[] lambdaArray = { 'z', 'a', 'x', 'c', 'b', 'w' };

            Console.WriteLine($"Original array for lambda wxpression: {new string(lambdaArray)}");
            ArraySortDelegate sortDescending = (array) =>
            {
                Array.Sort(array);
                Array.Reverse(array);
            };
            sortDescending(lambdaArray);
            Console.WriteLine($"Sorted array: {new string(lambdaArray)}");



            char[] anonymousArray = { 'z', 'a', 'x', 'c', 'b', 'w' };

            Console.WriteLine($"Original array for anonymous wxpression: {new string(anonymousArray)}");
            ArraySortDelegate anonymousSortDescending = delegate (char[] array)
            {
                Array.Sort(array);
                Array.Reverse(array);
            };
            anonymousSortDescending(anonymousArray);
            Console.WriteLine($"Sorted array: {new string(anonymousArray)}");



            LimitedCapacityQueue myQueue = new LimitedCapacityQueue(capacity: 3);

            myQueue.QueueOverflow += HandleQueueOverflow;

            Console.WriteLine("\n--- 1. Adding items (Capacity=3) ---");
            myQueue.Enqueue('A');
            myQueue.Enqueue('B');
            myQueue.Enqueue('C');

            Console.WriteLine("\n--- 2. Queue overflow attempt ---");
            myQueue.Enqueue('D');

            Console.WriteLine("\n--- 3. Retry overflow ---");
            myQueue.Enqueue('E');
        }
        private static void HandleQueueOverflow(object sender, QueueOverflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n*** EVENT: QUEUE OVERFLOW! ***");
            Console.WriteLine($"    Queue capacity: {e.MaxCapacity}");
            Console.WriteLine($"    Current size: {e.CurrentSize}");
            Console.WriteLine($"    Item attemted to add: {e.ItemAttempted}");
            Console.WriteLine($"    Action: Item '{e.ItemAttempted}' was rejected, because queue is full");
            Console.ResetColor();
        }
    }
}