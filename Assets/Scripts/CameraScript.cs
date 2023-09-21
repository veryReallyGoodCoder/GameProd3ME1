using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private Vector2 playerMouse;

    public Transform cam;
    
    /*[Header("Camera")]
    public Transform root;
    public ConfigurableJoint hips;

    private Vector2 playerMouse;

    public float mouseSensitivity = 10f;

    //public Transform target;
    public GameObject target;

    [SerializeField] private float distanceBehind = 5f;
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position - target.transform.forward * distanceBehind + Vector3.up * cameraHeight;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.transform);
    }*/

    public void PlayerCamera(InputAction.CallbackContext ctx)
    {
        playerMouse = ctx.ReadValue<Vector2>();

        playerMouse.y = Mathf.Clamp(playerMouse.y, -20, 60);

        //Quaternion rootRotation = Quaternion.Euler(playerMouse.y, playerMouse.x, 0).normalized;
        //target.transform.rotation = rootRotation;

        //hips.targetRotation = Quaternion.Euler(0, playerMouse.x, 0).normalized;
    }

    
    public Transform target;          // The target (ragdoll character) to follow
    public float distance = 15.0f;    // The distance between the camera and the target
    public float height = 5.0f;      // The height of the camera above the target
    public float rotationSpeed = 5.0f; // The speed at which the camera rotates

    private Vector3 offset;          // The offset between the camera and the target

    void Start()
    {
        offset = new Vector3(0, height, -distance);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired rotation based on the target's rotation
        //Quaternion desiredRotation = target.rotation * Quaternion.Euler(0, playerMouse.x, 0);



        target.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);

        // Smoothly interpolate the camera's position and rotation
        //transform.position = Vector3.Lerp(transform.position, target.position + desiredRotation * offset, Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);


        //Quaternion arcRotation = transform.rotation * Quaternion.Euler(playerMouse.y, 0, 0);
        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);



        //transform.position = Vector3.Lerp(transform.position, target.position + arcRotation * offset, Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, arcRotation, Time.deltaTime * rotationSpeed);

    }
}

