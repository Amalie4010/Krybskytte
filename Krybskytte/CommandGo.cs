/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Follow an exit";
  }
  
  public void Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      Console.WriteLine("I don't seem to know where that is 🤔");
      return;
    }
    context.Transition(parameters[0]);

    // Use one turn for player

    GameState.gameState.UseTurn();
    
    //Generates a random item on chance
    Random random = new Random();
    int luckyNum = random.Next(1, 100);
    
    //Console.WriteLine(luckyNum);
    
    if (luckyNum < 15)
    {      
      Inventory.AddItem();
      Console.WriteLine("You found an item!");
    }

  }
}
