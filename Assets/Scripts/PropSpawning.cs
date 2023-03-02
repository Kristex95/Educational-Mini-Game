using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawning : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnpoints;


    [SerializeField] private float propSpeed = 1f;

    [Header("Prop")]
    [SerializeField] private GameObject propPrefab;
    [SerializeField] private Material material;

    [Header("Position offset")]
    [SerializeField] [Range(0.1f, 5f)] private float maxY;
    [SerializeField] [Range(-1f, 0f)] private float minY;

    [Header("Delay")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Camera")]
    private Camera cam;

    private bool doSpawn = false;
    private bool coroutineRunning = false;


    private Vector2 res;

    private void Awake()
    {
        res.x = Screen.width;
        res.y = Screen.height;
        cam = Camera.main;
        Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0f, Mathf.Abs(cam.gameObject.transform.position.z) + 1.86f));
        spawnpoints[0].transform.position = new Vector3(-(spawnPos.x + 1f), spawnpoints[0].position.y, spawnpoints[0].position.z);
        spawnpoints[1].transform.position = new Vector3(spawnPos.x + 1f, spawnpoints[1].position.y, spawnpoints[1].position.z);
    }

    private void Update()
    {
        if (res.x != Screen.width || res.y != Screen.height)
        {
            Vector3 spawnPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0f, Mathf.Abs(cam.gameObject.transform.position.z) + 1.86f));
            spawnpoints[0].transform.position = new Vector3(-(spawnPos.x + 1f), spawnpoints[0].position.y, spawnpoints[0].position.z);
            spawnpoints[1].transform.position = new Vector3(spawnPos.x + 1f, spawnpoints[1].position.y, spawnpoints[1].position.z);

            res.x = Screen.width;
            res.y = Screen.height;
        }
    }

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

            //Setting up prop

            PropData propData = GameManager.playablePropsData[Random.Range(0, 3)];
            Mesh randMesh = propData.Mesh;
            newProp.GetComponent<MeshFilter>().mesh = randMesh;
            newProp.GetComponent<Renderer>().materials = propData.Materials.ToArray();
            newProp.name = propData.name;

            if(randSide == 0)
                newProp.GetComponent<PropMoving>().SetHorizontalVelocity(1 * propSpeed);
            else
                newProp.GetComponent<PropMoving>().SetHorizontalVelocity(-1 * propSpeed);

            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);
        }
        coroutineRunning = false;
    }

    public void OnScoreUpdate(int score)
    {
        if(score % 20 == 0 && propSpeed + .3f < 3.5f)
        {
            propSpeed += 0.3f;
        }
        else if(score % 10 == 0)
        {
            if(maxTime -.2f > 1.2f)
                maxTime -= 0.2f;
            if(minTime - 0.025f > 0.4f)
                minTime -= 0.025f;
        }
    }
}
