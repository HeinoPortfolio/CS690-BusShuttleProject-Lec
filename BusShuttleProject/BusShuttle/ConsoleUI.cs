using Spectre.Console;

namespace BusShuttle;
public class ConsoleUI

{
    //FileSaver fileSaver;

    DataManager dataManager;

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
            
            string command;

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
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}