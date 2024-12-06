using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Veronica coding
    public float Maxhealth = 100;
    public float currenthealth;
    // Youtube.  
    public GameObject player;
    public Transform respawnPoint;

    //Healthbar UI Reference - Paul B.
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //making sure when the player start they have max health
        currenthealth = Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        /* TEMPORARY INPUT FOR TESTING DAMAGE & HEALTHBAR UI - Paul B.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Damage(10);
        }
        */
    }

    // making a funtion that reduces the players health when they take damage
    // funtion takes in damage amount
    public void Damage(float damage)
    {
        currenthealth -= damage;
        ;

        //if(damageVignette == true)
        //{
        //    vignetteColor = damageVignette.GetComponent("Color");
            
        //}

        // Update Health bar UI & check health after taking damage - Paul B.
        healthBar.fillAmount = currenthealth / 100f;
        checkHealth();
    }


            


    // making function that checks the players health
    void checkHealth()
    {
        //if the health is less then 0 you are dead 
        if (currenthealth <= 0)
        {
            Debug.Log("YOU ARE DEAD");

            //You are dead UI

            //Youtube. Teleport the player to the destend respawn point
            player.transform.position = respawnPoint.position;

            // Reset player health & Healthbar UI on respawn - Paul B.
            currenthealth = Maxhealth;
            healthBar.fillAmount = currenthealth / 100f;
        }

    }

}