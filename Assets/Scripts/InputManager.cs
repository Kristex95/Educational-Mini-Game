using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private GameObject prop;
    private Rigidbody rb;

    private Vector3 touchOffset;

    private bool holding = false;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchPressAction = playerInput.actions["TouchPress"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPress;
        touchPressAction.canceled += ReleaseTouchPress;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPress;
        touchPressAction.canceled -= ReleaseTouchPress;
    }

    public void TouchPress(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = touchPositionAction.ReadValue<Vector2>();
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 1.86f + Mathf.Abs(Camera.main.transform.position.z)));

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, position - Camera.main.transform.position, out hit, 10f))
        {
            if(hit.collider.gameObject.layer == 6)
            {
                prop = hit.collider.gameObject;
                rb = prop.GetComponent<Rigidbody>();

                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                touchOffset = prop.transform.position - position;

                holding = true;
            }
        }
    }

    public void ReleaseTouchPress(InputAction.CallbackContext context)
    {
        if (prop != null && rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            prop.GetComponent<Collider>().isTrigger = false;

            holding = false;
        }
    }

    private void FixedUpdate()
    {
        if (holding)
        {
            Vector2 touchPosition = touchPositionAction.ReadValue<Vector2>();
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 1.86f + Mathf.Abs(Camera.main.transform.position.z)));

            prop.transform.position = position + touchOffset;
        }
    }
}
