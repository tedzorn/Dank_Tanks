using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D bossrb;
    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
    private Vector3 lookAtPosition;
    private float angle = 1.0f;
    void Start()
    {
        bossrb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    
 
    void Update() {

        //if (Time.time % 5 == 0)
        //{
            
        //}
        //else
        //{
            BossMovement();
            
        //}
 
    }

    void BossMovement()
    {
        transform.Translate(0f, 0.3f * Time.deltaTime, 0f);
    }
    void BossRotation()
    {
        lookAtPosition = new Vector3(Random.Range(-20f, 20f),0, Random.Range(-20f, 20f) );
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;
       
        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * 50);
       /* Debug.Log("in rotation");
        Vector3 rotationpoint = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0);
        
        Vector3 aimDirection = (rotationpoint - transform.position).normalized;
        angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        var neededRotation = Quaternion.LookRotation(Vector3.forward, aimDirection - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,neededRotation, 1f * Time.deltaTime);
        */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
            
        BossRotation();
        
    }
    
    
    
}
