// This is the inventory

class Inventory {
    private int size = 5;
    private Items[] stuff;
    private int j;

    public Inventory() {
        stuff = new Items[size];
    }

    //Generates an item and adds it to your inventory
    public void AddItem() {
        Items newItem = new Items();
        
        for (int i = 0; i < stuff.Length; i++) {
            if (stuff[i] == null) {
                stuff[i] = new Items();
                return;
            }
            else {
                j++;
                
                if (j == stuff.Length) {
                    Console.WriteLine("");
                    Console.WriteLine("No space in inventory");
                    j = 0;
                    return;
                }
            }
        }
    }

    //Removes an item from the inventory
    public void RemoveItem() {
        for (int i = 0; i < stuff.Length; i++) {
            if (stuff[i] != null) {
                stuff[i] = null;
                return;
            }
        }
    }

    //Shows what's in the inventory
    public void GetStuff() {
        Console.WriteLine("");
        Console.WriteLine("Your inventory contains: ");
        foreach (var item in stuff) {
            if (item != null) {
                Console.Write("- ");
                Console.WriteLine(item.GetItemName());
            }
        }
    }
}