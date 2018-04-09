using System;
using static System.Console;
using static CSharp6Sample.MyConstants;

namespace CSharp6Sample
{

    public static class MyConstants
    {
        public const string Value1 = nameof(Value1); 
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            StringInterpolation();
            NullDemo1(null);

            try
            {
                ThrowSomething();
            }
            catch (Exception ex) when (ex.Message == "bad bad")
            {
                Console.WriteLine("bad bad");
 
            }

            Console.WriteLine(Value1);
        }

        private static void NullDemo1(object o)
        {
            // if (o == null) throw new ArgumentNullException(nameof(o));

            string s1 = o?.ToString() ?? string.Empty;

            bool? b1 = null;
            bool b2 = b1 ?? false;
            Nullable<bool> b3 = null;

            //// C# 8
            //string? s2 = null;




        }

        private static void StringInterpolation()
        {
            int x = 42;
            string s = "astring";
            Console.WriteLine("some text, x: {0:x}, s: {1}", x, s);

            Console.WriteLine($"some text, x: {x:x}, s: {s + 2}");

            string format1 = string.Format("some text, x:{0:x}, s: {1}", x, s);

            FormattableString fs1 = $"some text, x: {x:x}, s: {s + 2}";




        }

        public int GetAValue()
        {
            return 3;
        }
        public int GetAValue2() => 3;

        public int Add(int x, int y) => x + y;


        public int MyProp => 42;

        public int MyProp2
        {
            get
            {
                return 42;
            }
        }

        public static void ThrowSomething()
        {
            throw new Exception("bad bad");

        }


    }
}
