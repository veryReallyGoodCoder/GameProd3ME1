using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    Rigidbody rb;

    public float moveSpeed = 1000f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        Vector3 force = moveSpeed * Vector3.forward;
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(force, ForceMode.Force);
            Debug.Log("forward");
        }

    }

}
