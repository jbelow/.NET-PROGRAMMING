using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TicketSystem
{
    public class TaskFile
    {
        // public property
        public string filePath { get; set; }
        public List<Task> Task { get; set; }


        // constructor is a special method that is invoked
        // when an instance of a class is created
        public TaskFile(string taskFilePath)
        {
            filePath = taskFilePath;
            Task = new List<Task>();

            // to populate the list with data, read from the data file
            try
            {
                StreamReader sr = new StreamReader(filePath);

                // first line contains column headers
                sr.ReadLine();
                
                while (!sr.EndOfStream)
                {

                    // create instance of Task class
                    Task task = new Task();

                    string line = sr.ReadLine();

                    string[] taskDetails = line.Split(',');
                    task.ticketId = UInt64.Parse(taskDetails[0]);
                    task.summary = taskDetails[1];
                    task.status = taskDetails[2];
                    task.priority = taskDetails[3];
                    task.submitter = taskDetails[4];
                    task.assigned = taskDetails[5];
                    task.watching = taskDetails[6].Split('|').ToList();
                    task.projectName = taskDetails[7];
                    task.dueDate = DateTime.Parse(taskDetails[8]);

                    Task.Add(task);
                }
                // close file when done
                sr.Close();
                Console.WriteLine("Tasks in file {0}", Task.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("the catch happened for the TaskFile");
                Console.WriteLine(ex.Message);
            }
        }


        public void AddTask(Task task)
        {
            try
            {
                Console.WriteLine("trying to write a new line");
                // first generate task id
                task.ticketId = Task.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);

                sw.WriteLine($"{task.ticketId},{task.summary},{task.status},{task.priority},{task.submitter},{task.assigned},{string.Join("|", task.watching)},{task.projectName},{task.dueDate}");
                sw.Close();

                // add task details to Lists
                Task.Add(task);

                // log transaction
                Console.WriteLine("Task id {0} added", task.ticketId);

            } 
            catch(Exception ex)
            {
                Console.WriteLine("the catch happened for AddTask");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
