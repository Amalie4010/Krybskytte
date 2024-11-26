using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


/* Context class to hold all context relevant to the Enemy.
 */

class Enemy
{
    Space current;
    Context playerContext;


    public Enemy(Space startNode, Context playerContext)
    {
        current = startNode;
        this.playerContext = playerContext;
    }

    public Space GetCurrent()
    {
        return current;
    }

    public void SetCurrent(Space space)
    {
        current = space;
    }

    public void Transition(string direction)   
    {
        Space next = current.FollowEdge(direction);
        if (next == null)
        {
            throw new Exception("Enemy's desired next edge doesnt exist");
        }
        else
        {
            //current.Goodbye();
            current = next;
            //current.Welcome();
        }
    }



    List<string> CalculateShortestRouteToPlayer(Node endpoint) 
    {
        // Use BFS to search entire map
        List<Node> visited = new List<Node>();
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(current);
        Dictionary<Node, Node> parentsDict = new Dictionary<Node, Node>();

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            visited.Add(current);

            foreach (KeyValuePair<string, Node> neighbor in current.GetEdges())
            {
                // Continue only when a node isnt traversible by enemy AND the player currently isnt on that particular node.
                if (!((Space) neighbor.Value).isTraversableByEnemy && ((Space)neighbor.Value) != endpoint)
                {
                    continue;
                }

                if (!visited.Contains(neighbor.Value) && !parentsDict.ContainsKey(neighbor.Value))
                {
                    queue.Enqueue(neighbor.Value);
                    parentsDict.Add(neighbor.Value, current);
                }
            }
        }

        // Create node path
        List<Node> path = new List<Node>();
        path.Add(endpoint);
        Node currentNode = endpoint;
        while (currentNode != current)
        {
            currentNode = parentsDict[currentNode];
            path.Add(currentNode);
        }
        path.Reverse();

        // Construct path of edges
        List<string> edgePath = new List<string>();
        for(int i=0; i<path.Count - 1; i++)
        {
            Node node = path[i];
            foreach(KeyValuePair<string, Node> edge in node.GetEdges())
            {
                if (edge.Value == path[i+1])
                {
                    edgePath.Add(edge.Key);
                }
            }
        }

        
        return edgePath;

    }

    public void HuntOnce()
    {
        List<string> path = CalculateShortestRouteToPlayer(playerContext.GetCurrent());
        if (path.Count > 0) // If path == 0 that means the enemy already is at the same location as the player and therefore shouldnt move
        {
            Transition(path[0]);
            Shell.WriteDangerMessage(GenerateDangerLevelMessage(path.Count));
        }

        if (PlayerIsInRange())
        {
            KillPlayer();
        }

    }

    bool PlayerIsInRange() 
    {
        return current == playerContext.GetCurrent();
    }

    void KillPlayer()
    {
        //Print Gun
        Shell.PrintLine(PrettyPrinter.TextToString("Gun.txt"));
        
        Shell.PrintLine("");

        
        GameState.gameState.Lose();
    }

    string GenerateDangerLevelMessage(int distance)
    {
        if (distance <= 3) 
        {
            return "You smell danger VERY close to you!";
        }
        else if (distance <= 6)
        {
            return "You smell danger near to you";
        }else
        {
            return "You smell no danger";
        }
    }
}