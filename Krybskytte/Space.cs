/* Space class for modeling spaces (rooms, caves, ...)
 */

using System.Dynamic;

class Space : Node {
  private string description;
  public bool traped;
  public Space (String name, string description = "", bool traped = false) : base(name)
  {
    this.description = description;
    this.traped = traped;
    Traps.places.Add(this);//Adds all objets from spaces
  }
  
  public void Welcome () {
    Console.WriteLine("- - - - - - - - - - - - -");
    Console.WriteLine("You are now at " + name);
    if (description != "") Console.WriteLine(description);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current paths are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - " + exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
