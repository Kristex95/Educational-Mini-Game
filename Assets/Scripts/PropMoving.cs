using UnityEngine;

public class PropMoving : MonoBehaviour
{
    [SerializeField] private GameEvent onReduceLives;
    private Rigidbody rb;
    private Renderer _renderer;
    private bool hasAppeared;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        int rotationDir = 0;
        while (rotationDir == 0)
            rotationDir = Random.Range(-1, 2);
        rb.angularVelocity = new Vector3(0, Random.Range(.3f, 1f) * rotationDir, 0);
    }

    private void Update()
    {
        if (_renderer.isVisible)
        {
            hasAppeared = true;
        }

        if (hasAppeared)
        {
            if (!_renderer.isVisible)
            {
                onReduceLives.TriggerEvent();
                Destroy(gameObject);
            }
        }
    }

    public void SetHorizontalVelocity(float xVelocity)
    {
        rb.velocity = new Vector3(xVelocity, 0, 0);
    }
}
