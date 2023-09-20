using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{

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
    void Update()
    {
        Vector3 desiredPosition = target.transform.position - target.transform.forward * distanceBehind + Vector3.up * cameraHeight;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.transform);
    }
}
