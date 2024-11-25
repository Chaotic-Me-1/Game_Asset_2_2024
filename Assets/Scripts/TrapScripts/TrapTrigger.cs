using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapTrigger : MonoBehaviour
{ 


public bool trap = false;
public Transform[] Cutt;
public PlayerInventroy invCheck;
//public Keypickup keypickup;
public CodeUnlocked CodeUnlocked;
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
    //bool keyunlocked = invCheck != null;
    // it cheaks the array size and adds 1 when CodeUnlocked.isUnlocked == true  
    int keyunlocked = invCheck.inventory.Length - 1;
    if (CodeUnlocked.isUnlocked == true)
    {
        keyunlocked++;



    }

    Debug.Log(keyunlocked);

    // if the array is bigger then 0 the the trap will remain false 
    if (other.tag == "Player" &&
         keyunlocked > 0)
    {

        trap = false;
        Debug.Log(" wire cut ");

        //Debug.Log("hit the player");
        //trap = true;
    }

    else
    {
        Debug.Log("hit the player");
        trap = true;
    }




    //if (other.tag == "Player")
    //{
    //    trap = true;

    //}

}

    




}
