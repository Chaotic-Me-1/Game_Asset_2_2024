using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // code mix John & Veronica & Paul

    public float moveSpeed = 10; //default movment speed 
    public float sneakSpeed = 5; // have a slower speed then the walk
    public float turnSpeed = 100; // default turning speed 
    public float maxSpeed = 15; // the max speed tha player can go
    public float currentSpeed = 0; //stablish the state of speed takes place

    public Vector3 jump;
    public float jumpForce = 0.25f;
    public bool IsGrounded;
    private Rigidbody rb;
    private bool isjumping;

    public bool isRunning = false;// is the player running 
    public bool issneaking = false; //is the charature in a sneaking state
    public Animator playerAnim;
    private bool walking;
    private bool isTurning;
    public float rbVelocity;
    public float GRAVITY = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = Vector3.up;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rbVelocity = rb.velocity.magnitude;
        transform.Rotate(transform.up * turn * turnSpeed * Time.deltaTime);
        Vector3 newpos = transform.position + (transform.forward * move * currentSpeed * Time.deltaTime);
        transform.position = newpos;

        // Sneak with pressing G
        issneaking = Input.GetKey(KeyCode.G);

        // Running with pressing Shift
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // check if sneaking
        if (issneaking)
        {
            //changing the speed of sneak
            currentSpeed = sneakSpeed;
            Debug.Log("You cliked sneak");
        }
        //checking if running 
        else if (isRunning)
        {

            //changing the speed to running
            currentSpeed = maxSpeed;
            Debug.Log("You are running");

        }
        // no mater if G or F is pushed the players speed will return back to the normal walking speed 
        else
        {
            // going back to default speed
            currentSpeed = moveSpeed;

        }

        //Jump is space
        isjumping = Input.GetKeyDown(KeyCode.Space);

        if (isjumping&&IsGrounded)
        {
            //using force and gavity to make the player jump to keep the rb
            rb.AddForce(jump * jumpForce * GRAVITY, ForceMode.Impulse);
            IsGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerAnim.SetTrigger("Jump");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.ResetTrigger("Jump");
            playerAnim.SetTrigger("SlowRun");
        }


        //Using rigidbody velocity to reset all triggers and go to idle when standing still, just in case they haven't set/reset properly elsewhere.
        if (rbVelocity == 0)
        {
            playerAnim.ResetTrigger("LeftTurn");
            playerAnim.ResetTrigger("RightTurn");
            playerAnim.ResetTrigger("Jump");
            playerAnim.ResetTrigger("SlowRun");
            playerAnim.ResetTrigger("SlowRunBackwards");
            playerAnim.ResetTrigger("FastRun");
            playerAnim.SetTrigger("Idle");
        }

        if (Input.GetKey(KeyCode.W) && isTurning == true)
        {
            playerAnim.ResetTrigger("LeftTurn");
            playerAnim.ResetTrigger("RightTurn");
            playerAnim.SetTrigger("SlowRun");
            playerAnim.ResetTrigger("Idle");
            walking = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("SlowRun");
            playerAnim.ResetTrigger("Idle");
            walking = true;
            playerAnim.ResetTrigger("Jump");
        }

        // Partially fixed transition from turning to running animations, if the A or D key is still being held, but it only triggers
        // when W is pressed a second time, not immediately? 
        // Also if A or D is still held when player stops running (holding W) it doesn't switch to turning left/right

        //ResetAllTriggers(playerAnim);
        //Debug.Log("Resetting All Animation Triggers");

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetTrigger("Idle");
            playerAnim.ResetTrigger("SlowRun");
            playerAnim.ResetTrigger("FastRun");
            walking = false;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("SlowRunBackwards");
            playerAnim.ResetTrigger("Idle");
            playerAnim.ResetTrigger("LeftTurn");
            playerAnim.ResetTrigger("RightTurn");
            playerAnim.ResetTrigger("Jump");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetTrigger("Idle");
            playerAnim.ResetTrigger("SlowRunBackwards");
        }

        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerAnim.SetTrigger("FastRun");
                playerAnim.ResetTrigger("SlowRun");
                playerAnim.ResetTrigger("Jump");
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerAnim.SetTrigger("SlowRun");
                playerAnim.ResetTrigger("FastRun");
            }

        }

        if (walking == false)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnim.SetTrigger("LeftTurn");
                playerAnim.ResetTrigger("Idle");
                playerAnim.ResetTrigger("RightTurn");
                playerAnim.ResetTrigger("Jump");
                isTurning = true;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetTrigger("Idle");
                playerAnim.ResetTrigger("LeftTurn");
                isTurning = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerAnim.SetTrigger("RightTurn");
                playerAnim.ResetTrigger("Idle");
                playerAnim.ResetTrigger("LeftTurn");
                playerAnim.ResetTrigger("Jump");
                isTurning = true;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetTrigger("Idle");
                playerAnim.ResetTrigger("RightTurn");
                isTurning = false;
            }

            //public static void ResetAllTriggers(Animator animator)
            //{
            //    foreach (var trigger in animator.parameters)
            //    {
            //        if (trigger.type == AnimatorControllerParameterType.Trigger)
            //        {
            //            animator.ResetTrigger(trigger.name);
            //        }
            //    }
            //}
        }
    }

    void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            Debug.Log("You are on ground");

        }
    }
}