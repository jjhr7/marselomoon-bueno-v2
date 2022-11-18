using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlDeath : CtrlGameListener
{

    public GameObject[] gameObjects;
    protected override void GameStateChanged(GameStates current, GameStates previous)
    {
        if (current == GameStates.Death)
        {
            for (int i = 0; i < gameObjects.Length; i++)
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

