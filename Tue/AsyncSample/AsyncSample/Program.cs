using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallGreeting();
            //Console.WriteLine("After CallGreeting");
            CallErrors();
            Console.ReadLine();
            Console.WriteLine("Main completed");
        }

        private static async void CallErrors()
        {
            Task outerTask = null;
            try
            {
                Task t1 = ThrowErrorAfterAsync(4000, "first");
                Task t2 = ThrowErrorAfterAsync(3000, "second");
                outerTask = Task.WhenAll(t2, t1);
                await outerTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"outer exception: {ex.Message}");

                foreach (var inner in outerTask.Exception.InnerExceptions)
                {
                    Console.WriteLine($"inner {inner.Message}");
                }
            }
        }

        private async static void CallGreeting()
        {
            ShowThreadInfo("CallGreeting started");
            //string katharinaResult = await GreetingAsync("Katharina", 3000);
            //string stephanieResult = await GreetingAsync("Stephanie", 2000);
            //Console.WriteLine(katharinaResult);
            //Console.WriteLine(stephanieResult);

            Task<string> kTask = GreetingAsync("Katharina", 3000);
            Task<string> sTask = GreetingAsync("Stephanie", 2000);
            string[] results = await Task.WhenAll(kTask, sTask);
            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);
            ShowThreadInfo("CallGreeting after await");
   
            Console.WriteLine("CallGreeting completed");
        }

        public static async Task<string> CallGreeting2()
        {
            string s = await GreetingAsync("Matthias", 3000);
            return "hello";
        }

        public static Task<string> GreetingAsync(string name, int ms)
        {
            return Task.Run(() => Greeting(name, ms));
        }

        public static string Greeting(string name, int ms)
        {
            Console.WriteLine("Greeting started");
            ShowThreadInfo("Greeting");
            Thread.Sleep(ms);
            return $"Hello, {name}";
        }

        private static void ShowThreadInfo(string title) =>
            Console.WriteLine($"{title}, thread: {Thread.CurrentThread.ManagedThreadId}, task: {Task.CurrentId}");


        public static async Task ThrowErrorAfterAsync(int ms, string error)
        {
            await Task.Delay(ms);
            throw new Exception(error);
        }
    }
}
