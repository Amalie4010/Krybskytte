


/*HOW TO USE
 
 1)
Create text file in Text_Files folder

2)
Call method using text file name
PrettyPrinter.Printer("FileName.txt");

*/

using Microsoft.Win32;
using System;
using static GameState;

static class PrettyPrinter
{
 
    //ATTRIBUTES
    public static Registry registry;
    
    //CONSTRUCTORS
    
    
    //METHODS
    
    
    //SOURCE: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
    public static void Printer(string directory)
    {
        
        //Get full directory path
        directory = FindLocalPath() + "/Text_Files/" + directory;
        
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader(directory);
        
        //Read the first line of text
        string line = sr.ReadLine();
        
        //Continue to read until you reach end of file
        while (line != null)
        {
            //write the line to console window
            Console.WriteLine(line);
            
            //Read the next line
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
    }


    public static void ClearConsole()
    {
        Console.Clear();
    }

    public static void WriteDividerLine()
    {
        Console.WriteLine("- - - - - - - - - - - - -");
    }
    public static void WriteLocation(string name, string desc)
    {
        Console.WriteLine("You are now at " + name);
        if (desc != "" && Game.gameState.GetState() == States.Day)
        {
            Console.WriteLine($"{desc}");
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

    public static string FindLocalPath()
    {

        string localDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        return localDir;
    }



}