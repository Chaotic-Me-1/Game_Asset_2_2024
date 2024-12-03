using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor : MonoBehaviour
{
    public Animator Floor1Door;
    public Dooropen_animation dooropen_Animation; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dooropen_Animation.DoorLvl1open == true) 
        {
            Floor1Door.SetTrigger("OpeningTrigger");
            Debug.Log("its opening");
        }

        if (dooropen_Animation.DoorLvl1closed == true)
        {
            Floor1Door.SetTrigger("ClosingTrigger");
        }





    }




}
