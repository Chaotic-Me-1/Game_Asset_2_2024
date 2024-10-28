using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // code mix John & Veronica
    public float moveSpeed = 10;
    public float turnSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        transform.Rotate(transform.up * turn * turnSpeed * Time.deltaTime);
        Vector3 newpos = transform.position + (transform.forward * move * moveSpeed * Time.deltaTime);
        transform.position = newpos;

        // test sneak add animation later
        if (Input.GetKeyDown(KeyCode.G))
        {

            Debug.Log("You cliked sneak");
        }


    }
}
