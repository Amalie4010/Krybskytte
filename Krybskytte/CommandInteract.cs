namespace Krybskytte;

class CommandInteract : BaseCommand, ICommand
{


    public CommandInteract()
    {
        description = "Interact with NPC";
    }

    public void Execute(Context context,string command, string[] parameters)
    {
        /* koden context.GetCurrent().NPC != null, denne del ser om der er en NPC på current space man er på
         hvis der er, ved at se om NPC er lig med ikke null hvis det ikke er lig med null, så tager den
         informationen fra get
         */
        Shell.PrintLine("Interact with NPC"); 
        if (context.GetCurrent().NPC != null)  
        {
            context.GetCurrent().NPC.ShowInformation(); // den viser information om NPC, name, desciption, vl1
            Inventory.AddItem(); //npc giver item med koden som står i inventory

            if (Inventory.GetCount() != Inventory.GetSize())
            {
                
                  Shell.PrintLine($"{context.GetCurrent().NPC.nameNPC} gave you an item"); // Der står at NPC giver item
            }
           

        }
    }
    
    
}