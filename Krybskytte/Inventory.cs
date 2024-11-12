// This is the inventory

static class Inventory {
    static private int size = 5;
    static private Items[] stuff;
    static private int full;

    static Inventory() {
        stuff = new Items[size];
    }

    //Generates an item and adds it to your inventory
    public static void AddItem() {
        Items newItem = new Items();
        
        for (int i = 0; i < stuff.Length; i++) {
            if (stuff[i] == null) {
                stuff[i] = new Items();
                return;
            }
            else {
                full++;
                
                if (full == stuff.Length) {
                    PrettyPrinter.WriteInventoryFull();
                    full = 0;
                    return;
                }
            }
        }
    }

    //Removes an item from the inventory
    public static void RemoveItem() {
        for (int i = 0; i < stuff.Length; i++) {
            if (stuff[i] != null) {
                stuff[i] = null;
                return;
            }
        }
    }

    //Shows what's in the inventory
    public static Items[] GetStuff() {
        return stuff;
    }
}