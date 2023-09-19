namespace HomeTasks_Pro_12
{
    internal class Program
    {
        static ManualResetEvent[] events = new ManualResetEvent[]
        {
        new ManualResetEvent(false),
        new ManualResetEvent(false)
        };

        static void Main()
        {
            for (int i = 0; i < events.Length; i++)
            {
                int threadNumber = i;
                Thread thread = new Thread(() => Worker(threadNumber));
                thread.Start();
            }
            ManualResetEvent.WaitAll(events);

            Console.WriteLine("Всі потоки завершили роботу.");
        }

        static void Worker(int threadNumber)
        {
            Console.WriteLine($"Потік {threadNumber} починає роботу.");
            Thread.Sleep(1000);
            Console.WriteLine($"Потік {threadNumber} завершив роботу.");
            events[threadNumber].Set(); 
        }
    }

}
