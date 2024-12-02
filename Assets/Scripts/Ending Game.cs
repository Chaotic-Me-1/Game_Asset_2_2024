using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingGame : MonoBehaviour
{
    public bool IsPlayerInsideEnd = false;
    public GameObject Choice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}

