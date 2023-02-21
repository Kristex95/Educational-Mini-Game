using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameEvent onGameStateChange;
    public GameEvent onScoreChange;

    public static GameStates state;

    public static int score { get; private set; }

    [Header("Props Data")]
    [SerializeField] private string propsDataPath;
    [HideInInspector] public static List<PropData> playablePropsData;

    private void Awake()
    {
        score = 0;

        List<PropData> propsData = Resources.LoadAll<PropData>(propsDataPath).ToList();
        playablePropsData = propsData.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

        foreach (var playablePropData in playablePropsData)
            Debug.Log(playablePropData.Mesh);

        UpdateGameState(GameStates.Play);
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

    public void AddScore()
    {
        score += 1;
        Debug.Log(score);
        onScoreChange.TriggerEvent();
    }
}
