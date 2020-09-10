using System;

namespace DateFormatting
{
    class Program
    {
        static void Main(string[] args)
        {


            DateTime today = DateTime.Now;

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            // Console.WriteLine("{0:M}, {0:yyyy}", today);
            // Console.WriteLine("{0:yyyy}.{0:mm}.{0:dd}", today);
            // Console.WriteLine("Day {0:dd} of {0:MMMM}, {0:yyyy}", today);
            // Console.WriteLine("Year: {0:yyyy}, Month: {0:MM}, Day: {0:dd}", today);
            // Console.WriteLine("{0:dddd}", today);
            // Console.WriteLine("{0:hh}:{0:mm} {0:tt} ", today);
            // Console.WriteLine("{0:dd}", today);
            // Console.WriteLine("{0:dd}", today);



            Console.WriteLine($"{today:M}, {today:yyyy}");
            Console.WriteLine($"{today:yyyy}.{today:mm}.{today:dd}");

        }
    }
}
