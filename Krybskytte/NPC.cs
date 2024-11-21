using System.Net.Sockets;

public class NPC : IInteractable
{
    //her under er der attributes til NPC'erne
    public string nameNPC;
    public string descriptionNPC;
    public string vl2NPC;
    
    
    //constructor her har den samme navn som klassen, 
    public NPC (string nameNPC, string descriptionNPC, string vl2NPC)
    {
        this.nameNPC = nameNPC;
        this.descriptionNPC = descriptionNPC;
        this.vl2NPC = vl2NPC;
        
    }
    
    
    //her under står koden for hvad der vises til spilleren i spillet om NPC, og dens voice lines. 
    public void ShowInformation()
    {
        Shell.PrintLine($"Hello im a {nameNPC}\n \n" + 
                    $"description {descriptionNPC} \n"+
                    $"voice line 1 {vl2NPC}"); 
    }

    
}