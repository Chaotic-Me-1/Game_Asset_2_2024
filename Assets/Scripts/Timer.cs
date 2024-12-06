using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //Youtube & Veronica code & Paul code
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject player;
    public Transform respawnPoint;
    public float startingTime;
    public GameObject failedScreen;
    public bool failScreenShowing;

    // Update is called once per frame
    void Start()
    {
        startingTime = remainingTime;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        
        else if (remainingTime <= 0)
        {
            remainingTime = 0;

            //Gameover
            timerText.color = Color.red;


            failedScreen.SetActive(true);
            failScreenShowing = true;
        }

        if (failScreenShowing && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (failScreenShowing && Input.GetKeyDown(KeyCode.F))
        {
            QuitGame();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Restart()
    {
        //Runs if pressing "R" on "Mission Failed" screen
        //Teleports player to start point, resets timer values & colour, deactivates timer
        //Hides "Mission Failed" screen & resets bool

        failScreenShowing = false;
        failedScreen.SetActive(false);
        gameObject.SetActive(false);
        player.transform.position = respawnPoint.position;
        remainingTime = startingTime;
        timerText.color = Color.white;

    }

    void QuitGame()
    {
        //Runs if pressing "F" on Mission Failed screen
        //Debug print for testing in editor
        //Quits game in built version

        Debug.Log("Quit Game");
        Application.Quit();

    } 
}
