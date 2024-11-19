//display inventory
class CommandInventory : BaseCommand, ICommand {

    public CommandInventory() {
        this.description = "Display your inventory";
    }

    public void Execute(Context context, string command, string[] parameters) {
        Shell.WriteInventoryContent(Inventory.GetStuff());
    }
}