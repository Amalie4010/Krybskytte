
public class Items
{
    
    //ATTRIBUTES
    
    //List of possible item names
    private string[] names =
    {
        "Screwdriver",
        "Hammer",
        "Lock-pick"
    };
    
    //Name of item
    private string name;

    
    //CONSTRUCTORS
    
    //Instantiate a random item
    public Items()
    {
        Random randomInt = new Random();
        int randomNum  = randomInt.Next(0, 3); //Create number between 0 and 2

        name = names[randomNum];
    }

    //Instantiate specific item. Make public to use
    private Items(string itemName)
    {
        name = itemName;
    }
    
    
    //METHODS

    //Return name of Item
    public string GetItemName()
    {
        return this.name;
    }

    
    
    
    
}