using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIPhone : MonoBehaviour
{   //Veronicas code
    public bool IsMainShowing; // checking if the main is showing 
    public GameObject Mail; //Getting the canvas object

    // Start is called before the first frame update
    void Start()
    {   //setting the statment at ture when the game start 
        IsMainShowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //The player can lose the UI when they are done 
        //Making it a one time event 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsMainShowing = false;
            Mail.SetActive(IsMainShowing);
            Debug.Log("Mails here");
        }
            
    }
}
