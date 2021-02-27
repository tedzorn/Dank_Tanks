using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemyCannon : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 z_angle;
    private float angle = 1.0f;
    public GameObject gObj;
    public Rigidbody2D playerrb;
    public float Gunrotationspeed = 0.5f;
    public float waitTime = 0f;
    public GameObject _projectile;
    
    void Start()
    {
        gObj = GameObject.Find("Tank Blue Base Idle");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //waitTime += Time.deltaTime;
        // if (waitTime >= 1f)
        // {
        //  waitTime = waitTime % 1f;
        if (gObj??false)
        {
            GunMovement();
        }
        //  }

        waitTime += Time.deltaTime;

        if (waitTime >= 3f)
        {
            if (gObj ?? false)
            {
                Fire();
            }

            waitTime = 0f;
        }
    }

    void GunMovement()
    {
        
        playerrb = gObj.GetComponent<Rigidbody2D>();
        

        Vector3 playerLocation = playerrb.position;
        playerLocation.z = 0f;

        Vector3 aimDrection = (playerLocation - transform.position).normalized;
        angle = (Mathf.Atan2(aimDrection.y, aimDrection.x) * Mathf.Rad2Deg) - 90;
        z_angle = new Vector3(0, 0, angle);
        transform.eulerAngles = z_angle;
    }

    void Fire()
    {
        playerrb = gObj.GetComponent<Rigidbody2D>();
        
        Vector3 playerLocation = playerrb.position;
        playerLocation.z = 0f;

        Vector3 aimDrection = (playerLocation - transform.position).normalized;
        
        var newProjectile = Instantiate(_projectile, transform.position + transform.up * 1.15f, transform.rotation) as GameObject;
        newProjectile.GetComponent<Projectile>().Initialize(aimDrection * 5);
    }
}