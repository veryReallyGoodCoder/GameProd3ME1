using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowingStuff : MonoBehaviour
{
    [Header("Picking Up")]
    bool equipped;
    
    [Header("Throwing")]
    private Rigidbody rb;

    //public GameObject charArm;

    public Transform hand;
    public GameObject projectile;

    private bool throwing;

    public float throwForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = projectile.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        projectile.transform.position = hand.position;


        if (throwing)
        {
            


            rb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
            Debug.Log("throw");
        }
    }

    public void Throw(InputAction.CallbackContext ctx)
    {
        throwing = ctx.action.triggered;
    }

    public void PickUp(InputAction.CallbackContext ctx)
    {
        if (ctx.action.triggered)
        {
            equipped = true;
        }
        else
        {
            equipped = false;
        }
    }

}
