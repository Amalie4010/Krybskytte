/* Help command
 */

class CommandHelp : BaseCommand, ICommand {
  Registry registry;
  
  public CommandHelp (Registry registry) {
    this.registry = registry;
    this.description = "Display a help message";
  }
  
  public void Execute (Context context, string command, string[] parameters) {
    string[] commandNames = registry.GetCommandNames();
    Array.Sort(commandNames);
    PrettyPrinter.PrintAllCommands(commandNames);
  }
}
