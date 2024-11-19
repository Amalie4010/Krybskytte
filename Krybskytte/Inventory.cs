// This is the inventory

static class Inventory {
    static private int size = 5;
    static private Items[] inventory = new Items[size];
    static private int full;

    static private int count;

    static Inventory() {
        inventory = new Items[size];
    }

    public static int GetCount()
    {
        return count;
    }

    //Generates an item and adds it to your inventory
    public static void AddItem() {
        Items newItem = new Items();
        if (count >= 0 && count <= size) {
            inventory[count] = newItem;
            count++;
            return;
        }
        else {
            Shell.PrintLine("No space in inventory");
            return;

        }
    }

    //Removes an item from the inventory
    public static void RemoveItem() {
        if (count >= 0) {
            inventory[count - 1] = null;
            count--;
            return;
        }
    }

    //Shows what's in the inventory
    public static Items[] GetInventory() {
        return inventory;
    }
}