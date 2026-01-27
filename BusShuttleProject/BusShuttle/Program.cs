namespace BusShuttle;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        string mode= AskForInput("Please select mode(driver OR manager): ");

        if (mode =="driver"){

            string command;

            do{
                
                string stopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter numbered of boarded passengers: "));
            
                // Append data to a file
                File.AppendAllText("passenger-data.txt", stopName+":"+boarded+Environment.NewLine);
                
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
