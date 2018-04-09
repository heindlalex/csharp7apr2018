using NetStandardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetFrameworkApp
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
