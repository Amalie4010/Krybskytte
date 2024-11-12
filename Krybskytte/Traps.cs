
class Traps {
    public static List<Space> places = new List<Space>();
   
    GameState gameState;
    Context context;

    public Traps(Context context, GameState gameState) { 
        this.context = context;
        this.gameState = gameState;
    }
    public void AddTrap() {
        Random random = new Random();
        int place = random.Next(0, places.Count);

        places[place].traped = true;
    }

    public void RemoveTrap() {
        context.GetCurrent().traped = false;
        Inventory.RemoveItem();        
    }

    public void FindTrap() {
        if (gameState.GetState() == GameState.States.Day) {
            RemoveTrap();
        }
        else {
            Console.WriteLine("That path contains a trap!\nQuick move somewere else");
        }
    }

}