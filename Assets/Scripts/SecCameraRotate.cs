using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecCameraRotate : MonoBehaviour
{
    public float rotateSpeed;
    Quaternion rotPoint1;
    Quaternion rotPoint2;
    public Transform cameraBody;

    // Start is called before the first frame update
    void Start()
    {
        //Store local transform on game start and calculate rotation from that instead of hard values 
        
        rotPoint1 = Quaternion.Euler(-30, -35, 0);
        rotPoint2 = Quaternion.Euler(-30, 35, 0);
        //cameraBody = transform.Find("CameraBody");
    }

    // Update is called once per frame
    void Update()
    {
        var factor = Mathf.PingPong(Time.time / rotateSpeed, 1);
        cameraBody.transform.rotation = Quaternion.Slerp(rotPoint1, rotPoint2, factor);
    }

}
