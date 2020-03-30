using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GameState
{
    private ArrayList winLogic1 = new ArrayList();
    private ArrayList winLogic2 = new ArrayList();
    private ArrayList currLogic = new ArrayList();
    private static GameState gameState;

    private GameState()
    {
        //Intialize the win logic and current logic
        winLogic1.Add(1); winLogic1.Add(1); winLogic1.Add(0); winLogic1.Add(0); winLogic1.Add(1); winLogic1.Add(1);
        winLogic2.Add(1); winLogic2.Add(1); winLogic2.Add(0); winLogic2.Add(1); winLogic2.Add(1); winLogic2.Add(1);
        currLogic.Add(0); currLogic.Add(0); currLogic.Add(0); currLogic.Add(0); currLogic.Add(0); currLogic.Add(0);
    }

    public static GameState getGameState()
    {
        if (gameState == null)
        {
            gameState = new GameState();
        }
        return gameState;
    }

    public bool checkLogic()
    {
        for (int i = 0; i < 6; i++)
        {
            if (((int)currLogic[i] != (int)winLogic1[i]) && (int)currLogic[i] != (int)winLogic2[i])
            {
                return false;
            }
        }

        return true;
    }

    public void updateCurrLogic(int index)
    {
        if (currLogic[index].Equals(0))
        {
            currLogic[index] = 1;
        }
        else
            currLogic[index] = 0;
    }

    public bool checkAvailible(int index)
    {
        if (currLogic[index].Equals(0))
            return true;
        return false;
    }
}
