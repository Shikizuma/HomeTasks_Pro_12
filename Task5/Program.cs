namespace Task5
{
    using System;
    using System.IO;
    using System.Threading;

    class Program
    {
        private static Semaphore semaphore = new Semaphore(2, 2, "sdf432wsw12f4234we234c12wwewrwe1"); 

        static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                int threadNumber = i;
                Thread thread = new Thread(() => AccessResource(threadNumber));
                thread.Start();
            }

            Console.ReadLine();
        }

        static void AccessResource(int threadNumber)
        {
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                try
                {
                    semaphore.WaitOne();
                    if (key == 'w')
                    {
                        using (StreamWriter writer = new StreamWriter("log.txt", true))
                        {
                            writer.WriteLine($"Потік {threadNumber} отримав доступ до ресурсу в {DateTime.Now}");
                        }
                        Thread.Sleep(3000);
                        Console.WriteLine("Запис пройшла!");
                    }
                    else
                    {
                        using (StreamReader reader = new StreamReader("log.txt"))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                        Thread.Sleep(3000);

                        Console.WriteLine("Читання пройшло!");
                    }

                    semaphore.Release(); 
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
    }

}