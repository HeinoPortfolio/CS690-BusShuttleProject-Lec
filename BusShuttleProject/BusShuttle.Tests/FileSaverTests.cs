namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    // Constructor
    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        File.Delete(testFileName);
        fileSaver = new FileSaver(testFileName);
    }


    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);

        Assert.Equal("Hello, World!"+Environment.NewLine, contentFromFile);
    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {
        // Create some sample data
        Stop sampleStop= new Stop("MyStop");
        Loop sampleLoop = new Loop("MyLoop");
        Driver sampleDriver = new Driver("Sample");

        // Create the passenger data object/instance
        PassengerData sampleData = new PassengerData(5, sampleStop,
            sampleLoop, sampleDriver);
        
        // Append to the sample file
        fileSaver.AppendData(sampleData);

        var contentFromFile = File.ReadAllText(testFileName);

        Assert.Equal("Sample:MyLoop:MyStop:5"+Environment.NewLine, contentFromFile);
    }
}