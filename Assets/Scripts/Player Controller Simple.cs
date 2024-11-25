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

    public bool isRunning = false;// is the player running 
    public bool issneaking = false; //is the charature in a sneaking state
    public Animator playerAnim;
    private bool walking;
    private bool isTurning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the axis from unity to get horizontal to move the char
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        transform.Rotate(transform.up * turn * turnSpeed * Time.deltaTime);
        Vector3 newpos = transform.position + (transform.forward * move * currentSpeed * Time.deltaTime);
        transform.position = newpos;

        // Sneak with pressing G
        issneaking = Input.GetKey(KeyCode.G);

        // Running with pressing F
        isRunning = Input.GetKey(KeyCode.F);

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
            walking = false;
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("SlowRunBackwards");
            playerAnim.ResetTrigger("Idle");
            playerAnim.ResetTrigger("LeftTurn");
            playerAnim.ResetTrigger("RightTurn");
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
                isTurning = true;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetTrigger("Idle");
                playerAnim.ResetTrigger("RightTurn");
                isTurning = false;
            }



        }

    }

    public static void ResetAllTriggers(Animator animator)
    {
        foreach (var trigger in animator.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(trigger.name);
            }
        }
    }
}



