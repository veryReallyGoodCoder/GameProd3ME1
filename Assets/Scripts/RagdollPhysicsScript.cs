using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RagdollPhysicsScript : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource soundManager;
    [SerializeField] private AudioClip fartNoise;


    [Header("Reference")]
    private Rigidbody rb;

    public GameObject fartSystem;
    //public Animator animator;

    [Header("Movement")]
    private Vector2 playerMove;

    public float upForce = 600f;
    public float speed = 150f;

    [Header("Jump")]
    private bool jump;
    public float thrust = 150f;
    public float gravity = -9.81f;

    [Header("Health and Damage")]
    public float playerHealth = 100f;
    public float damage = 15;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        fartSystem.SetActive(false);
    }

    private void FixedUpdate()
    {
        //keeps ragdoll upright
        Vector3 force = upForce * Vector3.up;
        rb.AddForce(force, ForceMode.Force);

        //movement
        Vector3 move = transform.forward * playerMove.y + transform.right * playerMove.x;

        //Vector3 move = new Vector3(playerMove.x, 0, playerMove.y);

        rb.velocity = move * speed * Time.deltaTime;

        //jump        
        if (jump)
        {
            Vector3 addThrust = thrust * Vector3.up * 3;
            force += addThrust;

            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
            //Debug.Log("up force");
            

        }

        fartSystem.SetActive(jump);

        
   
    }

    public void PlayerMovement(InputAction.CallbackContext ctx)
    {
        playerMove = ctx.ReadValue<Vector2>();
        //Debug.Log(playerMove);
    }

    public void PlayerJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.action.triggered;
        soundManager.clip = fartNoise;
        soundManager.Play();
        if (!jump)
        {
            soundManager.Stop();
        }
        //Debug.Log(jump);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lemon")
        {
            playerHealth -= damage;
            Debug.Log(playerHealth);
        }
    }

}
