using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingGame : MonoBehaviour
{
    public bool IsPlayerInsideEnd = false;
    public GameObject Choice;
    public bool IsChoiceShowing;

    // Start is called before the first frame update
    void Start()
    {
        IsChoiceShowing = false;
    }
    //Make an trigger to detect the player and show UI
    //it accepts a collider to be checked
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //checking off that the player is inside and can show "choice" 
            IsPlayerInsideEnd = true;
            IsChoiceShowing = true;
            Choice.SetActive(IsChoiceShowing);

        }
      
    }
    //Make an trigger to detect the player and hiddes UI when exting 
    //it accepts a collider to be checked
    private void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInsideEnd = false;
            IsChoiceShowing = false;
            Choice.SetActive(IsChoiceShowing);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Ses if the player is inside of the collider 
        if (IsPlayerInsideEnd)
        {
            //Getting input for both T and O 
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.O))
            {
                //calls the quit game function to quit the game 
                Debug.Log("Game end");
                QuitGame();
            }
        }
    }
    //this function will quit the game 
    private void QuitGame()
    {
        Application.Quit();
    }
}
