using NetStandardLib;
using System;

namespace DotnetCoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            string greeting = demo.Hello("Katharina");
            Console.WriteLine(greeting);

            demo.Message("Hello, Stephanie");
        }
    }
}
