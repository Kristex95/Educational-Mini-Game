using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawning : MonoBehaviour, IObserver
{
    [SerializeField] Subject _gameManagerSubject;

    [SerializeField] private List<Transform> spawnpoints;

    [SerializeField] private GameObject propPrefab;

    [Header("Position offset")]
    [SerializeField] [Range(0.1f, 5f)] private float maxY;
    [SerializeField] [Range(-1f, 0f)] private float minY;

    [Header("Delay")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;



    private bool doSpawn = false;


    public void OnNotify(GameStates state)
    {
        switch (state)
        {
            case (GameStates.Play):
                doSpawn = true;
                break;
            case (GameStates.Pause):
                doSpawn = false;
                break;
            case (GameStates.End):
                doSpawn = false;
                break;
        }
    }

    private void Start()
    {
        StartCoroutine(spawning());
    }

    IEnumerator spawning()
    {
        while (true)
        {
            if (doSpawn)
            {
                int randSide = Random.Range(0, 2);

                GameObject newProp = Instantiate(propPrefab, spawnpoints[randSide].position + new Vector3(0, Random.Range(minY, maxY), 0), Quaternion.identity);
                if(randSide == 0)
                    newProp.GetComponent<PropMoving>().SetHorizontalVelocity(1f);
                else
                    newProp.GetComponent<PropMoving>().SetHorizontalVelocity(-1f);

                float delay = Random.Range(minTime, maxTime);
                yield return new WaitForSeconds(delay);
            }
        }
    }

    private void OnEnable()
    {
        _gameManagerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _gameManagerSubject.RemoveObserver(this);
    }
}
