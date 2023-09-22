using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private Vector2 playerMouse;
    private Vector3 direction;

    [SerializeField] private Transform cam;

    [SerializeField] private float smoothspeed = 10f;

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

        //Vector3 desiredPosition = Vector3.Lerp(cam.position, target.transform.position, smoothspeed * Time.deltaTime);
        //target.rotation = Quaternion.Euler(desiredPosition);

        /*direction = (target.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(cam.eulerAngles);

        target.rotation = Quaternion.Slerp(target.rotation, look, smoothspeed * Time.deltaTime);*/

        target.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);

        // Smoothly interpolate the camera's position and rotation
        //transform.position = Vector3.Lerp(transform.position, target.position + desiredRotation * offset, Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);

    }
}

