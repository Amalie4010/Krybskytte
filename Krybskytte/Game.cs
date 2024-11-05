/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  static Enemy    enemy    = new Enemy(world.GetEntry(), context);
  static GameState gameState = new GameState(enemy, world, context);

    private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("inventory", new CommandInventory());
  }

    static void Main (string[] args) {
    Console.WriteLine("Welcome to The Wild forrest. \n You're a wolf, hunted by Mr.Poacher, who's after your Pelt to sell on the black market. \n Outsmart him, survive 10 days, and claim your freedom.");
    InitRegistry();
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
      // enemy.HuntOnce(); // Hvis denne linje tilføjes, vil Enemy jagte spilleren efter hver kommando spilleren skriver. (Pt. dør spilleren bare instantly)
    }

    if (gameState.HasWon())
    {
        Console.WriteLine("You won, nice!");
    } else if (gameState.HasLost())
    {
            Console.WriteLine("You lost");
    }
  }
}
