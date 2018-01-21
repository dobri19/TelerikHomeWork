using System;
using System.Collections.Generic;

namespace Task07StackImplementation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new MineStack<int>();

            stack.Push(12);
            stack.Push(50);
            Console.WriteLine("Pop: " + stack.Pop());

            stack.Push(-115);
            stack.Push(65);
            stack.Push(22);
            Console.WriteLine("Peek: " + stack.Peek());

            stack.Push(512);
            stack.Push(602);
            stack.Push(16);
            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine(string.Join(" -> ", stack));
        }
    }
}
