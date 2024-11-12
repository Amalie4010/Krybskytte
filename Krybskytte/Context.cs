/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  Traps traps;
  bool done = false;
  
  public Context (Space node, Traps traps) {
    current = node;
    this.traps = traps;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next.traped == true ) {
        traps.FindTrap();
        current.Welcome();
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

