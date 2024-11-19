// This is the inventory

static class Inventory {
    static private int size = 5;
    static private Items[] stuff = new Items[size];
    static private int full;

    static private int count;

    static Inventory() {
        stuff = new Items[size];
    }

    public static int GetCount()
    {
        return count;
    }

    //Generates an item and adds it to your inventory
    public static void AddItem() {
        Items newItem = new Items();
        if (count >= 0 && count <= size) {
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
            stuff[count - 1] = null;
            count--;
            return;
        }
    }

    //Shows what's in the inventory
    public static Items[] GetStuff() {
        return stuff;
    }
}