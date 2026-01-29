using Spectre.Console;

namespace BusShuttle;
public class ConsoleUI

{
    FileSaver fileSaver;

    // List of loops
    List<Loop> loops;

    // List of stops
    List<Stop> stops;

    // List of drivers
    List<Driver> drivers;


    public ConsoleUI()
    {
        fileSaver = new FileSaver("passenger-data.txt");
        // Create the loops
        loops = new List<Loop>();
        // Add loops to a list
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Green"));
        loops.Add(new Loop("Blue"));

        // Add stops to a list
        stops = new List<Stop>();
        stops.Add(new Stop("Music"));  
        stops.Add(new Stop("Towers"));
        stops.Add(new Stop("Oakwood"));
        stops.Add(new Stop("Anthony"));
        stops.Add(new Stop("Letterman"));

        // Assign them to the first loop
        loops[0].Stops.Add(stops[0]);
        loops[0].Stops.Add(stops[1]);
        loops[0].Stops.Add(stops[2]);
        loops[0].Stops.Add(stops[3]);
        loops[0].Stops.Add(stops[4]);

        // Add drivers to a list
        drivers = new List<Driver>();
        drivers.Add(new Driver("Huseyin Ergin"));
        drivers.Add(new Driver("Jane Doe"));
    }
    public void Show()
    {
        
        var mode = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select mode").AddChoices(new[]
        {
            "driver","manager"
        }));

        if (mode =="driver"){


            // Select a driver
            var selectedDriver = AnsiConsole.Prompt(new SelectionPrompt<Driver>()
                .Title("Select a driver").AddChoices(drivers));
            Console.WriteLine("Your selected driver: " + selectedDriver.Name); 

            // Select a loop
            Loop selectedLoop = AnsiConsole.Prompt(new SelectionPrompt<Loop>()
                .Title("Select a loop").AddChoices(loops));
            Console.WriteLine("Your selected loop: " + selectedLoop.Name); 
            
            string command;

            do{
                // Select a stop 
                Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>()
                    .Title("Select a stop")
                    .AddChoices(selectedLoop.Stops));
                Console.WriteLine("Your selected stop: " + selectedStop.Name); 

                int boarded = int.Parse(AskForInput("Enter numbered of boarded passengers: "));

                // Passenger data
                PassengerData data = new PassengerData(boarded,
                    selectedStop, selectedLoop, selectedDriver);
                
                // Append data to a file
                fileSaver.AppendData(data);
                
                // Select whether to continue or end
                command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What's next?")
                    .AddChoices(new[]
                    {
                        "continue","end"
                    }));
                    
            }while(command != "end");
        }
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}