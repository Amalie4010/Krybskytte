// This is the inventory

class Inventory {
    private List<string> stuff = new List<string>();
    private int size = 5;
    
    //Generates an item and adds it to your inventory
    public void GenerateItem() {
        string newItem = new Items().GetItemName();

        if (stuff.Count < size) {
            stuff.Add(newItem);
        }
        else {
            Console.WriteLine("No space in inventory");
        }
    }
    
    //Removes an item from the inventory
    public void RemoveItem() {
        stuff.RemoveAt(0);
    }
    
    //Shows what's in the inventory
    public void GetStuff() {
        foreach (var item in stuff) {
            Console.WriteLine("Your inventory contains: ");
            Console.WriteLine(item);
        }
    }
}