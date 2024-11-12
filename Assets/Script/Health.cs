using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Veronica coding
    public int Maxhealth = 100;
    public int currenthealth;
    // Youtube.  
    public GameObject player;
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //making sure when the player start they have max health
        currenthealth = Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        //if the health is less then 0 you are dead 
        if (currenthealth <= 0)
        {
            //You are dead UI

            //Youtube. Teleport the player to the destend respawn point
            player.transform.position = respawnPoint.position;

        }
    }
    // making a own void for damage saying the players health will do down from damage
    void Damage(int damage)
    {
        currenthealth -= damage;

    }
}