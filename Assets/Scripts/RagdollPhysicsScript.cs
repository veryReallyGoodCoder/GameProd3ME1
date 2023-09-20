using UnityEngine;
using UnityEngine.InputSystem;

public class RagdollPhysicsScript : MonoBehaviour
{

    [Header("Reference")]
    Rigidbody rb;
    //public GameObject player;
    //public Animator animator;

    [Header("Movement")]
    private Vector2 playerMove;

    public float upForce = 600f;
    public float speed = 150f;

    [Header("Jump")]
    private bool jump;
    public float thrust = 150f;
    public float gravity = -9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = player.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //keeps ragdoll upright
        Vector3 force = upForce * Vector3.up;
        rb.AddForce(force, ForceMode.Force);

        //jump        
        if (jump)
        {
            Vector3 addThrust = thrust * Vector3.up * 3;
            force += addThrust;

            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("up force");
        }

        //movement
        Vector3 move = new Vector3(playerMove.x, 0, playerMove.y);
        rb.velocity = move * speed * Time.deltaTime;

        //rb.AddForce(playerMove.x, 0, playerMove.y);

    }

    public void PlayerMovement(InputAction.CallbackContext ctx)
    {
        playerMove = ctx.ReadValue<Vector2>();
        Debug.Log(playerMove);

        //animator.SetBool("isWalking", true);
    }

    public void PlayerJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.action.triggered;
        //Debug.Log(jump);
    }
}