using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dooropen_animation : MonoBehaviour
{
    public Text Press_E;
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    //public CodeUnlocked Unlocked;
    public bool isE_pressed;
    public bool DoorLvl1open;
    public bool DoorLvl1closed;
    public AudioSource slidingDoorSound;

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

        if (other.tag == ("Player")) 
        {
            Press_E.gameObject.SetActive(true);
        }



        if (other.tag == ("Player") && 
            isE_pressed == true)
        {
            doorAnimation.SetTrigger("OpeningTrigger"); 
            Debug.Log ("is opening");
            DoorLvl1open = true;
            Press_E.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other) 
    {

        if (other.tag == ("Player"))
        {
            Press_E.gameObject.SetActive(false);
        }


        if ( other.tag == ("Player")   &&
            DoorLvl1open == true) 
        {
            doorAnimation.ResetTrigger("OpeningTrigger");
            doorAnimation.SetTrigger("ClosingTrigger");
            isE_pressed = false;
            DoorLvl1closed = true; 
        }
    }

    void PlayDoorSound()
    {
        slidingDoorSound.pitch = 1f;
        slidingDoorSound.Play();
    }

    void PlayDoorSoundSlowed()
    {
        slidingDoorSound.pitch = 0.4f;
        slidingDoorSound.Play();
    }
}
