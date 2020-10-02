using System.IO;

public class AccessData
{

    private string file = "Ticket.csv";
    public string AccessDataFile => file;

    public bool DoesFileExist()
    {
        if (File.Exists(file))
        {
            return true;
        }
        else
        { 
            return false;
        }
    }




}
