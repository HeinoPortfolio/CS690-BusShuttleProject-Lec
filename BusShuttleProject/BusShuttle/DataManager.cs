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

        // Add Stops to a list
        Stops = new List<Stop>();
        Stops.Add(new Stop("Music"));  
        Stops.Add(new Stop("Towers"));
        Stops.Add(new Stop("Oakwood"));
        Stops.Add(new Stop("Anthony"));
        Stops.Add(new Stop("Letterman"));

        // Assign them to the first loop
        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);

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
}