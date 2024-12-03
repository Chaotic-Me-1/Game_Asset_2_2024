using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropen_animation : MonoBehaviour
{
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    //public CodeUnlocked Unlocked;
    public bool isE_pressed;
    public bool DoorLvl1open;
    public bool DoorLvl1closed;
    // Start is called before the first frame update
    void Start()
    {
        isE_pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Animator a = game.GetComponent<Animator>();


        //if (trigger.trap == true) 
        //{
        //    doorAnimation.Play();

        //}    

        if (Input.GetKeyDown(KeyCode.E))
        {
            isE_pressed = true;

        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        isE_pressed = false;
    }


    





    private void OnTriggerStay(Collider other)
    {       // a simple trigger that when you have Interacted CodeUnlocked the animation will play when entering  
        if (other.tag == ("Player") && 
            isE_pressed == true)
        {
            doorAnimation.SetTrigger("OpeningTrigger"); 
            Debug.Log ("is opening");
            DoorLvl1open = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if( other.tag == ("Player")   &&
            DoorLvl1open == true) 
        {
            doorAnimation.SetTrigger("ClosingTrigger");
            isE_pressed = false;
            DoorLvl1closed = true;
        }
    
    
    
    }


}
