using System.Net.Sockets;

public class NPC : IInteractable
{
    //her under er der attributes til NPC'erne
    private string nameNPC;
    private string fileID;
    private string fileName;
    public bool ifInteracted;
    
    //constructor her har den samme navn som klassen, 
    public NPC (string nameNPC, string fileID, bool ifInteracted = false)
    {
        this.nameNPC = nameNPC;
        this.fileID = fileID;
        this.ifInteracted = ifInteracted;
    }
    //her under står koden for hvad der vises til spilleren i spillet om NPC, og dens voice lines. 
    public void ShowInformation()
    {

        Shell.PrintLine($"\nHello im {nameNPC}\n");
        
        Shell.PrintLine(PrettyPrinter.TextToString(FileName()));
        
        
    }
    public string FileName()
    {
        return fileName = fileID + ".txt";
    }

    public string GetNameNPC() {
        return nameNPC;
    }

}