using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowingStuff : MonoBehaviour
{
    [Header("Picking Up")]
    [SerializeField]private Transform cam;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private LayerMask Projectile;

    [SerializeField] private float rayDistance = 5f;
    
    public bool throwing;

    GrabbableObject grabbableObject;

    [Header("Sound")]
    [SerializeField] private AudioSource soundManager;
    [SerializeField] private AudioClip throwNoise;


    void Start()
    {
        //rb = projectile.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        //projectile.transform.position = hand.position;

       

        /*if (throwing)
        {
            


            rb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
            Debug.Log("throw");
        }*/
    }

    /*public void Throw(InputAction.CallbackContext ctx)
    {
        throwing = ctx.action.triggered;
    }*/

    public void PickUp(InputAction.CallbackContext ctx)
    {
        if (ctx.action.triggered && grabbableObject == null)
        {
            RaycastHit hit;
                   
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance, Projectile))
            {
                Debug.Log("hit");

                if(hit.transform.TryGetComponent<GrabbableObject>(out grabbableObject))
                {
                    Debug.Log(grabbableObject);
                    grabbableObject.Grab(grabPoint);
                }
            }

            throwing = false;
        }
        else if(ctx.action.triggered && grabbableObject != null)
        {
            
            grabbableObject.ThrowObject();
            grabbableObject = null;
            
            throwing = true;

            soundManager.clip = throwNoise;
            soundManager.PlayOneShot(throwNoise);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "lemon")
        {
            
        }
    }

}
