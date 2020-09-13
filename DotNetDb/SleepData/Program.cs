using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();
            string fileName = "data.txt";

            if (resp == "1")
            {
                // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                 // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate) {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);

                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file

                StreamReader sr = new StreamReader(fileName);

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitFileName;
                    string[] listOfHours;
                    double totalHoursForAWeek = 0;

                    //break the output into two parts 
                    splitFileName = line.Split(',');

                    //checking the list of hours
                    // Console.WriteLine(splitFileName[1]);

                    //start looping for each day
                    listOfHours = splitFileName[1].Split('|');
                    for (int i = 0; i < 7; i++) {

                        totalHoursForAWeek += double.Parse(listOfHours[i]);
                    
                    }


                    //the header for each week 
                    Console.WriteLine($"Week of {Convert.ToDateTime(splitFileName[0]):MMM}, {Convert.ToDateTime(splitFileName[0]):dd}, {Convert.ToDateTime(splitFileName[0]):yyyy}");
                    Console.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
                    Console.WriteLine("-- -- -- -- -- -- -- --- ---");
                    // Console.WriteLine(" " +  + " " + totalHoursForAWeek + " " + string.Format("{0:0.0}", totalHoursForAWeek/7));
                    Console.WriteLine(String.Format("{0,2} {1,2} {2,2} {3,2} {4,2} {5,2} {6,2} {7,3} {8,3:N1}", listOfHours[0], listOfHours[1], listOfHours[2], listOfHours[3], listOfHours[4], listOfHours[5], listOfHours[6], totalHoursForAWeek, totalHoursForAWeek/7));

                    //adding a line before the next week display
                    Console.WriteLine();
                    
                    


                }

            }
        }
    }
}