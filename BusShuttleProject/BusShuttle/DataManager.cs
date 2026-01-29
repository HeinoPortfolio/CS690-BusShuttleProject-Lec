using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace BusShuttle;

 public class DataManager
{

    
    FileSaver fileSaver;
     // List of Loops
    public List<Loop> Loops {get;}
    // List of Stops
    public List<Stop> Stops {get;}
    // List of Drivers
    public List<Driver> Drivers {get;}

    public List<PassengerData> PassengerData {get;}
    
    //Constructor
    public DataManager()
    {
        
        fileSaver = new FileSaver("passenger-data.txt");

        // Create the Loops
        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();

        // Read the stops from the file
        var stopsFileContent = File.ReadAllLines("stops.txt");
        // Add Stops to a list
        foreach (var stopName in stopsFileContent)
        {
            Stops.Add(new Stop(stopName));
        }


        // Assign them to the first loop
        for(int index =0; index < Stops.Count; index++)
        {
             Loops[0].Stops.Add(Stops[index]);
        }

        // Add Drivers to a list
        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Huseyin Ergin"));
        Drivers.Add(new Driver("Jane Doe"));

        PassengerData = new List<PassengerData>();
    }

    public void AddNewPassengerData(PassengerData data)
    {
       // Save to the list
       this.PassengerData.Add(data);
       // Save to the file
       this.fileSaver.AppendData(data);
    }


    // Add a stop to the list
    public void AddStop(Stop stop)
    {
       Stops.Add(stop); 
       //Synchonize the stops
       SynchronizeStops();
    }

    // Remove a stop from a list
    public void RemoveStop(Stop stop)
    {
        Stops.Remove(stop);
        //Synchonize the stops
        SynchronizeStops();
    }

    // Synchonize the stops
    public void SynchronizeStops()
    {
        File.Delete("stops.txt");

        foreach(var stop in Stops)
        {
            File.AppendAllText("stops.txt", stop.Name+Environment.NewLine);
        }
    }
}