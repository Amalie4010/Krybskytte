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
        Lost,
        Win
    }
    States state = States.Day;
    int turnsPerCycle = 5;
    int turnsUntilNextCycle;
    int daysRequiredToWin = 10;
    int daysRemainingToWin;

    public Enemy enemy;
    World world;
    Context context;
    Traps traps;

    public GameState(Enemy enemy, World world, Context context, Traps traps)
    {
        this.enemy = enemy;
        this.world = world;
        this.traps = traps;

        state = States.Day;
        turnsUntilNextCycle = turnsPerCycle;
        daysRemainingToWin = daysRequiredToWin;
        
        GameState.gameState = this;
        this.context = context;
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
        } else if (newState == States.Day)
        {
            daysRemainingToWin -= 1;
            if (daysRemainingToWin == 0)
            {
                ChangeState(States.Win);
                context.MakeDone();
            }
        }
        
    }
    
    private void ChangeState()
    {
        switch(state)
        {
            case States.Day:
                ChangeState(States.Night);
                break;
            case States.Night:
                ChangeState(States.Day);
                break;
            default:
                return;
        }
        PrintGameState();
    }

    public void Lose()
    {
        ChangeState(States.Lost);
        context.MakeDone();
    }

    public bool HasLost()
    {
        return state == States.Lost;
    }

    public bool HasWon()
    {
        return state == States.Win;
    }

    public void PrintGameState()
    {
        string stringToPrint;
        switch (state)
        {
            case States.Day:
                stringToPrint = "The day shines upon you!";
                traps.AddTrap();//Adds a trap when day comes
                break;
            case States.Night:
                stringToPrint = "The night has fallen!";
                break;
            default:
                return;
        }
        Console.WriteLine(stringToPrint);
    }
    public States GetState() { 
    return state;
    }
}

