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


        IInteractable? currentInteractable = context.GetCurrent().interactable;
        if (currentInteractable == null)  
        {
            Shell.PrintLine("There is nothing to interact with currently");
        } else
        {
            currentInteractable.Interact();
        } 
    }
}