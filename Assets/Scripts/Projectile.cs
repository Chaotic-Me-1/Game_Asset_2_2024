using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;
    //Vector3 flightDirection;
    //public GameObject projectileSpawner;

    void Start()

    {
       //flightDirection = gameObject.transform.forward;
       //transform.localEulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    void Update()

    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
            //projectileInstance.transform.Translate(5f * Time.deltaTime * Vector3.forward);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //DAMAGE PLAYER HERE - Call custom function on player to deal damage
            //Potentially add variable to projectile for how much damage is dealt
            Debug.Log("PLAYER HIT!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Projectile hit " + other.gameObject.name);
            Destroy(gameObject);
        }




        }
    }
