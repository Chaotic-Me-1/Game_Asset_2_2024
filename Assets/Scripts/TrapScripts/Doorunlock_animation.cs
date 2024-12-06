using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doorunlock_animation : MonoBehaviour
{
    public Text Press_E;
    public Animator doorAnimation;
    //public TrapTrigger trigger;
    public CodeUnlocked Unlocked;
    public bool isE_pressed;
    public AudioSource slidingDoorSound;

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
    {
        if (other.tag == ("Player") &&
            Unlocked.isUnlocked == true)
        {
            Press_E.gameObject.SetActive(true);


        }


        // a simple trigger that when you have Interacted CodeUnlocked the animation will play when entering  
        if (other.tag == ("Player") &&
            Unlocked.isUnlocked == true &&
            isE_pressed == true         )
        {
            doorAnimation.SetTrigger("OpeningTrigger");
            Press_E.gameObject.SetActive(false);

        }


        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
            
        {
            doorAnimation.SetTrigger("ClosingTrigger");
            isE_pressed = false;
            doorAnimation.ResetTrigger("OpeningTrigger");
            Press_E.gameObject.SetActive(false);
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