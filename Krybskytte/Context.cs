/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  Traps traps;
  bool done = false;
  
  public Context (Space node) {
    current = node;
  }
  public void SetTrap(Traps traps)
    {
        this.traps = traps;
    }
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next.trapped == true) 
    {
        if (GameState.gameState.GetState() == GameState.States.Day)
        {
            current = next;
            current.Welcome();

            if (Inventory.GetCount() > 0)
            {
                traps.RemoveTrap(next);
                Inventory.RemoveItem();
                Shell.PrintLine("You removed a trap and used an item!");
            }
            else
            {
                Shell.PrintLine("This place contains a trap. Watch out when night comes");
            }
        }
        else
        {
            Shell.PrintLine("That path contains a trap!\nQuick move somewhere else");
        }
            //current.Welcome();
    } 
    else {
      current = next;
      current.Welcome();
    }
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

