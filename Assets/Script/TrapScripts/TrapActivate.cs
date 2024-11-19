using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivate : MonoBehaviour
{
    public TrapTrigger trapTrigger;
    public bool trapActivate = false;


    // Start is called before the first frame update
    void Start()
    {
        //other.tag = ("Trap");

        //trapTrigger = GetComponentInParent<TrapTrigger>();
        Debug.Log(trapTrigger);
    }

    // Update is called once per frame
    void Update()
    {


        if (trapTrigger.trap == true)
        {
            trapActivate = true;
            transform.gameObject.SetActive(false);
        }

        //if(trapActivate == true) 
        //{
        //    Destroy(gameObject);

        //}
    }
}

