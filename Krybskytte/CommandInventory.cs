//display inventory
class CommandInventory : BaseCommand, ICommand {

    public CommandInventory() {
        this.description = "Display a inevntory";
    }

    public void Execute(Context context, string command, string[] parameters) {
        Inventory.GetStuff();
    }
}