
class Traps {
    public static List<Space> places = new List<Space>();
   
    GameState gameState;
    Context context;

    public Traps(Context context, GameState gameState) {
        this.context = context;
        this.context.SetTrap(this);
        this.gameState = gameState;
        this.gameState.SetTraps(this);
    }
    public void AddTrap() {
        Random random = new Random();
        int place = random.Next(0, places.Count);

        places[place].traped = true;
    }

    public void RemoveTrap(Space spaceToRemoveTrapFrom) {
        spaceToRemoveTrapFrom.traped = false;
        Inventory.RemoveItem();
        Console.WriteLine("Removed trap and used item!");
    }
}