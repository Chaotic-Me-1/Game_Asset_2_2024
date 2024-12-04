using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public Collider playerCapsule;
    public float rotateSpeed;
    public float castRange;
    public Collider castResult;
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    private IEnumerator shooterCoroutine;
    public float fireRate;
    public bool playerVisible = false;
    public int shootDelay;
    //public Vector3 direction;

    void Start()
    {
        shooterCoroutine = ShootCounter(fireRate);
        StartCoroutine(shooterCoroutine);

    }

    void Update()
    {
        var direction = (player.transform.position - transform.position);
        var targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (rotateSpeed * Time.deltaTime));
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

        if (shootDelay <= 20)
        {
            shootDelay++;
        }


 #region Handles Player Detection (Raycast)

        Debug.DrawRay(transform.position + new Vector3(0f, 1f, 0f), transform.TransformDirection(Vector3.forward) * castRange, Color.green);

        if (Physics.Raycast(transform.position + new Vector3(0f, 1f, 0f), transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo))
        {
            castResult = hitInfo.collider;
            if (castResult == playerCapsule)
            {
                Debug.DrawRay(transform.position + new Vector3(0f, 1f, 0f), transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
                Debug.Log("Pew! Pew! Shooting Player!");
                playerVisible = true;
            }

            else
            {
                playerVisible = false;
            }
        }

#endregion

    }

#region Handles Shooting & Firerate

    public IEnumerator ShootCounter(float fireRate)
    {
        while (true)
        {
            yield return new WaitUntil(() => shootDelay >= 20);

            if (playerVisible == true)

            {
                GameObject projectileInstance = Instantiate(projectile, projectileSpawnPoint);
                projectileInstance.transform.parent = null;
                shootDelay = 0;
                

                //projectileInstance = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
                //projectileInstance.transform.eulerAngles = Vector3.zero;
                //projectileInstance.transform.Translate(Vector3.forward * 5f * Time.deltaTime);
                //projectileInstance.transform.Translate(5f * Time.deltaTime * direction);
            }

        }
        
    }


    #endregion

}




/*TURRET ATTEMPT 1 
-- Simple LookAt rotation, looking at player. Can't control speed of rotation, have to create custom solution.

void Update()
{
    transform.LookAt(player.transform);
}

*/

/* TURRET ATTEMPT 2 
-- Using Unity Documentation, tried creating a custom "LookAt" rotation with Quaternion.RotateTowards. 
-- Can control speed, but rotation follows player's rotation, so the turret looks in the direction the player is looking, not AT the player.

 void Update()
{
    transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, (rotateSpeed * Time.deltaTime));
}
*/

/* TURRET ATTEMPT 3 
-- Works, but slightly distorts turret as the player Y position isn't exactly 0 during playtime. 
--Want to explore a better, more modular solution, in case we want to allow for a small range of vertical aim in turret.
--First need to fix rotation directly on turret, without referencing player Y position. 
--Then might have to have separate rotation on turret body, rotating around Y axis, and a small range of vertical rotation for the gun.

 void Update()
{
    if ((player.transform.position.y < 0f) || (player.transform.position.y > 0.1f))
    {
        return;
    }
    else
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (rotateSpeed * Time.deltaTime));
    }
}
*/

/*FIRING COROUTINE ATTEMPT 1
public class Turret : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed;
    public float castRange;
    public Transform castResult;
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    private IEnumerator shooterCoroutine;
    public float fireRate;

    void Start()
    {
        shooterCoroutine = ShootCounter(fireRate);
    }

    void Update()
    {
        var direction = (player.transform.position - transform.position);
        var targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (rotateSpeed * Time.deltaTime));
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

#region Handles Raycast

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * castRange, Color.green);

        if (Physics.Raycast(transform.position + transform.forward, transform.forward, out RaycastHit hitInfo))
        {
            castResult = hitInfo.collider.transform;

            if (castResult == player)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
                Debug.Log("Pew! Pew! Shooting Player!");
                StartCoroutine(shooterCoroutine);
            }

            else
            {
                StopCoroutine(shooterCoroutine);
            }
        }
        #endregion
    }

    public IEnumerator ShootCounter(float fireRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint);
        }
        
    }
}

*/

/* FIRING COROUTINE ATTEMPT 2
public class Turret : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed;
    public float castRange;
    public Transform castResult;
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    private IEnumerator shooterCoroutine;
    public float fireRate;
    public bool playerVisible = false;

    void Start()
    {
        shooterCoroutine = ShootCounter(fireRate, playerVisible);
        StartCoroutine(shooterCoroutine);
    }

    void Update()
    {
        var direction = (player.transform.position - transform.position);
        var targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (rotateSpeed * Time.deltaTime));
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

#region Handles Raycast

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * castRange, Color.green);

        if (Physics.Raycast(transform.position + transform.forward, transform.forward, out RaycastHit hitInfo))
        {
            castResult = hitInfo.collider.transform;

            if (castResult == player)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
                Debug.Log("Pew! Pew! Shooting Player!");
                playerVisible = true;
            }

            else
            {
                playerVisible = false;
            }
        }
        #endregion
    }

    public IEnumerator ShootCounter(float fireRate, bool playerVisible)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint);
        }
        
    }
}


*/

/*PROJECTILE TRAJECTORY FIX ATTEMPT 2
  public IEnumerator ShootCounter(float fireRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            if (playerVisible == true)

            {
                GameObject projectileInstance = Instantiate(projectile, projectileSpawnPoint);

                projectileInstance = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
                projectileInstance.transform.eulerAngles = Vector3.zero;

                projectileInstance.transform.Translate(5f * Time.deltaTime * Vector3.forward);
            }

        }
        
    }
*/