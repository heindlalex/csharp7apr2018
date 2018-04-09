using CSharp7Samples;
using CSharp7Samples.Extensions;
using CSharp7Samples.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        //BinaryLiteralsAndDigitSeparators();
        // RefLocalAndRefReturn();
        //OutVars();
        //LocalFunctions();
        // UseMyFilter();
        // LambdaExpressionsEverywhere();
        //FlexibleAwait();
        //ThrowExpressions();
        PatternMatching();
        //TuplesAndDeconstruction();
    }

    private static void UseMyFilter()
    {
        string[] data = { "one", "two" };
        var result = data.Filter3(null);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }


    }

    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));

        ulong l1 = 0xabcd_0123_8765_abab;
        int b1 = 0b_1111_00000_1011__0101;


        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));
        int[] data = { 1, 2, 3, 4, 5, 6 };
        ref readonly int a = ref GetByIndex(data, 2);
        Console.WriteLine(a);
        // a = 42;
        Console.WriteLine(data[2]);

        Console.WriteLine();
    }

    public static ref readonly int GetByIndex(int[] data, int index)
    {
        ref int x = ref data[index];
        return ref x;
    }


    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();
        bool success = int.TryParse(input, out int result);
        if (success)
        {
            Console.WriteLine($"this number: {result}");
        }
        else
        {
            Console.WriteLine("NaN");
        }
        Console.WriteLine();
    }

    private static void LocalFunctions()
    {
        Console.WriteLine(nameof(LocalFunctions));

        //int add(int x, int y)
        //{
        //    return x + y;
        //}
        int add(int x, int y) => x + y;

        // Func<int, int, int> add = (x, y) => x + y;

        int a = add(3, 4);
        Console.WriteLine(a);

        Console.WriteLine();
    }

    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));

        var p1 = new Person("Katharina Nagel");
        Console.WriteLine(p1.FirstName);

        Console.WriteLine();
    }

    private static void FlexibleAwait()
    {
        Console.WriteLine(nameof(FlexibleAwait));

        Console.WriteLine();
    }

    private static void ThrowExpressions()
    {
        Console.WriteLine(nameof(ThrowExpressions));
        int x = 42;

        int y = 0;
        if (x <= 42)
        {
            y = x;
        }
        else
        {
            throw new Exception("bad value");
        }

        Console.WriteLine($"y: {y}");
        Console.WriteLine();
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { "abc", 42, null, new Person("Matthias Nagel"), new Person("Stephanie Nagel") };

        foreach (object item in data)
        {
            IsPattern(item);
        }

        foreach (object item in data)
        {
            SwitchPattern(item);
        }

        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is 42) // const pattern
        {
            Console.WriteLine("it's 42");
        }
        if (o is null)
        {
            Console.WriteLine("null");
        }
        if (o is int i)  // type pattern
        {
            Console.WriteLine($"it's an int with value {i}");
        }
        if (o is Person p)
        {
            Console.WriteLine($"it's a person with {p.FirstName}");
        }
        if (o is var v1) // var pattern
        {
            Console.WriteLine($"var pattern {v1?.GetType().Name ?? "null"}");
        }
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {

            case null: // const pattern
                Console.WriteLine("it's null");
                break;
            case 42:
                Console.WriteLine("it's 42");
                break;
            case int i:
                Console.WriteLine($"it's an int with {i}");
                break;
            case Person p when p.FirstName.StartsWith("Steph"):
                Console.WriteLine("it's Stephanie");
                break;
            case Person p:
                Console.WriteLine("any Person");
                break;
            case var v1:
                Console.WriteLine("anything else");
                break;

            //default:
            //    break;

        }
    }

    private static void TuplesAndDeconstruction()
    {
        Console.WriteLine(nameof(TuplesAndDeconstruction));

        Tuple<string, int> t1 = Tuple.Create("abc", 42);
        // t1.Item1 = "new string";  // Tuple is read-only

        (string s, int i) = ("abc", 42);  // deconstruction - tuple creation
        // ValueTuple<string, int> vt1;


        var t2 = (mystring: "abc", myint: 42);  // tuple
        Console.WriteLine(t2.mystring);
        t2.mystring = "def";

        int x1 = 42;
        x1 = 43;

        var t3 = Divide(42, 11);
        Console.WriteLine(t3.result);
        Console.WriteLine(t3.remainder);

        (int result, int remainder) = Divide(9, 4);
        Console.WriteLine(result);

        var p2 = new Person("Stephanie Nagel");
        (string firstName, _, _) = p2;




        Console.WriteLine();
    }

    private static (int result, int remainder) Divide(int x, int y)
    {
        int res = x / y;
        int rem = x % y;
        return (res, rem);
    }




}