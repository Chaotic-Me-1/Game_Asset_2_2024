using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissaperingRedLine : MonoBehaviour
{
    public CodeUnlocked codeTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   // if you Interact with the code box the red line will dissapear
        if (codeTrigger.isUnlocked == true)
        {
            transform.gameObject.SetActive(false);
        }
    }
}