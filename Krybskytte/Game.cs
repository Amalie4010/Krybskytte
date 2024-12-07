/* Main class for launching the game
 */

using Krybskytte;

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry()); 
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  static Enemy    enemy    = new Enemy(world.GetEntry(), context);
  public static GameState gameState = new GameState(enemy, world, context);
  static Traps traps = new Traps(context, gameState);


    private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("quit", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("inventory", new CommandInventory());
    registry.Register("interact", new CommandInteract()); // når man skrive "interact", så executer commandinteract. 
  }

    private static void InitShell () 
    {
      Shell.registry = registry;
    }
  
  static void Main (string[] args) {

    
    if (gameState.TurnsUntilNextCycle() == 5 && gameState.DaysRequiredToWin() == 10)
    {
      Shell.PrintLine(PrettyPrinter.TextToString("Introduktion.txt"));
    }
    
    
    

    
    context.GetCurrent().Welcome();
    InitShell();
    InitRegistry();
    
    while (context.IsDone()==false) {
      Shell.Print("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
      // enemy.HuntOnce(); // Hvis denne linje tilføjes, vil Enemy jagte spilleren efter hver kommando spilleren skriver. (Pt. dør spilleren bare instantly)
    }

    if (gameState.HasWon())
    {
      Shell.PrintLine("You won, nice!");
    } 
    else if (gameState.HasLost() && gameState.DaysRemainingToWin == gameState.DaysRequiredToWin)
    {
      Shell.PrintLine("you hear your family arriving while you slowly bleed out" +
                      "\nBam!! they also get shot," +
                      "\nthey call out your name in tears," +
                      "\nyou slowly loose your hearing and everything goes black." +
                      "\nYou lost...");
    } 
    else if (gameState.HasLost())
    {
      Shell.PrintLine("You lost");
    }
    
  }
}
