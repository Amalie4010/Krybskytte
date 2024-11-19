/* Command for transitioning between spaces
 */

using System.Linq.Expressions;

class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Follow an exit";
  }
  
  public void Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      PrettyPrinter.InvalidCommand();
      return;
    }

    try
    {
      context.Transition(parameters[0]);

     // Use one turn for player

      GameState.gameState.UseTurn();
     
    }
    
    catch (KeyNotFoundException)
    {
      PrettyPrinter.InvalidCommand();
    }
    
  }
}
