using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // code mix John & Veronica

    public float moveSpeed = 10; //default movment speed 
    public float sneakSpeed = 5; // have a slower speed then the walk
    public float turnSpeed = 100; // default turning speed 
    public float maxSpeed = 15; // the max speed tha player can go
    public float currentSpeed = 0; //stablish the state of speed takes place

    public bool isRunning = false;// is the player running 
    public bool issneaking = false; //is the charature in a sneaking state
    public Animator playerAnim;
    private bool walking;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("SlowRun");
            playerAnim.ResetTrigger("Idle");
            walking = true;
        }

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
    }
}
