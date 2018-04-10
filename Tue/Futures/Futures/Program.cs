using System;
using System.Threading;
using System.Threading.Tasks;

namespace Futures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartATask();
        }

        private static void StartATask()
        {
            Console.WriteLine("StartATask");
            var t1 = new Task<int>(() =>
            {
                Thread.Sleep(3000);
                return 42;
            });
            t1.Start();
            int result = t1.Result;
            Console.WriteLine(result);
        }
    }
}
