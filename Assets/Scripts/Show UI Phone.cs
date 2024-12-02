using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIPhone : MonoBehaviour
{
    public bool IsMainShowing;
    public GameObject Mail;

    // Start is called before the first frame update
    void Start()
    {
        IsMainShowing = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsMainShowing = false;
            Mail.SetActive(IsMainShowing);
            Debug.Log("Mails here");
        }
            
    }
}
