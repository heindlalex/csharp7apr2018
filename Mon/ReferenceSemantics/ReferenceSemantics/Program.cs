using System;
using System.Collections;

namespace ReferenceSemantics
{
    public readonly struct MyStruct
    {
        public int Data => 42;
    }

    public ref struct MyStackOnlyStruct  // stack only - no boxing allowed!
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            int a = 42;
            Foo(in a);

            MyStruct ms1 = new MyStruct();

            object o = ms1;  // boxing

            int x = ms1.Data;


            //ArrayList l1 = new ArrayList();
            //l1.Add(42);

            MyStackOnlyStruct ms2 = new MyStackOnlyStruct();
            // ms2.ToString();

            MagicOfSpan();
        }

        private static void MagicOfSpan()
        {
            int[] mydata = { 1, 2, 3, 4, 5, 6 };
            Span<int> span1 = mydata.AsSpan();
            Span<int> aSlice = span1.Slice(2);
            int x1 = aSlice[0];
        }

        static void Foo(in int i)
        {
            Console.WriteLine(i);
            // i = 11;
        }
    }
}
