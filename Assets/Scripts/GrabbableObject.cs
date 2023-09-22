using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Rigidbody objectRB;
    private Transform grabPoint;

    private float smoothSpeed = 5f;

    [SerializeField] private float throwForce = 200f;
    

    private void Start()
    {
        objectRB= GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(grabPoint != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPoint.position, smoothSpeed * Time.deltaTime);
            
            objectRB.MovePosition(newPosition);
            objectRB.useGravity = false;
        }
    }

    public void Grab(Transform grabPoint)
    {
        this.grabPoint = grabPoint;
    }

    public void ThrowObject()
    {
        objectRB.AddForce(grabPoint.forward * throwForce, ForceMode.Impulse);
        this.grabPoint = null;
        objectRB.useGravity = true;
    }
}
