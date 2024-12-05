using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject player;
    public Transform respawnPoint;
    private float startingTime;
    public GameObject failedScreen;

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

            //RESPAWN ON TIMER FINISH, RESET TIMER VALUES & COLOUR, DEACTIVATE TIMER

            player.transform.position = respawnPoint.position;
            remainingTime = startingTime;
            timerText.color = Color.white;
            gameObject.SetActive(false);

            //QUIT GAME ON TIMER FINISH
            //Application.Quit();

            Debug.Log("Game end");
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //void FailScreen()
    //{
        
    //}
}
