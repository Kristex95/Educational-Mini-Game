using UnityEngine;

public class BucketTriggerScript : MonoBehaviour
{
    [SerializeField] private GameEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            onTriggerEnter.TriggerEvent();
        }
    }
}
