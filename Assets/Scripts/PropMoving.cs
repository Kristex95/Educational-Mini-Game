using UnityEngine;

public class PropMoving : MonoBehaviour
{

    private Rigidbody rb;
    private Renderer _renderer;
    private bool hasAppeared;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
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
                Destroy(gameObject);
            }
        }
    }

    public void SetHorizontalVelocity(float xVelocity)
    {
        rb.velocity = new Vector3(xVelocity, 0, 0);
    }

}
