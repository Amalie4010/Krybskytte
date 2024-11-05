using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameState
{
    public static GameState? gameState;
    public enum States
    {
        Day,
        Night,
        Lost
    }
    States state = States.Day;
    int turnsPerCycle = 5;
    int turnsUntilNextCycle;
    public Enemy enemy;
    World world;

    public GameState(Enemy enemy, World world)
    {
        this.enemy = enemy;
        this.world = world;
        state = States.Day;
        turnsUntilNextCycle = turnsPerCycle;

        GameState.gameState = this;
    }

    public void UseTurn()
    {
        turnsUntilNextCycle -= 1;
        if (turnsUntilNextCycle == 0)
        {
            ChangeState();
            turnsUntilNextCycle = turnsPerCycle;
        }
        if (state == States.Night)
        {
            enemy.HuntOnce();
        }
    }

    private void ChangeState(States newState)
    {
        state = newState;
        if (newState == States.Night)
        {
            enemy.SetCurrent(world.GetEntry());
        }
        
    }
    
    private void ChangeState()
    {
        switch(state)
        {
            case States.Day:
                state = States.Night;
                break;
            case States.Night:
                state = States.Day; 
                break;
            default:
                return;
        }
        PrintGameState();
    }

    public void Lose()
    {
        ChangeState(States.Lost);
    }

    public bool HasLost()
    {
        return state == States.Lost;
    }

    public void PrintGameState()
    {
        string stringToPrint;
        switch (state)
        {
            case States.Day:
                stringToPrint = "The day shines upon you!";
                break;
            case States.Night:
                stringToPrint = "The night has fallen!";
                break;
            default:
                return;
        }
        Console.WriteLine(stringToPrint);
    } 
}

