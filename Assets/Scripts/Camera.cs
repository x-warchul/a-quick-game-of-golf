using UnityEngine;

public class Camera : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    private float LookSensitivity = 70f;

    private Vector2 mouseAbsolute;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    void HandleMovement()
    {
        Vector3 forwardMovment = Vector3.zero;

        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            forwardMovment += transform.forward;
        }
        // Backward
        if (Input.GetKey(KeyCode.S))
        {
            forwardMovment -= transform.forward;
        }

        forwardMovment.y = 0f;
        forwardMovment.Normalize();

        Vector3 rightMovement = Vector3.zero;

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            rightMovement += transform.right;
        }
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            rightMovement -= transform.right;
        }

        Vector3 movementVector = forwardMovment + rightMovement;
        movementVector.Normalize();

        transform.Translate(movementVector * MovementSpeed * Time.deltaTime, Space.World);
    }

    void HandleLook()
    {
        Vector2 mouseDelta = Input.mousePositionDelta;

        mouseDelta *= LookSensitivity;

        mouseDelta *= Time.deltaTime;

        mouseAbsolute += mouseDelta;

        mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -89.9f, 89.9f);

        transform.localRotation = Quaternion.AngleAxis(mouseAbsolute.y, Vector3.left);

        Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));

        transform.localRotation *= yRotation;
    }
}
