/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  

  public World () {
    Space dryCave = new Space("a cave");
    Space stone = new Space("a stone");
    Space waterStream = new Space("a water stream", "Wonder were it leads");
    Space oldTree = new Space("the old Tree", "Birds are singing a wonderfull melodi");
    Space clearing = new Space("a clearing", "it's nice and bright here");
    Space fallenTreeTrunk = new Space("a fallen tree trunk");
    Space forestEdge = new Space("the forest edge");//start
    forestEdge.NPC = new NPC("NameNPC", "description", "voiceLine1");
    Space lake = new Space("a lake", "A small water stream is connected");
    Space bottomOfRavine = new Space("the bottom of a ravine", "You don't seem to be able to get up");
    Space waterfall = new Space("a waterfall", "how intriguing");
    Space flower = new Space("a flower", "The flower smells great");
    Space field = new Space("a field");
    Space wetCave = new Space("a cave", "It's behind a waterfall");
    Space foxDen = new Space("a fox den", "Wonder who made this");
    Space smallRavine = new Space("a small ravine", "It's scary standing this close to the edge");
    Space crossroad = new Space("a crossroad");
    Space tunnel = new Space("a tunnel", "it's a tight squeeze, but you might be able i get trough");

    dryCave.AddEdge("west", stone);
    dryCave.AddEdge("inside", bottomOfRavine);
    dryCave.AddEdge("birdsong", oldTree);
    
    stone.AddEdge("south", clearing);
    stone.AddEdge("east", waterStream);
    stone.AddEdge("west", dryCave);
    
    waterStream.AddEdge("south", fallenTreeTrunk);
    waterStream.AddEdge("east", oldTree);
    waterStream.AddEdge("west", stone);
    waterStream.AddEdge("stream", lake);
    
    oldTree.AddEdge("south", forestEdge);
    oldTree.AddEdge("west", waterStream);
    
    clearing.AddEdge("north", stone);
    clearing.AddEdge("south", lake);
    clearing.AddEdge("east", fallenTreeTrunk);
    
    fallenTreeTrunk.AddEdge("north", waterStream);
    fallenTreeTrunk.AddEdge("east", forestEdge);
    fallenTreeTrunk.AddEdge("west", clearing);
    fallenTreeTrunk.AddEdge("smell", flower);
    
    forestEdge.AddEdge("north", oldTree);
    forestEdge.AddEdge("south", field);
    forestEdge.AddEdge("west", fallenTreeTrunk);
   
    lake.AddEdge("north", clearing);
    lake.AddEdge("south", waterfall);
    lake.AddEdge("stream", waterStream);
    
    bottomOfRavine.AddEdge("outside", dryCave);
    
    waterfall.AddEdge("north", lake);
    waterfall.AddEdge("east", flower);
    waterfall.AddEdge("behind", wetCave);
    
    flower.AddEdge("east", field);
    flower.AddEdge("west", waterfall);
    flower.AddEdge("birdsong", oldTree);
    
    field.AddEdge("north", forestEdge);
    field.AddEdge("south", foxDen);
    field.AddEdge("west", flower);
    
    wetCave.AddEdge("leave", waterfall);
    wetCave.AddEdge("inside", crossroad);
    
    foxDen.AddEdge("north", field);
    foxDen.AddEdge("inside", tunnel);
    foxDen.AddEdge("smell", flower);
    
    smallRavine.AddEdge("down", bottomOfRavine);
    smallRavine.AddEdge("back", crossroad);
    
    crossroad.AddEdge("outside", wetCave);
    crossroad.AddEdge("right", tunnel);
    crossroad.AddEdge("left", smallRavine);
    
    tunnel.AddEdge("outsie", foxDen);
    tunnel.AddEdge("tunnel", crossroad);
    
    
    this.entry = forestEdge;

  }
  
  public Space GetEntry () {
    return entry;
  }
}

