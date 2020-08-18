using System;

namespace JoshuaBelow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();

            // there are two ways to output the string 
            Console.WriteLine("Hello, " + name);
            Console.WriteLine("Hello, {0}", name);
            

        }
    }
}
