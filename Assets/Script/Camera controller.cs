//-----CameraFollow script-----\\
//---Author:MrPyxel---\\
//---Version:1.5---\\
//---Update:10/05/2017 22:20---\\


//-----Libraries-----\\
using System.Collections;
using UnityEngine;

//-----Script body-----\\
public class Cameracontroller: MonoBehaviour
{
    //-----Privates variables-----\\
    private Vector3 offset;

    //-----Publics variables-----\\
    [Header("Variables")]
    public Transform player;

    [Header("Position")] //creating float for the camera posistion axes
    public float camPosX;
    public float camPosY;
    public float camPosZ;

    [Header("Rotation")] // creating a float for the camera rotation axes
    public float camRotationX;
    public float camRotationY;
    public float camRotationZ;


    [Range(0f, 10f)] // making a statment for the turn speed 
    public float turnSpeed;

    //-----Privates functions-----\\
    private void Start()
    {
        offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);

        // Veronica code. Adding a cursor lock so the cursor dont go everywhere
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);


    }
}