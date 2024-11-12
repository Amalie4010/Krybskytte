namespace Krybskytte;

class CommandInteract : BaseCommand, ICommand
{


    public CommandInteract()
    {
        description = "Interact with NPC";
    }

    public void Execute(Context context,string command, string[] parameters)
    {
        Console.WriteLine("Interact with NPC");
        if (context.GetCurrent().NPC != null)
        {
            context.GetCurrent().NPC.showInformation();
            Inventory.AddItem(); 
        }
        else
        {
            Console.WriteLine("NPC not found");
            ;
        }
    }
    
    
    /*
    public void Execute(Context context, string command, string[] parameters)
    {
        throw new NotImplementedException();
    }

    
    public string GetDescription()
    {
        throw new NotImplementedException();
    }
    */
}