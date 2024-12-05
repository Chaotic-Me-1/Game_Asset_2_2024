using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpenSingle : MonoBehaviour
{
    public Animation SDAnimation;
    public bool open;
    public AudioSource slidingDoorSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
             open = true;
        }

        if (other.tag == ("Player") &&
            open == true)
        {
            SDAnimation.Play();
        }
     }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            open = false;
        }
    }

    void PlayDoorSound() 
    {
        slidingDoorSound.Play();
    }


    











}
