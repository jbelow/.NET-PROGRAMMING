using System;
using System.IO;
public class ReadData
{

    public void OutputData()
    {
        AccessData access = new AccessData();
        string dataFile = access.AccessDataFile;

        StreamReader sr = new StreamReader(dataFile);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            Console.WriteLine(line);
        }
        sr.Close();

    }
}