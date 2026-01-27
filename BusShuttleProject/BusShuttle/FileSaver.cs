
namespace BusShuttle;

using System.IO;

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