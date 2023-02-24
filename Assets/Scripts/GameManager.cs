using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameEvent onGameStateChange;
    public AddScoreEvent onScoreChange;

    public static GameStates state;


    [Header("Game info")]
    [SerializeField] private int lives = 3;
    public static int score { get; private set; }

    [Header("Props Data")]
    [SerializeField] private string propsDataPath;
    [HideInInspector] public static List<PropData> playablePropsData;

    [Header("Buckets")]
    [SerializeField] private List<GameObject> signs;
    [SerializeField] private List<BucketTriggerScript> triggerScripts;

    private void Awake()
    {
        lives = 3;
        score = 0;

        List<PropData> propsData = Resources.LoadAll<PropData>(propsDataPath).ToList();
        playablePropsData = propsData.OrderBy(x => Guid.NewGuid()).Take(triggerScripts.Count).ToList();

        for (int i = 0; i < playablePropsData.Count; i++)
        {
            //signs materials
            var materials = signs[i].GetComponent<MeshRenderer>().materials;
            materials[1] = playablePropsData[i].ImageMaterial;
            signs[i].GetComponent<MeshRenderer>().materials = materials;

            //triggers prop names
            triggerScripts[i].propTriggerName = playablePropsData[i].name;
        }



        UpdateGameState(GameStates.Play);
    }

    public void UpdateGameState(GameStates newState)
    {
        state = newState;

        switch (newState)
        {
            case GameStates.Play:
                Time.timeScale = 1;
                break;
            case GameStates.End:
                Time.timeScale = 0;
                break;
            case GameStates.Pause:
                Time.timeScale = 0;
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
        onScoreChange.Invoke(score);
    }

    [System.Serializable]
    public class AddScoreEvent : UnityEvent<int> { }

    public void ReduceLives()
    {
        if(lives > 0)
        {
            lives--;
        }

        if(lives == 0)
        {
            UpdateGameState(GameStates.End);

            //UI Logic

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
