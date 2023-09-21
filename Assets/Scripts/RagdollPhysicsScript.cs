using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RagdollPhysicsScript : MonoBehaviour
{

    [Header("Reference")]
    Rigidbody rb;

    public GameObject fartSystem;
    //public Animator animator;

    [Header("Movement")]
    private Vector2 playerMove;

    public float upForce = 600f;
    public float speed = 150f;

    [Header("Camera")]
    //public Transform root;
    //public ConfigurableJoint hips;

    public Transform cam;

    private Vector2 playerMouse;

    public float mouseSensitivity = 10f;

    [Header("Jump")]
    private bool jump;
    public float thrust = 150f;
    public float gravity = -9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = player.GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        fartSystem.SetActive(false);
    }

    private void FixedUpdate()
    {
        //keeps ragdoll upright
        Vector3 force = upForce * Vector3.up;
        rb.AddForce(force, ForceMode.Force);

        //movement
        //Vector3 move = new Vector3(playerMove.x, 0, playerMove.y);
        Vector3 move = transform.forward * playerMove.y + transform.right * playerMove.x;

        rb.velocity = move * speed * Time.deltaTime;

        //float targetAngle = MathF.Atan2(move.x, move.z);
        //hips.transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        //rb.AddForce(playerMove.x, 0, playerMove.y);

        //jump        
        if (jump)
        {
            Vector3 addThrust = thrust * Vector3.up * 3;
            force += addThrust;

            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("up force");

        }

        fartSystem.SetActive(jump);
                
    }

    public void PlayerMovement(InputAction.CallbackContext ctx)
    {
        playerMove = ctx.ReadValue<Vector2>();
        Debug.Log(playerMove);

        //animator.SetBool("isWalking", true);
    }

    public void PlayerCamera(InputAction.CallbackContext ctx)
    {
        playerMouse = ctx.ReadValue<Vector2>();

        //playerMouse.y = Mathf.Clamp(playerMouse.y, -20, 60);

        /*Quaternion rootRotation = Quaternion.Euler(playerMouse.y, playerMouse.x, 0).normalized;
        root.rotation = rootRotation;

        hips.targetRotation = Quaternion.Euler(0, playerMouse.x, 0).normalized;*/
    }

    public void PlayerJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.action.triggered;
        //Debug.Log(jump);
    }
}
