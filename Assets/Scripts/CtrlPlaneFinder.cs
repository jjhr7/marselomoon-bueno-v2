using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlaneFinder : CtrlGameListener
{

    public GameObject[] gameObjects;
    protected override void GameStateChanged(GameStates current, GameStates previous)
    {
        Debug.Log("previous " + previous);
        Debug.Log(current);
        if(previous == GameStates.Death)
        {
            current = previous;
            return;
        } 
        else if(current == GameStates.PlayGame)
        {
            for (int i=0; i<gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
        else
        {
        
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
