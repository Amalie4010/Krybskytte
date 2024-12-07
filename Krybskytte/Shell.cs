
using System.Net.Mime;
using static GameState;

static class Shell
{
    public static Registry registry;
    
    public static void PrintLine(string text)
    {
        Console.WriteLine(text);
    }
    
    public static void Print(string text)
    {
        Console.Write(text);
    }
    
    public static void ClearConsole()
    {
        Console.Clear();
    }
        
    public static void WriteLocation(string name, string desc)
    {
        Console.WriteLine("You are now at " + name);
        if (desc != "" && Game.gameState.GetState() == States.Day)
        {
            Console.WriteLine($"{desc}");
        }
        else if (Game.gameState.GetState() == States.Night) {
            Console.WriteLine("It's to dark to see any details");
        }
    }

    public static void WriteExits(HashSet<string> exits)
    {
        Console.WriteLine("\nExits:");
        foreach (String exit in exits)
        {
            Console.WriteLine("- " + exit);
        }
        Console.WriteLine();
    }

    public static void InvalidCommand()
    {
        Console.WriteLine("Invalid action (write, 'help' for help)");
    }

    public static void PrintAllCommands(string[] commandNames)
    {
        // find max length of command name
        int max = 0;
        foreach (String commandName in commandNames)
        {
            int length = commandName.Length;
            if (length > max) max = length;
        }

        // present list of commands
        Console.WriteLine("Commands:");
        foreach (String commandName in commandNames)
        {
            string description = registry.GetCommand(commandName).GetDescription();
            Console.WriteLine(" - {0,-" + max + "} " + description, commandName);
        }
    }

    public static void WriteDangerMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void WriteChangeInTime(States state)
    {
        string stringToPrint;
        switch (state)
        {
            case States.Day:
                stringToPrint = "The day shines upon you!";
                break;
            case States.Night:
                stringToPrint = "The night has fallen!";
                break;
            default:
                return;
        }
        Console.WriteLine(stringToPrint);
    }

    public static void WriteInventoryFull()
    {
        Console.WriteLine("No space in inventory");
    }

    public static void WriteInventoryContent(Items[] items)
    {
        Console.WriteLine("\nYour inventory contains: ");
        foreach (Items item in items)
        {
            if (item != null)
            {
                Console.Write("- ");
                Console.WriteLine(item.GetItemName());
            }
        }
    }
    
    
}