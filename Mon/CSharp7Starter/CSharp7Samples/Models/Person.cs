using System;
using System.Collections.Generic;
using CSharp7Samples.Extensions;

namespace CSharp7Samples.Models
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string name)
        {

        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
