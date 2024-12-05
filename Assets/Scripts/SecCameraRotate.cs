using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecCameraRotate : MonoBehaviour
{
    public float rotateSpeed;
    Quaternion rotPoint1;
    Quaternion rotPoint2;
    //private Vector3 lookDirection;
    public float rotAmount;
    public Transform cameraBody;

    // Start is called before the first frame update
    void Start()
    {
        //Store local transform on game start and calculate rotation from that instead of hard values 

        //rotPoint1 = Quaternion.AngleAxis(rotAmount *-1, Vector3.up);
        //rotPoint2 = Quaternion.AngleAxis(rotAmount, Vector3.up);

        //lookDirection = Vector3.forward;
        //rotPoint1 = Quaternion.LookRotation(lookDirection, Vector3.up)

        rotPoint1 = Quaternion.Euler(cameraBody.rotation.x + 30, cameraBody.localRotation.y + rotAmount, cameraBody.rotation.z);
        rotPoint2 = Quaternion.Euler(cameraBody.rotation.x + 30, cameraBody.localRotation.y - rotAmount, cameraBody.rotation.z);

        //rotPoint1 = Quaternion.Euler(30, -35, 0);
        //rotPoint2 = Quaternion.Euler(30, 35, 0);
        //cameraBody = transform.Find("camera_body");
    }

    // Update is called once per frame
    void Update()
    {
        var factor = Mathf.PingPong(Time.time / rotateSpeed, 1);
        cameraBody.transform.localRotation = Quaternion.Slerp(rotPoint1, rotPoint2, factor);
        //cameraBody.transform.rotation = Quaternion.Lerp(rotPoint1, rotPoint2, factor);
    }

}
