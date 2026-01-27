namespace BusShuttle;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileSaver fileSaver = new FileSaver("passenger-data.txt");
        string mode= AskForInput("Please select mode(driver OR manager): ");

        if (mode =="driver"){

            string command;

            do{
                
                string stopName = AskForInput("Enter stop name: ");
                int boarded = int.Parse(AskForInput("Enter numbered of boarded passengers: "));
                // Append data to a file
                fileSaver.AppendLine(stopName+":"+boarded);
                command = AskForInput("Enter command (end or continue): ");

            }while(command != "end");
        }
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}

public class FileSaver
{
   string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;
        // Create the file
        File.Create(this.fileName).Close();

    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line+Environment.NewLine);
    }




}
