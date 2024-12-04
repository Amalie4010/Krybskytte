/* Space class for modeling spaces (rooms, caves, ...)
 */

using System.Dynamic;

class Space : Node {
  private string description;
  public bool trapped;
  public IInteractable? interactable;
  public bool isTraversableByEnemy;

  public Space (String name, string description = "", bool isTraversableByEnemy = true) : base(name)
  {
    this.description = description;
    this.trapped = false;
    this.isTraversableByEnemy = isTraversableByEnemy;
    Traps.places.Add(this);//Adds all objets from spaces
  }
  
  public void Welcome () {

    Shell.ClearConsole();
    //PrettyPrinter.WriteDividerLine();
    Shell.WriteLocation(name, description);
    HashSet<string> exits = edges.Keys.ToHashSet();


    Shell.WriteExits(exits);
    if (interactable != null)
    {
         Shell.PrintLine(interactable.GetSelfAnnouncementMessage());
    }    
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
