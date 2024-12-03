using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorunlock_animation : MonoBehaviour
{
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    public CodeUnlocked Unlocked;
    public bool isE_pressed;

    // Start is called before the first frame update
    void Start()
    {
        isE_pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            Unlocked.isUnlocked == true)
        {
            doorAnimation.SetTrigger("OpeningTrigger");
        }


        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
            
        {
            doorAnimation.SetTrigger("ClosingTrigger");
            isE_pressed = false;
           
        }



    }



}