﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


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

    // Denne rekursive funktion fungerer ved at finde alle tænkelige ruter, og backtracker hvis en rute:
    // Går i ring
    // Er for lang
    // Er en dead-end
    bool FindPath(Node here, Node endpoint, List<Node> traversedNodes, List<string> path, int maxPathLength)
    {
        
        if (path.Count >= maxPathLength) // Er ruten for lang
        {
            path.RemoveAt(path.Count - 1);
            return false;
        }

        traversedNodes.Add(here);
        
        if (here == endpoint) 
        {
            return true;
        }
        foreach (KeyValuePair<string, Node> space in here.GetEdges())
        {
            if (!traversedNodes.Contains(space.Value)) // Har algoritmen tjekket dette før
            {
                path.Add(space.Key);
                if (FindPath(space.Value, endpoint, traversedNodes, path, maxPathLength)) // Er der en dead-end
                {
                    return true;
                }

            }
        }
        if (path.Count != 0)
        {
            path.RemoveAt(path.Count - 1);
        }
        return false;
    }

    // Looper og kører funktionen FindPath, indtil den korteste rute er fundet
    List<string> CalculateShortestRouteToPlayer(Node endpoint) 
    {
        int shortestPathLength = int.MaxValue;
        List<string> shortestPath = new List<string>();

        while (true)
        {

            List<string> path = new List<string>();
            if (FindPath(current, endpoint, new List<Node>(), path, shortestPathLength)) // Hvis FindPath er true, betyder det at der blev fundet en rute
            {
                shortestPath = path;
                shortestPathLength = shortestPath.Count;
                continue;
            }
            break;

        }
        return shortestPath;

    }

    public void HuntOnce()
    {
        List<string> path = CalculateShortestRouteToPlayer(playerContext.GetCurrent());
        Transition(path[0]);

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
        Console.WriteLine(" ____         __^.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,^.,.,.,.,.,.,.,_");
        Console.WriteLine("\\ \\     \\_/_\\      -o    ===       ------  ;;;;;;;;;;;;;;;;;;;;▄▄▄▄▄▄");
        Console.WriteLine("/_-----   /    /(/_)---- ██/-- {_/---     ^ ^ (_-___}----------------------------------------------------         ~KAPOW~         *");
        Console.WriteLine("           /__/            {██}  ");
        
        Console.WriteLine("");
        
        GameState.gameState.Lose();
    }
}