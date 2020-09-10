using System;

namespace FormatStringTutorial
{
    class Program
    {
        static void Main(string[] args)
        {


            DateTime today = DateTime.Now;
            

            Console.WriteLine($"{today:M}, {today:yyyy}");
            Console.WriteLine($"{today:M}, {today:yyyy}");

        }
    }
}
