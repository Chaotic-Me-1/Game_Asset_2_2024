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
    }

    // Update is called once per frame
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
        lightRef.color = Color.white;
    }

}
