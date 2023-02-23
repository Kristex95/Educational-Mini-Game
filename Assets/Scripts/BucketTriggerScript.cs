using UnityEngine;

public class BucketTriggerScript : MonoBehaviour
{
    [SerializeField] private GameEvent onAddScore;
    [SerializeField] private GameEvent onReduceLives;
    [HideInInspector] public string propTriggerName;

    private void OnTriggerEnter(Collider other)
    {
        if (propTriggerName == other.gameObject.name)
        {
            Destroy(other.gameObject);
            onAddScore.TriggerEvent();
        }
        else
        {
            Destroy(other.gameObject);
            onReduceLives.TriggerEvent();
        }
    }
}
