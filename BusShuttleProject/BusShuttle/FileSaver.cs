
namespace BusShuttle;

using System.IO;

public class FileSaver
{
   string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;

        // Check to see if the file exists
        if(!File.Exists(this.fileName)){ 
            // Create the file
            File.Create(this.fileName).Close();
        }
    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line+Environment.NewLine);
    }

    // To save passenger data
    public void AppendData(PassengerData data)
    {
        File.AppendAllText(this.fileName, data.Driver+":"+data.Loop
            +":"+data.Stop+":"+data.Boarded+Environment.NewLine);
    }

}