using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecCameraDetection : MonoBehaviour
{
    public GameObject lightToChange;
    private Light lightRef;
    public GameObject timerScript;

    void Start()
    {
        lightRef = lightToChange.GetComponent<Light>();

        //timerScript = GameObject.FindGameObjectWithTag("Timer");
    }

    // Timer doesn't trigger for some reason, tried to set it up within script, but can go back to original method
    // of setting the timerScript GameObject manually on each camera. (Or save timer as a prefab, and then maybe it's possible to add to camera prefab


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!!!");
            timerScript.SetActive(true);

            lightRef.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lightRef.color = Color.yellow;
    }

}
