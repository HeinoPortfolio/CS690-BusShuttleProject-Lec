using Spectre.Console;
using Spectre.Console.Cli;

namespace BusShuttle;
public class ConsoleUI

{

    DataManager dataManager;

    string command;

    public ConsoleUI()
    {
        // Instantiate the data manager
        dataManager = new DataManager();
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
                .Title("Select a driver").AddChoices(dataManager.Drivers));
            Console.WriteLine("Your selected driver: " + selectedDriver.Name); 

            // Select a loop
            Loop selectedLoop = AnsiConsole.Prompt(new SelectionPrompt<Loop>()
                .Title("Select a loop").AddChoices(dataManager.Loops));
            Console.WriteLine("Your selected loop: " + selectedLoop.Name); 
            
           //string command;

            do{
                // Select a stop 
                Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>()
                    .Title("Select a stop")
                    .AddChoices(selectedLoop.Stops));
                Console.WriteLine("Your selected stop: " + selectedStop.Name); 

                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of boarded passengers: "));

                // Passenger data
                PassengerData data = new PassengerData(boarded,
                    selectedStop, selectedLoop, selectedDriver);
                
                // Append data to a file
                dataManager.AddNewPassengerData(data);
                
                // Select whether to continue or end
                command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What's next?")
                    .AddChoices(new[]
                    {
                        "continue","end"
                    }));
                    
            }while(command != "end");
        }
        else if(mode == "manager")
        {
       
            do
            {
               
                // Select whether to continue or end
                command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What's do you want to do?")
                    .AddChoices(new[]
                    {
                        "add stop", "delete stop", "list stops","show busiest stop", "end" 
                    }));

                // Add stop to the route
                if( command == "add stop")
                {
                    // Ask for a stop name
                    var newStopName= AnsiConsole.Prompt(new TextPrompt<string>("Enter new stop name: "));
                    dataManager.AddStop(new Stop(newStopName));

                }else if (command == "delete stop")
                {
                    // Select a stop to delete
                    Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>()
                        .Title("Select a stop")
                        .AddChoices(dataManager.Stops));

                    Console.WriteLine("Your selected stop: " + selectedStop.Name);
                    dataManager.RemoveStop(selectedStop);
                }
                else if (command == "list stops")
                {
                    Console.WriteLine("List of stops:");
                    
                    var table = new Table();
                    table.AddColumn("Stop Name");

                    foreach (var stop in dataManager.Stops)
                    {
                        table.AddRow(stop.Name);
                    }
                    AnsiConsole.Write(table);
                    Console.WriteLine("\n");
                }
                else if (command == "show busiest stop")
                {
                    var result = Reporter.FindBusiestStop(dataManager.PassengerData);
                    
                    // Display the result
                    Console.WriteLine("THe busiest stop is: " + result.Name);

                }
            }while(command != "end");
        }
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}