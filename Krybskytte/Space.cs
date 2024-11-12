/* Space class for modeling spaces (rooms, caves, ...)
 */

using System.Dynamic;

class Space : Node {
  private string description;
  public bool traped;
  public NPC? NPC;
  public Space (String name, string description = "", bool traped = false) : base(name)

  {
    this.description = description;
    this.traped = traped;
    Traps.places.Add(this);//Adds all objets from spaces
  }
  
  public void Welcome () {

    PrettyPrinter.ClearConsole();
    //PrettyPrinter.WriteDividerLine();
    PrettyPrinter.WriteLocation(name, description);
    HashSet<string> exits = edges.Keys.ToHashSet();


    PrettyPrinter.WriteExits(exits);
    
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
