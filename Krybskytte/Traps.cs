
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

        places[place].trapped = true;
    }

    public void RemoveTrap(Space spaceToRemoveTrapFrom) {
        spaceToRemoveTrapFrom.trapped = false;
        Inventory.RemoveItem();
    }
}