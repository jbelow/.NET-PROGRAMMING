﻿using System;

namespace CourseGPA
{
    class Program
    {
        static void Main(string[] args)
        {
             int i;
            // accumulator needed to calculate GPA
            int gradePoints = 0;
            for (i = 0; i < 7; i++)
            {
                // ask a question
                Console.WriteLine("Enter a course (Y/N)?");
                // input the response
                string resp = Console.ReadLine().ToUpper();
                // if the response is anything other than "Y", stop asking
                if (resp != "Y")
                {
                    break;
                }
                // prompt for course name
                Console.WriteLine("Enter the course name.");
                Console.ReadLine();
                // prompt for course grade
                Console.WriteLine("Enter the course grade.");
                // save the course grade
                string grade = Console.ReadLine().ToUpper();
                // add to accumulator - if
                if (grade == "A")
                {
                   gradePoints += 4;
                } else if (grade == "B")
                {
                   gradePoints += 3;
                } else if (grade == "C")
                {
                   gradePoints += 2;
                } else if (grade == "D")
                {
                   gradePoints += 1;
                }
            }
            // calculate GPA
            double GPA = (double)gradePoints / i;
            // display GPA
            Console.WriteLine("Your GPA is {0:N2}", GPA);
        }
    }
}