public class NPC
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
    public void showInformation()
    {
        Console.WriteLine($"Hello im a {nameNPC}\n \n" + $"asd {descriptionNPC} \n"+"a{vl2NPC}"); //Ikke færdig
    }

    public void giveItem() //her skal metoden være for NPC'erne kan give items til spilleren
    {
        
    }

    public void spawnNPC()
    {
        
        
    }
}