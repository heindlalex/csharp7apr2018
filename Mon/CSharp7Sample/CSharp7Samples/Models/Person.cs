using System;
using System.Collections.Generic;
using CSharp7Samples.Extensions;

namespace CSharp7Samples.Models
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string name) => name.Split(' ').MoveElementsTo(out _firstName, out _lastName);


        public string FirstName => _firstName;
        public string LastName => _lastName;

        private int _age;

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        //public void Deconstruct(out string first, out string last, out int age)
        //{
        //    first = FirstName;
        //    last = LastName;
        //    age = Age;
        //}

    }

    public static class PersonExtensions
    {
        public static void Deconstruct(this Person p, out string first, out string last, out int age)
        {
            first = p.FirstName;
            last = p.LastName;
            age = p.Age;
        }
    }
}
