using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorunlock_animation : MonoBehaviour
{
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    public CodeUnlocked Unlocked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Animator a = game.GetComponent<Animator>();


        //if (trigger.trap == true) 
        //{
        //    doorAnimation.Play();

        //}    


    }

    private void OnTriggerEnter(Collider other)
    {       // a simple trigger that when you have Interacted CodeUnlocked the animation will play when entering  
        if (other.tag == ("Player") &&
            Unlocked.isUnlocked == true)
        {
            



        }
    }
}
