using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public PlayerInventroy toAdd;
    public bool itemGot = false;
    // Start is called before the first frame update
    void Start()
    {
        itemGot = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            //adding the transform to the array
            toAdd.inventory[0] = transform;
        // deleting/ removing the obgject from the game 
        transform.gameObject.SetActive(false);
        // just an indecator that you have pressed and i use it for other script to know that you have picked up the item   
        itemGot = true;



    }
}
