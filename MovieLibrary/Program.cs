using System;
using System.IO;
using NLog.Web;


namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {


            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            // create instance of Logger
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program started");

            string file = "ml-latest-small/movies.csv";
            string choice = "";

            do
            {

                if (File.Exists(file))
                {
                    Console.WriteLine("1) Read moive data from file.");
                    Console.WriteLine("2) Create new moive.");
                    Console.WriteLine("Enter any other key to exit.");
                    choice = Console.ReadLine();


                    //reading the moive data
                    if (choice == "1")
                    {

                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {

                            string display = "";
                            string moiveName = "";
                            string genres = "";
                            string[] genreList;
                            string genreDisplay = "";

                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');

                            for (int i = 0; i < arr.Length - 2; i++)
                            {

                                if (i == 0)
                                {
                                    moiveName = arr[i + 1];
                                }
                                else
                                {
                                    moiveName += "," + arr[i + 1];
                                }
                            }

                            genres = arr[arr.Length - 1];
                            // Console.WriteLine(genre);
                            genreList = genres.Split("|");
                            for (int i = 0; i < genreList.Length; i++)
                            {

                                //this is to check the first one
                                if (genreList.Length > 1 && i != genreList.Length - 1)
                                {
                                    genreDisplay += genreList[i] + ", ";
                                }
                                else
                                {
                                    genreDisplay += genreList[i];
                                }

                            }

                            display = "Id: " + arr[0] + " Title: " + moiveName + " Genres: " + genreDisplay;

                            Console.WriteLine(display);
                        }
                        sr.Close();
                    }

                    //creating a new moive
                    else if (choice == "2")
                    {
                        string newMoive = "";
                        int genres;
                        string lastId = "";
                        string moiveName = "";
                        Boolean isTitleDifferent = true;


                        Console.WriteLine("Enter the Movie Title.");
                        string userInput = Console.ReadLine();

                        //checking the name to make sure it isn't a duplicate and getting the last id
                        StreamReader sr = new StreamReader(file);


                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');

                            //this is to check the first one
                            for (int i = 0; i < arr.Length - 2; i++)
                            {

                                if (i == 0)
                                {
                                    moiveName = arr[i + 1];
                                }
                                else
                                {
                                    moiveName += "," + arr[i + 1];
                                }

                                if (userInput == moiveName)
                                {
                                    isTitleDifferent = false;
                                }
                            }

                            // Console.WriteLine(arr);
                            lastId = arr[0];
                        }
                        sr.Close();

                        if (isTitleDifferent)
                        {
                            //starting to write the new moive
                            StreamWriter sw = new StreamWriter(file, true);

                            newMoive += (Convert.ToInt32(lastId) + 1) + ",";
                            newMoive += userInput + ",";

                            Console.WriteLine("How many genres are there for this movie?");
                            userInput = Console.ReadLine();
                            genres = Convert.ToInt32(userInput);

                            if (genres == 0)
                            {
                                newMoive += "(no genres listed)";
                            }
                            else
                            {
                                for (int j = 0; j < genres; j++)
                                {
                                    Console.WriteLine("Enter a genres:");
                                    userInput = Console.ReadLine();
                                    newMoive += userInput;
                                    if (j != genres - 1)
                                    {
                                        newMoive += "|";
                                    }
                                }
                            }

                            Console.WriteLine(newMoive);
                            sw.WriteLine(newMoive);

                            sw.Close();
                        }
                        else
                        {
                            logger.Warn("Error: There is already a moive wih that name");
                            
                        }
                        
                    }
                } else
                { //if else check for file
                    logger.Warn("File does not exist. {file}", file);
                }

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
