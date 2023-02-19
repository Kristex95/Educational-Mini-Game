using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawning : MonoBehaviour
{
    [SerializeField] Subject _gameManagerSubject;

    [SerializeField] private List<Transform> spawnpoints;

    [SerializeField] private GameObject propPrefab;


    [SerializeField] private float propSpeed = 1f;

    [Header("Position offset")]
    [SerializeField] [Range(0.1f, 5f)] private float maxY;
    [SerializeField] [Range(-1f, 0f)] private float minY;

    [Header("Delay")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    private bool doSpawn = false;
    private bool coroutineRunning = false;


    public void OnStateChange()
    {
        switch (GameManager.state)
        {
            case (GameStates.Play):
                doSpawn = true;
                if(!coroutineRunning)
                    StartCoroutine(spawning());
                break;
            case (GameStates.Pause):
                doSpawn = false;
                break;
            case (GameStates.End):
                doSpawn = false;
                break;
        }
    }

    IEnumerator spawning()
    {
        coroutineRunning = true;
        while (doSpawn)
        {
            int randSide = Random.Range(0, 2);

            GameObject newProp = Instantiate(propPrefab, spawnpoints[randSide].position + new Vector3(0, Random.Range(minY, maxY), 0), Quaternion.identity);
            if(randSide == 0)
                newProp.GetComponent<PropMoving>().SetHorizontalVelocity(1 * propSpeed);
            else
                newProp.GetComponent<PropMoving>().SetHorizontalVelocity(-1 * propSpeed);

            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);
        }
        coroutineRunning = false;
    }

}
