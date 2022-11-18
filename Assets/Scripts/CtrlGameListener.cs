using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CtrlGameListener : MonoBehaviour
{

    protected abstract void GameStateChanged(GameStates current, GameStates previous);

    private void Awake()
    {
        CtrlGame.OnChangeState += GameStateChanged;
    }

    private void OnDestroy()
    {
        CtrlGame.OnChangeState -= GameStateChanged;
    }
}
