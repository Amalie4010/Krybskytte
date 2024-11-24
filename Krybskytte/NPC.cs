using System.Net.Sockets;

public class NPC
{
    //her under er der attributes til NPC'erne
    public string nameNPC;
    public string descriptionNPC;
    public string vl2NPC;
    public string fileName; 
    
    //constructor her har den samme navn som klassen, 
    public NPC (string nameNPC, string descriptionNPC, string vl2NPC)
    {
        this.nameNPC = nameNPC;
        this.descriptionNPC = descriptionNPC;
        this.vl2NPC = vl2NPC;
        
    }
    
    
    //her under står koden for hvad der vises til spilleren i spillet om NPC, og dens voice lines. 
    public void showInformation()
    {
        Console.WriteLine($"\n Hello im  {nameNPC}\n " + 
                          $" {descriptionNPC} \n"+
                          $" {vl2NPC}"); 
        /*
        PrettyPrinter.Printer(fileName);
        */
    }
/*
    public string FileName()
    {
        return fileName = "NPC-" + nameNPC + ".txt";
    }
    */
}