using System;
using TheOldLib;

namespace NetStandardLib
{
    public class Demo
    {
        public string Hello(string name) => $"Hello, {name}";

        public void Message(string message) =>
            new SomthingOld().Message(message);
    }
}
