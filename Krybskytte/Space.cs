/* Space class for modeling spaces (rooms, caves, ...)
 */


class Space : Node 
{
  private string description;
  public NPC? NPC;
  
  public Space (String name, string description = "") : base(name)
  {
    this.description = description;
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
