using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlGame : MonoBehaviour
{
    public static System.Action<GameStates, GameStates> OnChangeState;

    GameStates state = GameStates.None;
    bool tamuerto;


    public GameStates State
    {
        get => state;
        set
        {
            if (state == value) return;
            OnChangeState?.Invoke(value, state);
            state = value;
        }
    }

    public void TargetLost()
    {
        if (tamuerto)
        {
            return;
        }
        State = GameStates.LookForGroud;
        Debug.Log("TargetLost");

    }

    public void PlaneFound()
    {
        if (tamuerto)
        {
            return;
        }
        if (State == GameStates.PlayGame) return;
        State = GameStates.PlayGame;
        Debug.Log("PlayGame");
    }
    public void Death()
    {
        State = GameStates.Death;
        this.gameObject.SetActive(false);
        tamuerto = true;
        Debug.Log("Death");
    }

    public void Start()
    {
        tamuerto = false;
        State = GameStates.LookForGroud;
        Debug.Log("LookForGroud");
    }

    public void Log(string message)
    {
        Debug.Log(message);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    
}
