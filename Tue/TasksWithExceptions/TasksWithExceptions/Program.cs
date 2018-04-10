using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksWithExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // StartATask();
            StartATaskWithClosure();
            Console.ReadLine();
        }

        private static void StartATaskWithClosure()
        {
            int x = 42;
            for (int i = 0; i < 10; i++)
            {

                Task.Run(() =>
                {
                    // Thread.Sleep(10);
                    Console.WriteLine(i);
                });
            }
            //Task t1 = Task.Run(() =>
            //{
            //   // Thread.Sleep(10);
            //    Console.WriteLine(x);
            //});
            //x = 11;
        }

        private static void StartATask()
        {
            try
            {
                Task t1 = Task.Run(new Action(MyTask));
                t1.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"{ex.Message} {ex.GetType().Name}");
            }
            Console.WriteLine("StartATask finished");
        }

        private static void MyTask()
        {
            Console.WriteLine("MyTask started");
            throw new Exception("bad bad");
        }
    }
}
