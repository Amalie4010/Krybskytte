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
    if (next.traped == true) 
    {
        if (GameState.gameState.GetState() == GameState.States.Day)
        {
            if (Inventory.GetCount() > 0)
            {
                traps.RemoveTrap(next);
            }
            else
            {
                Shell.PrintLine("This place contains a trap. Watch out when night comes");
            }
            current.Goodbye();
            current = next;
            current.Welcome();
        }
        else
        {
            Shell.PrintLine("That path contains a trap!\nQuick move somewere else");
        }
            //current.Welcome();
        } 
    else {
      current.Goodbye();
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

