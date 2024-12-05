using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    //Veronica code & Youtube 
    bool PlayerHasFallen = false;
    // Youtube.  
    public GameObject Player;
    public Transform respawnPoint;

    void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHasFallen = true;
            Debug.Log("Obs get up again");

            //Youtube. Teleport the player to the destend respawn point
            Player.transform.position = respawnPoint.position;

        }
    }
}
