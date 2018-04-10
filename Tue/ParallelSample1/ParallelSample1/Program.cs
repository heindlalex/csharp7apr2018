using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSample1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Foo));

            //ThreadPool.GetMaxThreads(out int worker, out int completion);
            //ThreadPool.GetMinThreads(out int availableworker, out int availablecompl);

            TaskSample();
           
            //Console.WriteLine($"worker: {worker}, compl: {completion}");
            ShowThreadAndTaskInformation("Main");
            ////ParallelForSample();
            ////ParallelForEachSample();
            //ParallelInvokeSample();
            string input = Console.ReadLine();
            Console.WriteLine("finished main");
        }

        private static void TaskSample()
        {
            // Task t1 = Task.Run(new Action(MyTask));

            //Task t1 = new Task(MyTask);
            //t1.Start();

            Task t2 = new Task(MyTask, TaskCreationOptions.LongRunning);
            t2.Start();

            //t2.RunSynchronously();
            Console.WriteLine("end Task Sample");

            
        }

        static void MyTask()
        {
            Console.WriteLine("MyTask started");
            ShowThreadAndTaskInformation("MyTask");
            Thread.Sleep(1000);
            Console.WriteLine("MyTask ended");
        }

        static void Foo(object o)
        {
            Console.WriteLine("Foo started");
            ShowThreadAndTaskInformation("Foo");
            Thread.Sleep(1000);
            Console.WriteLine("Foo ended");
        }

        private static void ParallelInvokeSample()
        {
            Parallel.Invoke(Do1, Do2, Do1);
            Console.WriteLine("ready");
        }

        private static void ShowThreadAndTaskInformation(string title)
        {
            Console.WriteLine($"{title} thread: {Thread.CurrentThread.ManagedThreadId}, task: {Task.CurrentId}, background: {Thread.CurrentThread.IsBackground}, pooled: {Thread.CurrentThread.IsThreadPoolThread}");
        }

        private static void ShowThreadAndTaskInformation()
        {
            Console.WriteLine($"thread: {Thread.CurrentThread.ManagedThreadId}, task: {Task.CurrentId}");
        }

        private static void Do1()
        {
            Console.WriteLine("Do1 started");
            ShowThreadAndTaskInformation();
            Thread.Sleep(1000);
            Console.WriteLine("Do1 ended");
        }

        private static void Do2()
        {
            Console.WriteLine("Do2 started");
            ShowThreadAndTaskInformation();
            Thread.Sleep(1000);
            Console.WriteLine("Do2 ended");
        }

        private static void ParallelForEachSample()
        {
            var list = Enumerable.Range(0, 100000).Select(x => new Demo { Number = x, Text = $"text {x}" }).ToList();
            Parallel.ForEach(list, d =>
            {
                Console.WriteLine($"working on {d.Number} {d.Text}");
            });
        }

        private static void ParallelForSample()
        {
            Parallel.For(0, 100, x =>
            {
                Console.WriteLine($"starting loop {x}");
                Thread.Sleep(100);
                Console.WriteLine($"finish loop {x}");
            });

        }
    }
}
