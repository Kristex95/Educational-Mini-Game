using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : Subject
{
    public static GameManager Instance;

    public GameStates state;

    public int score { get; private set; }

    private void Awake()
    {
        Instance = this;
        UpdateGameState(GameStates.Play);
        score = 0;
    }

    public void UpdateGameState(GameStates newState)
    {
        state = newState;

        switch (newState)
        {
            case GameStates.Play:                
                break;
            case GameStates.End:
                break;
            case GameStates.Pause:
                break;
            default:
                break;
        }

        NotifyObservers(newState);
    }
}
