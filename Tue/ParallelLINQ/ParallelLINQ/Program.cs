using System;
using System.Linq;

namespace ParallelLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            LINQDemo();
        }

        private static void LINQDemo()
        {
            Random r = new Random();
            var list = Enumerable.Range(0, 10000).Select(x => new SomeData { Number = r.Next(0, 100), Text = $"text {x}" }).ToList();

            //var q = from x in list
            //        where x.Number > 40
            //        select x;

            list.AsParallel().Where(x => x.Number > 40).Select(x => x).ForAll(sd =>
            {
                Console.WriteLine($"{sd.Text} {sd.Number}");
            });

        }
    }
}
