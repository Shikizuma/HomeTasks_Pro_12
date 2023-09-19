using System.Threading;

namespace Task3
{
    internal class Program
    {
        static Mutex mutex = new Mutex(false, "MyMutex");
        static void Main(string[] args)
        {
            if (!mutex.WaitOne(TimeSpan.Zero, false))
            {
                Console.WriteLine("Програма запущена в іншому екземплярі.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Програма запущена.");

            Console.ReadKey();
            mutex.ReleaseMutex();
        }
    }
}