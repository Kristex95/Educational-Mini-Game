using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameEvent onGameStateChange;

    public static GameManager Instance;

    public static GameStates state;

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

        onGameStateChange.TriggerEvent();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && state == GameStates.Play)
        {
            UpdateGameState(GameStates.Pause);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && state == GameStates.Pause)
        {
            UpdateGameState(GameStates.Play);
        }
    }
}
