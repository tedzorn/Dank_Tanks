using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CannonScript : MonoBehaviour
{
    private Vector3 z_angle;
    private float angle = 1.0f;
    public GameObject _projectile;
    private float nextShot = 0f;
    public float shotRate = 0.5f;

    private AudioSource playerSource;
    public AudioClip fireClip;
    
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLocation.z = 0f;

        Vector3 aimDrection = (mouseLocation - transform.position).normalized;
        angle = (Mathf.Atan2(aimDrection.y, aimDrection.x) * Mathf.Rad2Deg) - 90;
        z_angle = new Vector3(0, 0, angle);
        transform.eulerAngles = z_angle;

        if (PauseMenu.GameIsPaused==false && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + shotRate;
                Fire();
            }
        }

    }

    void Fire()
    {
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLocation.z = 0f;

        Vector3 aimDrection = (mouseLocation - transform.position).normalized;
        var newProjectile = Instantiate(_projectile, transform.position + transform.up * 0.9f, transform.rotation) as GameObject;
        newProjectile.GetComponent<PlayerProjectile>().Initialize(aimDrection * 5);
	GetComponent<AudioSource>().PlayOneShot(fireClip, .3f);
    }
}
