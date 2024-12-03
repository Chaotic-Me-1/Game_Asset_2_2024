using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropen_animation : MonoBehaviour
{
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    //public CodeUnlocked Unlocked;
    public bool isE_pressed;
    // Start is called before the first frame update
    void Start()
    {
        isE_pressed = true;
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
            doorAnimation.SetBool("Opening", true); 
            Debug.Log ("is opening");
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if( other.tag == ("Player")) 
        {
            doorAnimation.SetBool("Opening", false);
            isE_pressed = false;

        }
    
    
    
    }


}
