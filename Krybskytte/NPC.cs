using System.Net.Sockets;

public class NPC : IInteractable
{
    //her under er der attributes til NPC'erne
    private string nameNPC;
    private string fileID;
    private string fileName;
    public bool hasBeenInteractedWith;
    
    //constructor her har den samme navn som klassen, 
    public NPC (string nameNPC, string fileID, bool hasBeenInteractedWith = false)
    {
        this.nameNPC = nameNPC;
        this.fileID = fileID;
        this.hasBeenInteractedWith = hasBeenInteractedWith;
    }
    //her under står koden for hvad der vises til spilleren i spillet om NPC, og dens voice lines. 
    public void Interact()
    {
        Shell.PrintLine($"\nHello im {nameNPC}\n");
        Shell.PrintLine(PrettyPrinter.TextToString(FileName()));

        if (hasBeenInteractedWith)
        {
            Shell.PrintLine("You already received an item from me");
            return;
        }
        if (Inventory.GetCount() >= Inventory.GetSize())
        {
            Shell.PrintLine("You don't seem to be able to carry any more!\nCome back when you have more space in you inventory,\nthen i will give you an item ");
            return;
        }

        Inventory.AddItem(); //npc giver item med koden som står i inventory
        Shell.PrintLine("Here is an item!"); // Der står at NPC giver item
        hasBeenInteractedWith = true;
    }
    public string FileName()
    {
        return fileName = fileID + ".txt";
    }

    public string GetNameNPC() {
        return nameNPC;
    }

    public string GetSelfAnnouncementMessage()
    {
        return $"You see that {nameNPC} is here!";
    }
}