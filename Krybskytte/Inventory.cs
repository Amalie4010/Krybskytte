// This is the inventory

static class Inventory {
    static private int size = 5;
    static private Items[] stuff;
    static private int full;

    static private int count;

    static Inventory() {
        stuff = new Items[size];
    }

    //Generates an item and adds it to your inventory
    public static void AddItem() {
        Items newItem = new Items();
        if (count >= 0 && count >= size) {
            stuff[count] = newItem;
            count++;
            return;
        }
        else {
            Console.WriteLine("No space in inventory");
            return;
        }
    }

    //Removes an item from the inventory
    public static void RemoveItem() {
        if (count >= 0) {
            stuff[count] = null;
            count--;
            return;
        }
        else {
            Console.WriteLine("This area contains a trap, but you have no items to remove it.");
            return;
        }
    }

    //Shows what's in the inventory
    public static void GetStuff() {
        Console.WriteLine("Your inventory contains: ");
        foreach (var item in stuff) {
            if (item != null) {
                Console.Write("- ");
                Console.WriteLine(item.GetItemName());
            }
        }
    }
}