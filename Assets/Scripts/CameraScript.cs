using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private Vector2 playerMouse;

    [SerializeField] private Transform cam;

    public void PlayerCamera(InputAction.CallbackContext ctx)
    {
        playerMouse = ctx.ReadValue<Vector2>();
    }

    
    public Transform target;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        target.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);

        // Smoothly interpolate the camera's position and rotation
        //transform.position = Vector3.Lerp(transform.position, target.position + desiredRotation * offset, Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);

    }
}

