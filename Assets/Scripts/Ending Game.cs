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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInsideEnd = true;
            IsChoiceShowing = true;
            Choice.SetActive(IsChoiceShowing);

        }
      
    }
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
        if (IsPlayerInsideEnd)
        {
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Game end");
                QuitGame();
            }
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}

