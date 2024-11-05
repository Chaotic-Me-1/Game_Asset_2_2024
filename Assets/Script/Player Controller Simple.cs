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
    public bool issneaking = false; //is the charature in a sneaking state
    public float currentSpeed = 0; //stablish the state of speed takes place
    public bool isRunning = false;// is the player running 
    

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
       
    }
}
