using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUnlocked : MonoBehaviour
{

    public bool isUnlocked = false;
    public KeyPickup keypickup;
    [SerializeField] private bool isE_pressed;
    // Start is called before the first frame update
    void Start()
    {
        isUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        // When the E is press you will activate the bool
        if (Input.GetKeyDown(KeyCode.E))
        {
            isE_pressed = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // its to reset the E so you have press it when  you enter 
        isE_pressed = false;
    }








    public void OnTriggerStay(Collider other)
    {
        // if  you pressed E and Got the Item it will be true
        if (other.tag == "Player" &&
           isE_pressed == true &&
           keypickup.itemGot == true)

        {
            // this is used to for other scripts to know that you have interated with this object
            isUnlocked = true;
            Debug.Log(" its unlocked");
        }




    }


}
