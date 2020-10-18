using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TicketSystem
{
    public class EnhancementFile
    {
        // public property
        public string filePath { get; set; }
        public List<Enhancement> Enhancement { get; set; }


        // constructor is a special method that is invoked
        // when an instance of a class is created
        public EnhancementFile(string enhancementFilePath)
        {
            filePath = enhancementFilePath;
            Enhancement = new List<Enhancement>();

            // to populate the list with data, read from the data file
            try
            {
                StreamReader sr = new StreamReader(filePath);

                // first line contains column headers
                sr.ReadLine();
                
                while (!sr.EndOfStream)
                {

                    // create instance of Enhancement class
                    Enhancement enhancement = new Enhancement();

                    string line = sr.ReadLine();

                    string[] enhancementDetails = line.Split(',');
                    enhancement.ticketId = UInt64.Parse(enhancementDetails[0]);
                    enhancement.summary = enhancementDetails[1];
                    enhancement.status = enhancementDetails[2];
                    enhancement.priority = enhancementDetails[3];
                    enhancement.submitter = enhancementDetails[4];
                    enhancement.assigned = enhancementDetails[5];
                    enhancement.watching = enhancementDetails[6].Split('|').ToList();
                    enhancement.software = enhancementDetails[7];
                    enhancement.cost = double.Parse(enhancementDetails[8]);
                    enhancement.reason = enhancementDetails[9];
                    enhancement.estimate = enhancementDetails[10];

                    Enhancement.Add(enhancement);
                }
                // close file when done
                sr.Close();
                Console.WriteLine("Enhancements in file {0}", Enhancement.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("the catch happened for the EnhancementFile");
                Console.WriteLine(ex.Message);
            }
        }


        public void AddEnhancement(Enhancement enhancement)
        {
            try
            {
                Console.WriteLine("trying to write a new line");
                // first generate enhancement id
                enhancement.ticketId = Enhancement.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);

                sw.WriteLine($"{enhancement.ticketId},{enhancement.summary},{enhancement.status},{enhancement.priority},{enhancement.submitter},{enhancement.assigned},{string.Join("|", enhancement.watching)},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");
                sw.Close();

                // add enhancement details to Lists
                Enhancement.Add(enhancement);

                // log transaction
                Console.WriteLine("Enhancement id {0} added", enhancement.ticketId);

            } 
            catch(Exception ex)
            {
                Console.WriteLine("the catch happened for AddEnhancement");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
