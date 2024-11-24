/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  


  public World () {
        //Making spaces
        Space treeHouse = new Space("a tree house", "You see smoke in the distance");
        Space mossyStone = new Space("a mossy stone");
        Space hillTop = new Space("a hill top", "You see smoke in the distance");
        Space puddle = new Space("a puddle");
        Space bigOak = new Space("the big oak", "Look up, there is a tree house in it");
        Space well = new Space("a well", "Falling down seems like a bad idea");
        Space bottomOfWell = new Space("the bottom of the well", "You can't come up, maybe try to swim down?", false);
        Space shrine = new Space("a shrine", "A water stream runs by");
        Space crashedAirplane = new Space("a crashed airplane");
        Space sapling = new Space("a sapling", "One day it will grow into a big tree");
        Space rabbitNest = new Space("a Rabbit nest", "Rabbits? that looks more like a nugget to me!");
        Space birchTree = new Space("a birch tree");
        Space valley = new Space("a valley");
        Space tumulus = new Space("a tumulus", "Wonder how many are buried here");
        Space dryCave = new Space("a cave", "Don't dig straight down!");    
        Space stone = new Space("a stone");
        Space waterStream = new Space("a water stream", "Wonder were it leads");
        Space oldTree = new Space("the old Tree", "Birds are singing a wonderful melody");
        Space campfire = new Space("a campfire", "Smoke reached over the trees");
        Space abandonCar = new Space("an abandon car");
        Space ruin = new Space("a ruin");
        Space clearing = new Space("a clearing", "it's nice and bright here");
        Space fallenTreeTrunk = new Space("a fallen tree trunk");
        Space forestEdge = new Space("the forest edge");//start
        Space fairyRing = new Space("a fairy ring");
        Space mushroom = new Space("a few mushrooms", "You spot even more!");
        Space oldRailWay = new Space("an old rail way", "It's very overgrown");
        Space lake = new Space("a lake", "A small water stream is connected");
        Space witchHut = new Space("a witch hut");
        Space humongousMushroom = new Space("a humongous mushroom", "It's big, red and has white polka dots, it could probably bounce a racecar \nYou spot a bunch of smaller mushrooms as well");
        Space bottomOfRavine = new Space("the bottom of a ravine", "You don't seem to be able to get up, but here is a pool of water", false);
        Space waterfall = new Space("a waterfall", "how intriguing");
        Space flower = new Space("a flower", "The flower smells great");
        Space field = new Space("a field");
        Space swamp = new Space("a swamp");
        Space weirdEntrance = new Space("a weird entrance", "Something exiting must be on the other side");
        Space storageRoom = new Space("a storage room", "Contains a lot of nuka cola? Don't know what that is");
        Space sewer = new Space("a sewer", "Disgusting!!", false);
        Space wetCave = new Space("a cave", "It's behind a waterfall");
        Space foxDen = new Space("a fox den", "Wonder who made this");
        Space bunker = new Space("a bunker", "There is a red door");
        Space hallway = new Space("a hallway", "This room contain 6 doors, they all have distinct colors");
        Space bathroom = new Space("a bathroom", "There is big hole were the toilet should be\nWould it be nasty seeing were it leads or should i look behind the green door?");
        Space smallRavine = new Space("a small ravine", "It's scary standing this close to the edge");
        Space crossroad = new Space("a crossroad", "A hornet runs across the ground");
        Space tunnel = new Space("a tunnel", "it's a tight squeeze, but you might be able i get trough", false);
        Space medbay = new Space("a medbay", "There is a big crack in the wall");
        Space barracks = new Space("the barracks", "This room contain two door, one of them is pink");
        Space generator = new Space("a generator", "not much else to see");
        Space dinningHall = new Space("a dinning hall", "not much else to see");



        //Making NPC's
        forestEdge.NPC = new NPC("Pam, The Pangolin", "", "Well here is your item");
        waterStream.NPC = new NPC("Crush, The Leatherback Turtle", "", "Well here is your item");
        barracks.NPC = new NPC("Jarvan IV, The Javan Rhino", "", "Well here is your item");
        valley.NPC = new NPC("Tim, The Tiger", "", "Well here is your item");
        humongousMushroom.NPC = new NPC("Syndra, The Sunda Tiger", "", "Well here is your item");
        treeHouse.NPC = new NPC("Sajjad, The Orangutang", "", "Well here is your item");
        smallRavine.NPC = new NPC("Thai Fung, The Amur Leopard", "", "Well here is your item");
        crashedAirplane.NPC = new NPC("Kai Cenat, The African Elephant", "", "Well here is your item");
        bunker.NPC = new NPC("Rhyan, The Sumatran Rhino", "", "Well here is your item");
        sewer.NPC = new NPC("Raphael, The Hawksbill Turtle", "", "Well here is your item");


        //Determin the path for each space
        treeHouse.AddEdge("down", bigOak);
        treeHouse.AddEdge("smoke", campfire);

        mossyStone.AddEdge("south", crashedAirplane);
        mossyStone.AddEdge("east", hillTop);

        hillTop.AddEdge("east", puddle);
        hillTop.AddEdge("west", mossyStone);
        hillTop.AddEdge("smoke", campfire);

        puddle.AddEdge("south", sapling);
        puddle.AddEdge("east", bigOak);
        puddle.AddEdge("west", hillTop);

        bigOak.AddEdge("east", well);
        bigOak.AddEdge("west", puddle);
        bigOak.AddEdge("up", treeHouse);

        well.AddEdge("south", birchTree);
        well.AddEdge("west", bigOak);
        well.AddEdge("down", bottomOfWell);

        bottomOfWell.AddEdge("swim", sewer);

        shrine.AddEdge("south", tumulus);
        shrine.AddEdge("stream", waterStream);

        crashedAirplane.AddEdge("north", mossyStone);
        crashedAirplane.AddEdge("south", dryCave);

        sapling.AddEdge("north", puddle);
        sapling.AddEdge("south", oldTree);
        sapling.AddEdge("east", rabbitNest);

        rabbitNest.AddEdge("east", birchTree);
        rabbitNest.AddEdge("west", sapling);

        birchTree.AddEdge("north", well);
        birchTree.AddEdge("south", campfire);
        birchTree.AddEdge("east", valley);
        birchTree.AddEdge("west", rabbitNest);

        valley.AddEdge("east", tumulus);
        valley.AddEdge("west", birchTree);

        tumulus.AddEdge("north", shrine);
        tumulus.AddEdge("south", ruin);
        tumulus.AddEdge("west", valley);

        dryCave.AddEdge("north", crashedAirplane);
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

        oldTree.AddEdge("north", sapling);
        oldTree.AddEdge("south", forestEdge);
        oldTree.AddEdge("west", waterStream);

        campfire.AddEdge("north", birchTree);
        campfire.AddEdge("east", abandonCar);

        abandonCar.AddEdge("south", mushroom);
        abandonCar.AddEdge("west", campfire);

        ruin.AddEdge("north", tumulus);
        ruin.AddEdge("south", oldRailWay);
    
        clearing.AddEdge("north", stone);
        clearing.AddEdge("south", lake);
        clearing.AddEdge("east", fallenTreeTrunk);
    
        fallenTreeTrunk.AddEdge("north", waterStream);
        fallenTreeTrunk.AddEdge("east", forestEdge);
        fallenTreeTrunk.AddEdge("west", clearing);
        fallenTreeTrunk.AddEdge("smell", flower);
    
        forestEdge.AddEdge("north", oldTree);
        forestEdge.AddEdge("south", field);
        forestEdge.AddEdge("east", fairyRing);
        forestEdge.AddEdge("west", fallenTreeTrunk);

        fairyRing.AddEdge("south", witchHut);
        fairyRing.AddEdge("west", forestEdge);

        mushroom.AddEdge("north", abandonCar);
        mushroom.AddEdge("east", oldRailWay);
        mushroom.AddEdge("mushroom", humongousMushroom);
        mushroom.AddEdge("birdsong", oldTree);

        oldRailWay.AddEdge("north", ruin);
        oldRailWay.AddEdge("south", sewer);
        oldRailWay.AddEdge("west", mushroom);

        lake.AddEdge("north", clearing);
        lake.AddEdge("south", waterfall);

        witchHut.AddEdge("north", fairyRing);
        witchHut.AddEdge("south", swamp);
        witchHut.AddEdge("east", humongousMushroom);

        humongousMushroom.AddEdge("south", weirdEntrance);
        humongousMushroom.AddEdge("west", witchHut);
        humongousMushroom.AddEdge("mushroom", mushroom);

        bottomOfRavine.AddEdge("outside", dryCave);
        bottomOfRavine.AddEdge("pool", lake);

        waterfall.AddEdge("north", lake);
        waterfall.AddEdge("east", flower);
        waterfall.AddEdge("behind", wetCave);
    
        flower.AddEdge("east", field);
        flower.AddEdge("west", waterfall);
        flower.AddEdge("birdsong", oldTree);
    
        field.AddEdge("north", forestEdge);
        field.AddEdge("south", foxDen);
        field.AddEdge("east", swamp);
        field.AddEdge("west", flower);

        swamp.AddEdge("north", witchHut);
        swamp.AddEdge("east", weirdEntrance);
        swamp.AddEdge("west", field);

        weirdEntrance.AddEdge("north", humongousMushroom);
        weirdEntrance.AddEdge("west", swamp);
        weirdEntrance.AddEdge("inside", bunker);

        storageRoom.AddEdge("yellow", hallway);

        sewer.AddEdge("north", oldRailWay);
        sewer.AddEdge("explore", bathroom);

        wetCave.AddEdge("outside", waterfall);
        wetCave.AddEdge("inside", crossroad);
    
        foxDen.AddEdge("north", field);
        foxDen.AddEdge("inside", tunnel);
        foxDen.AddEdge("smell", flower);

        bunker.AddEdge("outside", weirdEntrance);
        bunker.AddEdge("red", hallway);

        hallway.AddEdge("red", bunker);
        hallway.AddEdge("yellow", storageRoom);
        hallway.AddEdge("green", bathroom);
        hallway.AddEdge("blue", dinningHall);
        hallway.AddEdge("purple", generator);
        hallway.AddEdge("pink", barracks);

        bathroom.AddEdge("hole", sewer);
        bathroom.AddEdge("green", hallway);

        smallRavine.AddEdge("down", bottomOfRavine);
        smallRavine.AddEdge("back", crossroad);
    
        crossroad.AddEdge("outside", wetCave);
        crossroad.AddEdge("right", tunnel);
        crossroad.AddEdge("left", smallRavine);
    
        tunnel.AddEdge("outside", foxDen);
        tunnel.AddEdge("left", crossroad);
        tunnel.AddEdge("right", medbay);

        medbay.AddEdge("door", barracks);
        medbay.AddEdge("crack", tunnel);

        barracks.AddEdge("pink", hallway);
        barracks.AddEdge("door", medbay);

        generator.AddEdge("purple", hallway);

        dinningHall.AddEdge("blue", hallway);

        this.entry = forestEdge;

  }
  
  public Space GetEntry () {
    return entry;
  }
}

