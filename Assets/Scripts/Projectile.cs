using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;
    //Vector3 flightDirection;
    //public GameObject projectileSpawner;
    private GameObject player;
    public float damageAmount;

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
            player = other.gameObject;
            player.GetComponent("Health").BroadcastMessage("Damage", damageAmount);

            //Debug.Log("PLAYER HIT!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Projectile hit " + other.gameObject.name);
            Destroy(gameObject);
        }

        }
    }
